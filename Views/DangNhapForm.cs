using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using QuanLyDangKy.Data;
using QuanLyDangKy.Models;

namespace QuanLyDangKy.Views
{
    public partial class DangNhapForm : Form
    {
        public DangNhapForm()
        {
            InitializeComponent();
            // Khởi động luôn hiện phần Đăng Nhập đè lên trên
            pnlDangNhap.BringToFront();
        }

        // --- HIỆU ỨNG CHUYỂN ĐỔI 2 PANEL ---
        private void lblChuyenDangKy_Click(object sender, EventArgs e)
        {
            pnlDangKy.BringToFront(); // Kéo panel Đăng Ký lên trên cùng
        }

        private void lblChuyenDangNhap_Click(object sender, EventArgs e)
        {
            pnlDangNhap.BringToFront(); // Kéo panel Đăng Nhập lên trên cùng
        }

        // --- LOGIC ĐĂNG KÝ TÀI KHOẢN ---
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRegUser.Text) || string.IsNullOrWhiteSpace(txtRegPass.Text))
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtRegPass.Text != txtRegConfirm.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!chkDieuKhoan.Checked)
            {
                MessageBox.Show("Bạn phải đồng ý với Điều khoản dịch vụ để tiếp tục!", "Bắt buộc", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                KetNoiDuLieu db = new KetNoiDuLieu();
                using (MySqlConnection conn = new MySqlConnection(db.LayChuoiKetNoi()))
                {
                    conn.Open();
                    // 1. Kiểm tra xem user đã tồn tại chưa
                    string checkQuery = "SELECT COUNT(*) FROM NguoiDung WHERE TenDangNhap = @user";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@user", txtRegUser.Text);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("Tên đăng nhập này đã có người sử dụng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // 2. Thêm tài khoản mới
                    string insertQuery = "INSERT INTO NguoiDung (TenDangNhap, MatKhau) VALUES (@user, @pass)";
                    using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@user", txtRegUser.Text);
                        insertCmd.Parameters.AddWithValue("@pass", txtRegPass.Text);
                        insertCmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Đăng ký thành công! Hãy đăng nhập.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pnlDangNhap.BringToFront(); // Chuyển về màn hình đăng nhập
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- LOGIC ĐĂNG NHẬP ---
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                KetNoiDuLieu db = new KetNoiDuLieu();
                using (MySqlConnection conn = new MySqlConnection(db.LayChuoiKetNoi()))
                {
                    string query = "SELECT MaNguoiDung, TenDangNhap FROM NguoiDung WHERE TenDangNhap = @user AND MatKhau = @pass";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", txtLogUser.Text);
                        cmd.Parameters.AddWithValue("@pass", txtLogPass.Text);

                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Lưu vào phiên (Session)
                                PhienDangNhap.MaNguoiDungHienTai = reader.GetInt32("MaNguoiDung");
                                PhienDangNhap.TenDangNhapHienTai = reader.GetString("TenDangNhap");

                                this.DialogResult = DialogResult.OK; // Báo hiệu đăng nhập thành công
                                this.Close(); // Đóng popup
                            }
                            else
                            {
                                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}