using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using QuanLyDangKy.Data;
using QuanLyDangKy.Models;

namespace QuanLyDangKy.Views
{
    public partial class CaiDatForm : Form
    {
        public CaiDatForm()
        {
            InitializeComponent();
        }

        private void CaiDatForm_Load(object sender, EventArgs e)
        {
            // 1. Đồng bộ UI với các biến toàn cục trong RAM
            if (cmbTienTe.Items.Contains(PhienDangNhap.TienTeMacDinh))
                cmbTienTe.SelectedItem = PhienDangNhap.TienTeMacDinh;
            else
                cmbTienTe.SelectedIndex = 0;

            tgDarkMode.Checked = PhienDangNhap.CheDoToi;

            // Xử lý ComboBox Số ngày nhắc
            if (PhienDangNhap.SoNgayNhac == 0) cmbSoNgayNhac.SelectedIndex = 0;
            else if (PhienDangNhap.SoNgayNhac == 1) cmbSoNgayNhac.SelectedIndex = 1;
            else if (PhienDangNhap.SoNgayNhac == 3) cmbSoNgayNhac.SelectedIndex = 2;
            else if (PhienDangNhap.SoNgayNhac == 7) cmbSoNgayNhac.SelectedIndex = 3;
            else cmbSoNgayNhac.SelectedIndex = 4; // Tắt (-1)
        }

        private void btnLuuCaiDat_Click(object sender, EventArgs e)
        {
            string tienTe = cmbTienTe.SelectedItem?.ToString() ?? "VND";
            bool darkmode = tgDarkMode.Checked;

            // Dịch lại số ngày từ ComboBox
            int soNgay = 3;
            if (cmbSoNgayNhac.SelectedIndex == 0) soNgay = 0;
            else if (cmbSoNgayNhac.SelectedIndex == 1) soNgay = 1;
            else if (cmbSoNgayNhac.SelectedIndex == 2) soNgay = 3;
            else if (cmbSoNgayNhac.SelectedIndex == 3) soNgay = 7;
            else if (cmbSoNgayNhac.SelectedIndex == 4) soNgay = -1;

            try
            {
                // Cập nhật Database
                KetNoiDuLieu db = new KetNoiDuLieu();
                using (MySqlConnection conn = new MySqlConnection(db.LayChuoiKetNoi()))
                {
                    string query = "UPDATE nguoidung SET TienTeMacDinh = @tiente, CheDoToi = @dark, SoNgayNhacNho = @songay WHERE MaNguoiDung = @uid";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@tiente", tienTe);
                        cmd.Parameters.AddWithValue("@dark", darkmode ? 1 : 0);
                        cmd.Parameters.AddWithValue("@songay", soNgay);
                        cmd.Parameters.AddWithValue("@uid", PhienDangNhap.MaNguoiDungHienTai);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                // Cập nhật lại RAM
                PhienDangNhap.TienTeMacDinh = tienTe;
                PhienDangNhap.CheDoToi = darkmode;
                PhienDangNhap.SoNgayNhac = soNgay;

                MessageBox.Show("Đã lưu cài đặt thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi lưu cài đặt: " + ex.Message); }
        }

        private void btnResetDuLieu_Click(object sender, EventArgs e)
        {
            DialogResult xacNhan = MessageBox.Show(
                "CẢNH BÁO: Hành động này sẽ XÓA SẠCH toàn bộ gói đăng ký và lịch sử của bạn.\nTài khoản và Cài đặt vẫn được giữ nguyên.\nBạn có chắc chắn muốn tiếp tục?",
                "Xác nhận Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (xacNhan == DialogResult.Yes)
            {
                try
                {
                    KetNoiDuLieu db = new KetNoiDuLieu();
                    using (MySqlConnection conn = new MySqlConnection(db.LayChuoiKetNoi()))
                    {
                        conn.Open();
                        // Chỉ xóa dữ liệu bảng con, giữ lại bảng nguoidung
                        string qXoa = @"
                            DELETE FROM lichsuhoatdong WHERE MaNguoiDung = @uid;
                            DELETE FROM goidangky WHERE MaNguoiDung = @uid;
                            DELETE FROM goimau WHERE MaNguoiDung = @uid;";

                        using (MySqlCommand cmd = new MySqlCommand(qXoa, conn))
                        {
                            cmd.Parameters.AddWithValue("@uid", PhienDangNhap.MaNguoiDungHienTai);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Đã làm sạch toàn bộ dữ liệu!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex) { MessageBox.Show("Lỗi Reset: " + ex.Message); }
            }
        }

        private void tgDarkMode_CheckedChanged(object sender, EventArgs e)
        {
            bool isDark = tgDarkMode.Checked;
            PhienDangNhap.CheDoToi = isDark;

            foreach (Form frm in Application.OpenForms)
            {
                ThemeManager.ApDungGiaoDien(frm, isDark);
            }
        }
    }
}