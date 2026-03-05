using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using QuanLyDangKy.Data;
using QuanLyDangKy.Models;

namespace QuanLyDangKy.Views
{
    public partial class TrangChuForm : Form
    {
        // Khai báo biến toàn cục lưu mốc thời gian của Lưới
        private DateTime ngayBatDauLich;

        public TrangChuForm()
        {
            InitializeComponent();
        }

        // ==========================================
        // 1. SỰ KIỆN KHI TẢI FORM
        // ==========================================
        private void TrangChuForm_Load(object sender, EventArgs e)
        {
            VeKhungGioLich();
            CapNhatGiaoDienDangNhap();
            lblHomNay.Text = "Hôm nay: " + DateTime.Now.ToString("dd/MM/yyyy");
            btnThemLich.BringToFront();
        }

        // ==========================================
        // VẼ LƯỚI THỜI GIAN (ĐÃ CẬP NHẬT CỬA SỔ TRƯỢT)
        // ==========================================
        private void VeKhungGioLich()
        {
            // Khởi tạo mốc thời gian mặc định nếu chưa có (lúc mới mở Form)
            if (ngayBatDauLich == DateTime.MinValue)
            {
                ngayBatDauLich = DateTime.Now.Date.AddDays(-30);
            }

            // BẮT BUỘC: Nín thở UI và reset thanh cuộn về 0 để chống kẹt
            panel1.SuspendLayout();
            tlpLich.SuspendLayout();
            panel1.AutoScrollPosition = new Point(0, 0);

            tlpLich.Controls.Clear();
            tlpLich.ColumnStyles.Clear();
            tlpLich.RowStyles.Clear();

            // Luôn chỉ giữ 60 ngày trên RAM cho nhẹ máy
            int soNgayHienThi = 60;

            tlpLich.ColumnCount = soNgayHienThi + 1;
            tlpLich.RowCount = 25;

            // Cởi trói thanh cuộn (Chống giật khung hình)
            tlpLich.Dock = DockStyle.None;
            // KHÔNG ĐƯỢC GÁN tlpLich.Location Ở ĐÂY NỮA

            tlpLich.Width = 60 + (soNgayHienThi * 150);
            tlpLich.Height = 50 + (24 * 50);

            // Vẽ Cột
            tlpLich.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            for (int i = 1; i <= soNgayHienThi; i++)
                tlpLich.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));

            // Vẽ Hàng
            tlpLich.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            for (int i = 1; i <= 24; i++)
                tlpLich.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));

            // Đổ text 24 Giờ
            for (int i = 0; i < 24; i++)
            {
                Label lblGio = new Label();
                lblGio.Text = i == 0 ? "12 AM" : (i < 12 ? $"{i} AM" : (i == 12 ? "12 PM" : $"{i - 12} PM"));
                lblGio.AutoSize = false;
                lblGio.TextAlign = ContentAlignment.TopRight;
                lblGio.Dock = DockStyle.Fill;
                lblGio.ForeColor = Color.Gray;
                lblGio.Font = new Font("Segoe UI", 8);

                tlpLich.Controls.Add(lblGio, 0, i + 1);
            }

            // Đổ text 60 Ngày
            for (int i = 1; i <= soNgayHienThi; i++)
            {
                DateTime ngayHienTai = ngayBatDauLich.AddDays(i - 1);
                Label lblNgay = new Label();

                lblNgay.Text = ngayHienTai.ToString("ddd\ndd/MM");
                lblNgay.AutoSize = false;
                lblNgay.TextAlign = ContentAlignment.MiddleCenter;
                lblNgay.Dock = DockStyle.Fill;

                if (ngayHienTai.Date == DateTime.Now.Date)
                {
                    lblNgay.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    lblNgay.ForeColor = Color.FromArgb(12, 97, 242);
                }
                else
                {
                    lblNgay.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                    lblNgay.ForeColor = Color.DimGray;
                }

                tlpLich.Controls.Add(lblNgay, i, 0);
            }

            // XONG XUÔI THÌ CHO PHÉP VẼ LẠI
            tlpLich.ResumeLayout();
            panel1.ResumeLayout();
        }

        // ==========================================
        // THUẬT TOÁN CUỘN ĐẾN NGÀY CHỈ ĐỊNH
        // ==========================================
        private void CuonDenNgay(DateTime ngayDich)
        {
            if (panel1 == null || tlpLich == null) return;

            // Tính số ngày chênh lệch để tìm tọa độ cột
            int soNgay = (int)(ngayDich.Date - ngayBatDauLich.Date).TotalDays;
            if (soNgay < 0) soNgay = 0;
            if (soNgay > 60) soNgay = 60;

            int toaDoX = 60 + (soNgay * 150);

            // Dùng BeginInvoke để xếp hàng lệnh cuộn về cuối cùng, chờ giao diện load xong
            this.BeginInvoke((MethodInvoker)delegate
            {
                panel1.AutoScrollPosition = new Point(toaDoX, 0);
            });
        }

        // ==========================================
        // 4. LOGIC ĐĂNG NHẬP VÀ UI TOPBAR
        // ==========================================
        private void CapNhatGiaoDienDangNhap()
        {
            if (PhienDangNhap.MaNguoiDungHienTai == -1)
            {
                btnMoDangNhap.Size = new Size(130, 40);
                btnMoDangNhap.BorderRadius = 15;
                btnMoDangNhap.Text = "ĐĂNG NHẬP";
                btnMoDangNhap.Image = null;
                btnMoDangNhap.ContextMenuStrip = null;

                tlpLich.Controls.Clear();
                VeKhungGioLich();
            }
            else
            {
                btnMoDangNhap.Size = new Size(45, 45);
                btnMoDangNhap.BorderRadius = 22;
                btnMoDangNhap.Text = "";

                try
                {
                    // Dùng Application.StartupPath để lấy thư mục gốc đang chạy file .exe
                    // Sau đó nối với thư mục "Icon" và tên file ảnh
                    string avatarPath = System.IO.Path.Combine(Application.StartupPath, "Icon", "avatar_default.png");

                    btnMoDangNhap.Image = Image.FromFile(avatarPath);
                    btnMoDangNhap.ImageAlign = HorizontalAlignment.Center;
                    btnMoDangNhap.ImageSize = new Size(45, 45);
                }
                catch (Exception ex)
                {
                    // Tạm thời in ra lỗi nếu không tìm thấy ảnh để dễ debug
                    Console.WriteLine("Lỗi load Avatar: " + ex.Message);
                }

                btnMoDangNhap.ContextMenuStrip = menuTaiKhoan;
                TaiDuLieuLenLich();

                // Trượt lề về ngày Hôm nay
                ThayDoiMocThoiGian(DateTime.Now);
            }
        }
        // ==========================================
        // SIÊU HÀM: DỊCH CHUYỂN CỬA SỔ THỜI GIAN
        // ==========================================
        private void ThayDoiMocThoiGian(DateTime ngayDich)
        {
            // 1. Dời mốc bắt đầu lịch sang 30 ngày trước của ngày bạn vừa chọn
            ngayBatDauLich = ngayDich.Date.AddDays(-30);

            // 2. Gọi hàm vẽ lại toàn bộ lưới và tải dữ liệu gói đăng ký
            // (Nó sẽ tự động chỉ lấy các gói rơi vào 60 ngày của vùng không gian mới)
            TaiDuLieuLenLich();

            // 3. Cuộn thanh trượt ngang về đúng ngày bạn chọn
            CuonDenNgay(ngayDich);
        }
        private void btnMoDangNhap_Click(object sender, EventArgs e)
        {
            if (PhienDangNhap.MaNguoiDungHienTai == -1)
            {
                DangNhapForm frm = new DangNhapForm();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CapNhatGiaoDienDangNhap();
                    lblHomNay.Text = $"Xin chào, {PhienDangNhap.TenDangNhapHienTai}!";
                }
            }
            else
            {
                menuTaiKhoan.Show(btnMoDangNhap, new Point(0, btnMoDangNhap.Height));
            }
        }

        private void menuDangXuat_Click(object sender, EventArgs e)
        {
            PhienDangNhap.MaNguoiDungHienTai = -1;
            PhienDangNhap.TenDangNhapHienTai = "";
            CapNhatGiaoDienDangNhap();
            lblHomNay.Text = "Hôm nay: " + DateTime.Now.ToString("dd/MM/yyyy");
        }

        // ==========================================
        // 5. CÁC SỰ KIỆN SIDEBAR VÀ TOPBAR
        // ==========================================
        private void btnToggleBoLoc_Click(object sender, EventArgs e)
        {
            pnlDanhSachBoLoc.Visible = !pnlDanhSachBoLoc.Visible;
            btnToggleBoLoc.Text = pnlDanhSachBoLoc.Visible ? "▼ Lọc Theo Thể Loại" : "▶ Lọc Theo Thể Loại";
        }

        private void calMini_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime ngayChon = calMini.SelectionRange.Start;
            lblHomNay.Text = "Đang xem: " + ngayChon.ToString("dd/MM/yyyy");

            // Ép bảng lịch to lướt theo đến đúng ngày vừa click!
            ThayDoiMocThoiGian(ngayChon);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (PhienDangNhap.MaNguoiDungHienTai == -1) return;
            try
            {
                KetNoiDuLieu db = new KetNoiDuLieu();
                decimal tongChiPhi = 0;
                decimal chiPhiRac = 0;

                using (MySqlConnection conn = new MySqlConnection(db.LayChuoiKetNoi()))
                {
                    string query = "SELECT GiaGoc, TrangThaiHoatDong FROM GoiDangKy WHERE MaNguoiDung = @uid";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@uid", PhienDangNhap.MaNguoiDungHienTai);
                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                decimal gia = reader.GetDecimal("GiaGoc");
                                bool dangHoatDong = reader.GetBoolean("TrangThaiHoatDong");
                                tongChiPhi += gia;
                                if (!dangHoatDong) chiPhiRac += gia;
                            }
                        }
                    }
                }
                MessageBox.Show($"Tổng chi tiêu: {tongChiPhi:N0} VNĐ\nChi phí rác (Đã ngưng): {chiPhiRac:N0} VNĐ", "Thống Kê");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void btnCaiDat_Click(object sender, EventArgs e)
        {
            if (PhienDangNhap.MaNguoiDungHienTai == -1)
            {
                MessageBox.Show("Vui lòng đăng nhập để truy cập Cài đặt hệ thống!", "Khóa truy cập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Chức năng Cài đặt đang được phát triển.", "Cài đặt", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnThemLich_Click(object sender, EventArgs e)
        {
            if (PhienDangNhap.MaNguoiDungHienTai == -1)
            {
                MessageBox.Show("Bạn cần đăng nhập để thêm gói mới!", "Nhắc nhở");
                return;
            }

            // Mở comment này ra khi bạn tạo xong ThemGoiForm nhé!
            /*
            using (ThemGoiForm frm = new ThemGoiForm())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    TaiDuLieuLenLich();
                    CuonDenNgay(DateTime.Now);
                }
            }
            */
            MessageBox.Show("Sẵn sàng liên kết với ThemGoiForm!");
        }

        // ==========================================
        // 6. TẢI DỮ LIỆU TỪ DATABASE VÀ VẼ KHỐI MÀU
        // ==========================================
        public void TaiDuLieuLenLich()
        {
            VeKhungGioLich();
            try
            {
                KetNoiDuLieu db = new KetNoiDuLieu();
                using (MySqlConnection conn = new MySqlConnection(db.LayChuoiKetNoi()))
                {
                    string query = "SELECT TenDichVu, TheLoai, NgayGiaHan, TrangThaiHoatDong FROM GoiDangKy WHERE MaNguoiDung = @uid";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@uid", PhienDangNhap.MaNguoiDungHienTai);
                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string ten = reader.GetString("TenDichVu");
                                string loai = reader.GetString("TheLoai");
                                DateTime han = reader.GetDateTime("NgayGiaHan");
                                bool active = reader.GetBoolean("TrangThaiHoatDong");

                                // Tính tọa độ Cột (Số ngày lệch so với mốc bắt đầu)
                                int col = (int)(han.Date - ngayBatDauLich.Date).TotalDays + 1;

                                // Nội suy hàng (Giờ giả lập từ 8am - 8pm)
                                int row = (ten.Length % 12) + 8 + 1;

                                // Chỉ vẽ nếu ngày gia hạn nằm trong vùng lưới 60 ngày
                                if (col >= 1 && col <= 60)
                                {
                                    Guna.UI2.WinForms.Guna2Button btnGoi = new Guna.UI2.WinForms.Guna2Button();
                                    btnGoi.Text = ten;
                                    btnGoi.Dock = DockStyle.Fill;
                                    btnGoi.BorderRadius = 5;
                                    btnGoi.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                                    btnGoi.TextAlign = HorizontalAlignment.Left;
                                    btnGoi.Margin = new Padding(3);

                                    if (!active)
                                    {
                                        btnGoi.FillColor = Color.LightGray;
                                        btnGoi.ForeColor = Color.DimGray;
                                        btnGoi.Text = "[Hủy]\n" + ten;
                                    }
                                    else
                                    {
                                        switch (loai)
                                        {
                                            case "Giải trí": btnGoi.FillColor = Color.FromArgb(234, 67, 53); break;
                                            case "Công việc": btnGoi.FillColor = Color.FromArgb(66, 133, 244); break;
                                            case "Học tập": btnGoi.FillColor = Color.FromArgb(251, 188, 5); break;
                                            default: btnGoi.FillColor = Color.FromArgb(52, 168, 83); break;
                                        }
                                    }

                                    // Thêm khối màu vào lưới
                                    tlpLich.Controls.Add(btnGoi, col, row);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải lịch: " + ex.Message); }
        }
    }
}