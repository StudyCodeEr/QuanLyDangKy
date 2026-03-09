using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using QuanLyDangKy.Data;
using QuanLyDangKy.Models;

namespace QuanLyDangKy.Views
{
    public partial class TrangChuForm : Form
    {
        private DateTime ngayBatDauLich;
        private DateTime ngayDuocChon;
        private ThongKeForm frmThongKe = null;

        public TrangChuForm()
        {
            InitializeComponent();

            // --- BẬT DOUBLE BUFFERING CHỐNG GIẬT CHO BẢNG LỊCH ---
            typeof(TableLayoutPanel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, tlpLich, new object[] { true });

            this.panel1.Resize += panel1_Resize;
        }

        // TỰ ĐỘNG CHIA 6 DÒNG - 7 CỘT KHI KÉO CỬA SỔ
        private void panel1_Resize(object sender, EventArgs e)
        {
            if (tlpLich != null && panel1.ClientSize.Height > 0 && panel1.ClientSize.Width > 0 && tlpLich.ColumnCount > 0)
            {
                // Chia chiều cao 6 dòng
                int soDongHienThi = 6;
                int chieuCaoMotDong = (panel1.ClientSize.Height - 60) / soDongHienThi;
                if (chieuCaoMotDong < 45) chieuCaoMotDong = 45;
                tlpLich.Height = 60 + (14 * chieuCaoMotDong);

                // Chia chiều rộng đúng 7 cột
                float chieuRongCot = (float)panel1.ClientSize.Width / 7f;
                if (chieuRongCot < 120f) chieuRongCot = 120f;

                for (int i = 0; i < tlpLich.ColumnCount; i++)
                {
                    tlpLich.ColumnStyles[i].Width = chieuRongCot;
                }
                tlpLich.Width = (int)(tlpLich.ColumnCount * chieuRongCot);
            }
        }

        private void TrangChuForm_Load(object sender, EventArgs e)
        {
            ngayDuocChon = DateTime.Now.Date;
            CapNhatGiaoDienDangNhap();
            lblHomNay.Text = "Hôm nay: " + DateTime.Now.ToString("dd/MM/yyyy");
            btnThemLich.BringToFront();
        }

        // ==========================================
        // VẼ KHUNG LỊCH 60 NGÀY LIÊN TỤC
        // ==========================================
        private void VeKhungGioLich()
        {
            tlpLich.Controls.Clear();
            tlpLich.ColumnStyles.Clear();
            tlpLich.RowStyles.Clear();

            int soNgayHienThi = 60; // Render 60 ngày để cuộn qua lại
            int soDongGoi = 14;

            tlpLich.ColumnCount = soNgayHienThi;
            tlpLich.RowCount = soDongGoi + 1;
            tlpLich.Dock = DockStyle.None;

            // Tính toán 7 Cột
            float chieuRongCot = (float)panel1.ClientSize.Width / 7f;
            if (chieuRongCot < 120f) chieuRongCot = 120f;
            tlpLich.Width = (int)(soNgayHienThi * chieuRongCot);

            // Tính toán 6 Dòng
            int chieuCaoManHinh = panel1.ClientSize.Height > 0 ? panel1.ClientSize.Height : 720;
            int chieuCaoDongBanDau = (chieuCaoManHinh - 60) / 6;
            if (chieuCaoDongBanDau < 45) chieuCaoDongBanDau = 45;
            tlpLich.Height = 60 + (soDongGoi * chieuCaoDongBanDau);

            // Gán thông số
            for (int i = 0; i < soNgayHienThi; i++)
                tlpLich.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, chieuRongCot));

            tlpLich.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            float chieuCaoPhanTram = 100f / soDongGoi;
            for (int i = 1; i <= soDongGoi; i++)
                tlpLich.RowStyles.Add(new RowStyle(SizeType.Percent, chieuCaoPhanTram));

            // Đổ Label Ngày
            for (int i = 0; i < soNgayHienThi; i++)
            {
                DateTime ngayHienTai = ngayBatDauLich.AddDays(i);
                Label lblNgay = new Label();
                lblNgay.Text = ngayHienTai.ToString("ddd\ndd/MM");
                lblNgay.AutoSize = false;
                lblNgay.TextAlign = ContentAlignment.MiddleCenter;
                lblNgay.Dock = DockStyle.Fill;
                lblNgay.Margin = new Padding(0);

                if (ngayHienTai.Date == DateTime.Now.Date)
                {
                    lblNgay.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    lblNgay.ForeColor = Color.White;
                    lblNgay.BackColor = Color.Crimson;
                }
                else if (ngayHienTai.Date == ngayDuocChon.Date)
                {
                    lblNgay.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    lblNgay.ForeColor = Color.White;
                    lblNgay.BackColor = Color.ForestGreen;
                }
                else
                {
                    lblNgay.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                    lblNgay.ForeColor = Color.DimGray;
                    lblNgay.BackColor = Color.Transparent;
                }

                tlpLich.Controls.Add(lblNgay, i, 0);
            }
        }

        // ==========================================
        // TẢI DỮ LIỆU ĐẸP & CHUẨN
        // ==========================================
        public void TaiDuLieuLenLich(DateTime ngayDich)
        {
            tlpLich.Visible = false;
            panel1.SuspendLayout();
            tlpLich.SuspendLayout();

            // Đặt ngày chọn làm tâm, thụt lùi 30 ngày để lấy đà cuộn
            ngayBatDauLich = ngayDich.Date.AddDays(-30);
            ngayDuocChon = ngayDich.Date;

            VeKhungGioLich();

            if (PhienDangNhap.MaNguoiDungHienTai != -1)
            {
                try
                {
                    List<string> theLoaiDuocChon = new List<string>();
                    if (chkLocGiaiTri.Checked) theLoaiDuocChon.Add("Giải trí");
                    if (chkLocCongViec.Checked) theLoaiDuocChon.Add("Công việc");
                    if (chkLocHocTap.Checked) theLoaiDuocChon.Add("Học tập");
                    if (chkLocTienIch.Checked) theLoaiDuocChon.Add("Tiện ích");
                    if (chkLocKhac.Checked) theLoaiDuocChon.Add("Khác");

                    KetNoiDuLieu db = new KetNoiDuLieu();
                    using (MySqlConnection conn = new MySqlConnection(db.LayChuoiKetNoi()))
                    {
                        // === ĐÃ SỬA: Bổ sung "MaGoi" vào SELECT ===
                        string query = "SELECT MaGoi, TenDichVu, TheLoai, NgayGiaHan, TrangThaiHoatDong, MauSac FROM GoiDangKy WHERE MaNguoiDung = @uid ORDER BY NgayGiaHan ASC";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@uid", PhienDangNhap.MaNguoiDungHienTai);
                            conn.Open();
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                Dictionary<DateTime, int> slotTheoNgay = new Dictionary<DateTime, int>();

                                while (reader.Read())
                                {
                                    // === ĐÃ SỬA: Đọc "MaGoi" từ Database ===
                                    int maGoi = reader.GetInt32("MaGoi");
                                    string ten = reader.GetString("TenDichVu");
                                    string loai = reader.GetString("TheLoai");
                                    DateTime han = reader.GetDateTime("NgayGiaHan").Date;
                                    bool active = reader.GetBoolean("TrangThaiHoatDong");
                                    string maMau = reader.GetString("MauSac");

                                    // Lọc thể loại
                                    if (theLoaiDuocChon.Count > 0 && !theLoaiDuocChon.Contains(loai))
                                        continue;

                                    int col = (int)(han - ngayBatDauLich).TotalDays;

                                    // Chỉ đổ những gói rơi vào mảng 60 ngày đang hiển thị
                                    if (col >= 0 && col < 60)
                                    {
                                        if (!slotTheoNgay.ContainsKey(han)) slotTheoNgay[han] = 1;
                                        else slotTheoNgay[han]++;

                                        int row = slotTheoNgay[han];

                                        if (row <= 14)
                                        {
                                            Guna.UI2.WinForms.Guna2Button btnGoi = new Guna.UI2.WinForms.Guna2Button();
                                            btnGoi.Text = ten;

                                            // === ĐÃ SỬA: Gắn sự kiện và ID cho nút ===
                                            btnGoi.Tag = maGoi;
                                            btnGoi.Click += btnGoi_Click;
                                            // =========================================

                                            btnGoi.Dock = DockStyle.Fill;
                                            btnGoi.BorderRadius = 5;
                                            btnGoi.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                                            btnGoi.TextAlign = HorizontalAlignment.Left;
                                            btnGoi.Margin = new Padding(3);

                                            if (!active)
                                            {
                                                btnGoi.FillColor = Color.LightGray;
                                                btnGoi.ForeColor = Color.DimGray;
                                                btnGoi.Text = "[Đã Hủy]\n" + ten;
                                            }
                                            else
                                            {
                                                try { btnGoi.FillColor = ColorTranslator.FromHtml(maMau); }
                                                catch { btnGoi.FillColor = Color.FromArgb(52, 168, 83); }
                                            }

                                            tlpLich.Controls.Add(btnGoi, col, row);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show("Lỗi tải lịch: " + ex.Message); }
            }

            // Tự động cuộn sao cho Ngày đang chọn (Cột số 30) nằm ngay giữa màn hình
            float chieuRongCotDinam = (float)panel1.ClientSize.Width / 7f;
            if (chieuRongCotDinam < 120f) chieuRongCotDinam = 120f;

            // Lùi lại 3 cột để ngày số 30 nằm ở giữa 7 cột
            int toaDoX = (int)((30 - 3) * chieuRongCotDinam);
            if (toaDoX < 0) toaDoX = 0;

            panel1.AutoScrollPosition = new Point(0, 0);
            tlpLich.ResumeLayout(true);
            panel1.ResumeLayout(true);
            tlpLich.Visible = true;

            this.BeginInvoke((MethodInvoker)delegate
            {
                panel1.AutoScrollPosition = new Point(toaDoX, 0);
            });
        }

        // ==========================================
        // LOGIC ĐĂNG NHẬP & SỰ KIỆN NÚT BẤM (GIỮ NGUYÊN)
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
            }
            else
            {
                btnMoDangNhap.Size = new Size(45, 45);
                btnMoDangNhap.BorderRadius = 22;
                btnMoDangNhap.Text = "";

                try
                {
                    string avatarPath = System.IO.Path.Combine(Application.StartupPath, "Icon", "avatar_default.png");
                    btnMoDangNhap.Image = Image.FromFile(avatarPath);
                    btnMoDangNhap.ImageAlign = HorizontalAlignment.Center;
                    btnMoDangNhap.ImageSize = new Size(45, 45);
                }
                catch { }
                btnMoDangNhap.ContextMenuStrip = menuTaiKhoan;
            }

            TaiDuLieuLenLich(DateTime.Now);
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
            else menuTaiKhoan.Show(btnMoDangNhap, new Point(0, btnMoDangNhap.Height));
        }

        private void menuDangXuat_Click(object sender, EventArgs e)
        {
            PhienDangNhap.MaNguoiDungHienTai = -1;
            PhienDangNhap.TenDangNhapHienTai = "";
            CapNhatGiaoDienDangNhap();
            lblHomNay.Text = "Hôm nay: " + DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void btnToggleBoLoc_Click(object sender, EventArgs e)
        {
            pnlDanhSachBoLoc.Visible = !pnlDanhSachBoLoc.Visible;
            btnToggleBoLoc.Text = pnlDanhSachBoLoc.Visible ? "▼ Lọc Theo Thể Loại" : "▶ Lọc Theo Thể Loại";
        }

        private void BoLoc_CheckedChanged(object sender, EventArgs e)
        {
            TaiDuLieuLenLich(ngayDuocChon != DateTime.MinValue ? ngayDuocChon : DateTime.Now);
        }

        private void calMini_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime ngayChon = calMini.SelectionRange.Start;
            lblHomNay.Text = "Đang xem: " + ngayChon.ToString("dd/MM/yyyy");
            TaiDuLieuLenLich(ngayChon);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (PhienDangNhap.MaNguoiDungHienTai == -1)
            {
                MessageBox.Show("Bạn cần đăng nhập để xem thống kê!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tính năng Toggle (Bật/Tắt): Đóng form thống kê và quay lại trang chủ
            if (frmThongKe != null && !frmThongKe.IsDisposed)
            {
                frmThongKe.Close();
                frmThongKe = null;

                // 1. HIỆN LẠI PANEL
                panel1.Visible = true;
                pnlSidebar.Visible = true;

                // 2. KHẮC PHỤC LỖI SIDEBAR CHE TOPBAR (Sắp xếp lại Z-Order)
                // Trong WinForms, SendToBack() giúp Control lấy không gian Docking ĐẦU TIÊN
                pnlTop.SendToBack();       // TopBar chiếm toàn bộ chiều ngang trên cùng trước
                pnlSidebar.BringToFront(); // Sau đó Sidebar mới được chiếm lề trái
                panel1.BringToFront();     // Cuối cùng Lịch lấp đầy phần còn lại

                // 3. KHẮC PHỤC LỖI TỤT DÒNG NGÀY: Vẽ lại lịch để TableLayoutPanel tính lại phần trăm
                TaiDuLieuLenLich(ngayDuocChon != DateTime.MinValue ? ngayDuocChon : DateTime.Now);

                return;
            }

            // ẨN LỊCH VÀ SIDEBAR ĐỂ NHƯỜNG KHÔNG GIAN CHO THỐNG KÊ
            panel1.Visible = false;
            pnlSidebar.Visible = false;

            // Khởi tạo Form Thống Kê
            frmThongKe = new ThongKeForm();
            frmThongKe.TopLevel = false;
            frmThongKe.FormBorderStyle = FormBorderStyle.None;
            frmThongKe.Dock = DockStyle.Fill;

            this.Controls.Add(frmThongKe);

            // Đảm bảo Form Thống kê hiển thị đúng chỗ
            frmThongKe.BringToFront();

            // Đảm bảo thanh TopBar luôn nổi lên trên cùng (Che lên cả Form Thống kê)
            pnlTop.BringToFront();

            frmThongKe.Show();
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
                MessageBox.Show("Bạn cần đăng nhập để thêm gói mới!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (ThemGoiForm frm = new ThemGoiForm())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    TaiDuLieuLenLich(ngayDuocChon != DateTime.MinValue ? ngayDuocChon : DateTime.Now);
                }
            }
        }

        // ==========================================
        // 7. GỌI FORM SỬA THÔNG TIN CÁ NHÂN
        // ==========================================
        private void menuSuaThongTin_Click(object sender, EventArgs e)
        {
            if (PhienDangNhap.MaNguoiDungHienTai == -1)
            {
                MessageBox.Show("Bạn cần đăng nhập để xem thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (ThongTinCaNhanForm frm = new ThongTinCaNhanForm())
            {
                DialogResult ketQua = frm.ShowDialog();

                if (ketQua == DialogResult.OK)
                {
                    CapNhatGiaoDienDangNhap();
                }
                else if (ketQua == DialogResult.Abort)
                {
                    menuDangXuat_Click(null, null);
                }
            }
        }

        // ==========================================
        // === ĐÃ SỬA: HÀM SỰ KIỆN KHI CLICK VÀO GÓI ===
        // ==========================================
        private void btnGoi_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button btn = sender as Guna.UI2.WinForms.Guna2Button;
            if (btn != null && btn.Tag != null)
            {
                int maGoiDuocChon = (int)btn.Tag;

                using (ChiTietGoiForm frm = new ChiTietGoiForm(maGoiDuocChon))
                {
                    // Chờ người dùng đóng form chi tiết, nếu họ có thay đổi thì load lại bảng
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        TaiDuLieuLenLich(ngayDuocChon != DateTime.MinValue ? ngayDuocChon : DateTime.Now);
                    }
                }
            }
        }
    }
}