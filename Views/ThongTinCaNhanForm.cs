using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using QuanLyDangKy.Data;
using QuanLyDangKy.Models;

namespace QuanLyDangKy.Views
{
    public partial class ThongTinCaNhanForm : Form
    {
        // Biến lưu đường dẫn file ảnh
        private string duongDanAnhHienTai = "";

        public ThongTinCaNhanForm()
        {
            InitializeComponent();
        }

        // ==========================================
        // 1. KHI FORM VỪA MỞ LÊN -> TẢI DỮ LIỆU CŨ VÀO Ô
        // ==========================================
        private void ThongTinCaNhanForm_Load(object sender, EventArgs e)
        {
            try
            {
                KetNoiDuLieu db = new KetNoiDuLieu();
                using (MySqlConnection conn = new MySqlConnection(db.LayChuoiKetNoi()))
                {
                    // Đã bổ sung thêm cột NamSinh vào câu lệnh SQL
                    string query = "SELECT HoTen, NamSinh, SoDienThoai, Email, AvatarPath FROM NguoiDung WHERE MaNguoiDung = @uid";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@uid", PhienDangNhap.MaNguoiDungHienTai);
                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtHoTen.Text = reader["HoTen"].ToString();
                                txtNamSinh.Text = reader["NamSinh"].ToString();
                                txtSoDienThoai.Text = reader["SoDienThoai"].ToString();
                                txtEmail.Text = reader["Email"].ToString();

                                duongDanAnhHienTai = reader["AvatarPath"].ToString();

                                // Nếu có ảnh trong DB và file ảnh thực sự tồn tại trên máy tính
                                if (!string.IsNullOrEmpty(duongDanAnhHienTai) && File.Exists(duongDanAnhHienTai))
                                {
                                    // Chèn ảnh vào nút Guna2CircleButton
                                    picAvatar.Image = Image.FromFile(duongDanAnhHienTai);
                                    // BẮT BUỘC: Ép ảnh giãn ra bằng đúng kích thước của cái nút tròn
                                    picAvatar.ImageSize = new Size(picAvatar.Width, picAvatar.Height);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chưa có dữ liệu cũ hoặc lỗi tải: " + ex.Message, "Thông báo");
            }
        }

        // ==========================================
        // 2. CÁC HÀM SỰ KIỆN NÚT BẤM
        // ==========================================

        private void btnDoiAnh_Click(object sender, EventArgs e)
        {
            ThucHienDoiAnh(); // Gọi khối lệnh đổi ảnh
        }

        private void btnDoiAnh_Click_1(object sender, EventArgs e)
        {
            ThucHienDoiAnh(); // Cho dù giao diện gọi hàm này thì vẫn chạy đổi ảnh bình thường!
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ThucHienLuuThongTin();
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            ThucHienLuuThongTin(); // Cho dù giao diện gọi hàm này thì vẫn lưu bình thường!
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close(); // Đây chính là nút Đóng của bạn
        }

        private void btnXoaTaiKhoan_Click(object sender, EventArgs e)
        {
            DialogResult hoiNguoiDung = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản? Hành động này không thể hoàn tác.", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (hoiNguoiDung == DialogResult.Yes)
            {
                try
                {
                    KetNoiDuLieu db = new KetNoiDuLieu();
                    using (MySqlConnection conn = new MySqlConnection(db.LayChuoiKetNoi()))
                    {
                        string query = "DELETE FROM NguoiDung WHERE MaNguoiDung = @uid";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@uid", PhienDangNhap.MaNguoiDungHienTai);
                            conn.Open();
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Đã xóa tài khoản.", "Thông báo");
                            this.DialogResult = DialogResult.Abort; // Báo hiệu đã xóa
                            this.Close();
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show("Lỗi xóa: " + ex.Message); }
            }
        }

        // ==========================================
        // 3. KHỐI LỆNH XỬ LÝ CHÍNH
        // ==========================================
        private void ThucHienDoiAnh()
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Image Files(*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";
                    ofd.Title = "Chọn ảnh đại diện của bạn";

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        duongDanAnhHienTai = ofd.FileName;
                        picAvatar.Image = Image.FromFile(duongDanAnhHienTai);

                        // BẮT BUỘC: Ép ảnh giãn ra bằng đúng kích thước của cái nút tròn
                        picAvatar.ImageSize = new Size(picAvatar.Width, picAvatar.Height);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải ảnh lên: " + ex.Message, "Lỗi");
            }
        }

        private void ThucHienLuuThongTin()
        {
            try
            {
                KetNoiDuLieu db = new KetNoiDuLieu();
                using (MySqlConnection conn = new MySqlConnection(db.LayChuoiKetNoi()))
                {
                    string query = "UPDATE NguoiDung SET HoTen = @hoten, NamSinh = @namsinh, SoDienThoai = @sdt, Email = @email, AvatarPath = @avatar WHERE MaNguoiDung = @uid";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@hoten", txtHoTen.Text.Trim());
                        cmd.Parameters.AddWithValue("@namsinh", txtNamSinh.Text.Trim());
                        cmd.Parameters.AddWithValue("@sdt", txtSoDienThoai.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@avatar", duongDanAnhHienTai);
                        cmd.Parameters.AddWithValue("@uid", PhienDangNhap.MaNguoiDungHienTai);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Cập nhật thông tin thành công!", "Tuyệt vời", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK; // Báo hiệu lưu thành công
                        this.Close(); // Lưu xong tự đóng Form
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu dữ liệu: " + ex.Message, "Lỗi Database");
            }
        }
    }
}