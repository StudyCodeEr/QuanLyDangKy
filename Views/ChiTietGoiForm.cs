using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using QuanLyDangKy.Data;

namespace QuanLyDangKy.Views
{
    public partial class ChiTietGoiForm : Form
    {
        private int _maGoi;
        private string mauSacDaChon = "#34A853";
        private Guna.UI2.WinForms.Guna2CircleButton nutMauDangChon = null;
        private bool _trangThaiHoatDong = true;

        // Constructor NHẬN ID TỪ TRANG CHỦ TRUYỀN SANG
        public ChiTietGoiForm(int maGoi)
        {
            InitializeComponent();
            _maGoi = maGoi;
        }

        // ===============================================
        // 1. LOAD DỮ LIỆU TỪ DATABASE
        // ===============================================
        private void ChiTietGoiForm_Load(object sender, EventArgs e)
        {
            try
            {
                KetNoiDuLieu db = new KetNoiDuLieu();
                using (MySqlConnection conn = new MySqlConnection(db.LayChuoiKetNoi()))
                {
                    string query = "SELECT * FROM GoiDangKy WHERE MaGoi = @magoi";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@magoi", _maGoi);
                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Đổ Text
                                txtTenDichVu.Text = reader.GetString("TenDichVu");
                                cmbTheLoai.SelectedItem = reader.GetString("TheLoai");
                                txtGiaTien.Text = reader.GetDecimal("GiaGoc").ToString("0");

                                string tienTe = reader.GetString("DonViTienTe");
                                if (cmbTienTe.Items.Contains(tienTe)) cmbTienTe.SelectedItem = tienTe;

                                dtpNgayGiaHan.Value = reader.GetDateTime("NgayGiaHan");

                                // Thiết lập Trạng Thái (Tạm ngưng / Hoạt động)
                                _trangThaiHoatDong = reader.GetBoolean("TrangThaiHoatDong");
                                CapNhatGiaoDienNutTamNgung();

                                // Thiết lập Màu Sắc
                                mauSacDaChon = reader.GetString("MauSac");
                                ChonMauTuDatabase(mauSacDaChon);
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message); }
        }

        // ===============================================
        // 2. LOGIC GIAO DIỆN (NÚT TẠM NGƯNG & MÀU SẮC)
        // ===============================================
        private void CapNhatGiaoDienNutTamNgung()
        {
            if (_trangThaiHoatDong)
            {
                btnTamNgung.Text = "⏸️ TẠM NGƯNG";
                btnTamNgung.FillColor = Color.FromArgb(242, 153, 74); // Màu Cam
            }
            else
            {
                btnTamNgung.Text = "▶️ KHÔI PHỤC";
                btnTamNgung.FillColor = Color.FromArgb(46, 204, 113); // Màu Xanh lá
            }
        }

        private void ChonMauTuDatabase(string maHex)
        {
            Guna.UI2.WinForms.Guna2CircleButton[] danhSachNutMau = { btnMau1, btnMau2, btnMau3, btnMau4, btnMau5 };
            bool timThayMauCoSan = false;

            // Quét xem màu trong DB có khớp với 5 nút có sẵn không
            foreach (var nut in danhSachNutMau)
            {
                string hexCuaNut = $"#{nut.FillColor.R:X2}{nut.FillColor.G:X2}{nut.FillColor.B:X2}";
                if (hexCuaNut.Equals(maHex, StringComparison.OrdinalIgnoreCase))
                {
                    HieuUngChonMau(nut);
                    timThayMauCoSan = true;
                    break;
                }
            }

            // Nếu không khớp màu nào, đổ màu đó vào nút Custom
            if (!timThayMauCoSan)
            {
                try
                {
                    btnMauCustom.FillColor = ColorTranslator.FromHtml(maHex);
                    btnMauCustom.Text = "";
                    HieuUngChonMau(btnMauCustom);
                }
                catch { HieuUngChonMau(btnMau1); } // Lỗi thì lấy màu 1 làm gốc
            }
        }

        private void HieuUngChonMau(Guna.UI2.WinForms.Guna2CircleButton nutDuocChon)
        {
            if (nutMauDangChon != null)
            {
                nutMauDangChon.BorderThickness = 0;
                if (nutMauDangChon == btnMauCustom) nutMauDangChon.BorderThickness = 1;
            }

            nutMauDangChon = nutDuocChon;
            nutMauDangChon.BorderColor = Color.Black;
            nutMauDangChon.BorderThickness = 3;

            mauSacDaChon = $"#{nutDuocChon.FillColor.R:X2}{nutDuocChon.FillColor.G:X2}{nutDuocChon.FillColor.B:X2}";
        }

        private void MauCoSan_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2CircleButton clickedBtn = sender as Guna.UI2.WinForms.Guna2CircleButton;
            HieuUngChonMau(clickedBtn);
        }

        private void btnMauCustom_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                btnMauCustom.FillColor = colorDialog.Color;
                btnMauCustom.Text = "";
                HieuUngChonMau(btnMauCustom);
            }
        }

        // ===============================================
        // 3. CÁC NÚT CHỨC NĂNG: TẠM NGƯNG - LƯU - XÓA
        // ===============================================

        private void btnTamNgung_Click(object sender, EventArgs e)
        {
            // Đảo ngược trạng thái
            bool trangThaiMoi = !_trangThaiHoatDong;

            try
            {
                KetNoiDuLieu db = new KetNoiDuLieu();
                using (MySqlConnection conn = new MySqlConnection(db.LayChuoiKetNoi()))
                {
                    string query = "UPDATE GoiDangKy SET TrangThaiHoatDong = @tt WHERE MaGoi = @magoi";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@tt", trangThaiMoi);
                        cmd.Parameters.AddWithValue("@magoi", _maGoi);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                // Cập nhật lại UI và báo cho Trang Chủ load lại lịch
                _trangThaiHoatDong = trangThaiMoi;
                CapNhatGiaoDienNutTamNgung();
                MessageBox.Show(trangThaiMoi ? "Đã khôi phục gói thành công!" : "Đã tạm ngưng gói.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDichVu.Text) || !decimal.TryParse(txtGiaTien.Text, out decimal gia))
            {
                MessageBox.Show("Vui lòng kiểm tra lại Tên và Giá tiền!", "Lỗi");
                return;
            }

            try
            {
                KetNoiDuLieu db = new KetNoiDuLieu();
                using (MySqlConnection conn = new MySqlConnection(db.LayChuoiKetNoi()))
                {
                    string query = @"UPDATE GoiDangKy 
                                     SET TenDichVu=@ten, TheLoai=@loai, GiaGoc=@gia, DonViTienTe=@tiente, NgayGiaHan=@ngay, MauSac=@mau 
                                     WHERE MaGoi=@magoi";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ten", txtTenDichVu.Text.Trim());
                        cmd.Parameters.AddWithValue("@loai", cmbTheLoai.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@gia", gia);
                        cmd.Parameters.AddWithValue("@tiente", cmbTienTe.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@ngay", dtpNgayGiaHan.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@mau", mauSacDaChon);
                        cmd.Parameters.AddWithValue("@magoi", _maGoi);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi cập nhật: " + ex.Message); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa vĩnh viễn gói này khỏi lịch sử?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    KetNoiDuLieu db = new KetNoiDuLieu();
                    using (MySqlConnection conn = new MySqlConnection(db.LayChuoiKetNoi()))
                    {
                        string query = "DELETE FROM GoiDangKy WHERE MaGoi = @magoi";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@magoi", _maGoi);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex) { MessageBox.Show("Lỗi xóa: " + ex.Message); }
            }
        }
    }
}