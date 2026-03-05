using QuanLyDangKy.Models;
using QuanLyDangKy.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyDangKy.Models;

namespace QuanLyDangKy
{
    public partial class TrangChuForm : Form
    {
        public TrangChuForm()
        {
            InitializeComponent();
        }

        private void btnMoDangNhap_Click(object sender, EventArgs e)
        {
            // Gọi Form Đăng nhập dưới dạng Cửa sổ nổi (ShowDialog)
            DangNhapForm dangNhapPopup = new DangNhapForm();

            // Nếu cửa sổ trả về OK (Nghĩa là đăng nhập thành công)
            if (dangNhapPopup.ShowDialog() == DialogResult.OK)
            {
                // Ẩn nút đăng nhập đi
                btnMoDangNhap.Visible = false;

                MessageBox.Show($"Xin chào {PhienDangNhap.TenDangNhapHienTai}!", "Thành công");

                // Gọi hàm LoadData() ở đây để nạp dữ liệu gói đăng ký của user này vào DataGridView
                // (Sẽ hướng dẫn viết hàm LoadData() ở Giai đoạn 4)
            }
        }
    }
}
