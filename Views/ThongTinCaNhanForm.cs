using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using QuanLyDangKy.Data;
using QuanLyDangKy.Models;
using System.Drawing.Drawing2D; // Thư viện để vẽ đồ họa hình tròn
using System.Drawing.Imaging;

namespace QuanLyDangKy.Views
{
    public partial class ThongTinCaNhanForm : Form
    {
        private string duongDanAnhMoi = "";
        private string tenFileAvatarHienTai = "";

        public ThongTinCaNhanForm()
        {
            InitializeComponent();
        }

        // ===============================================
        // THUẬT TOÁN ÉP ẢNH THÀNH HÌNH TRÒN
        // ===============================================
        private Image TaoAnhTron(Image anhGoc)
        {
            // Lấy cạnh ngắn nhất để tạo hình vuông
            int minSize = Math.Min(anhGoc.Width, anhGoc.Height);

            // Tính tọa độ để cắt chính giữa ảnh
            int x = (anhGoc.Width - minSize) / 2;
            int y = (anhGoc.Height - minSize) / 2;

            // Tạo Bitmap mới hình vuông, nền trong suốt
            Bitmap anhTron = new Bitmap(minSize, minSize);
            anhTron.MakeTransparent();

            using (Graphics g = Graphics.FromImage(anhTron))
            {
                // Bật chế độ khử răng cưa để viền tròn được mượt
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                // Dùng TextureBrush để "sơn" ảnh gốc vào hình tròn
                using (TextureBrush brush = new TextureBrush(anhGoc))
                {
                    // Dịch chuyển chổi quét đến giữa ảnh gốc
                    brush.TranslateTransform(-x, -y);

                    // Vẽ một hình tròn lấp đầy bằng brush
                    g.FillEllipse(brush, 0, 0, minSize, minSize);
                }
            }
            return anhTron;
        }

        // ===============================================
        // 1. TẢI DỮ LIỆU KHI MỞ FORM
        // ===============================================
        private void ThongTinCaNhanForm_Load(object sender, EventArgs e)
        {
            try
            {
                KetNoiDuLieu db = new KetNoiDuLieu();
                using (MySqlConnection conn = new MySqlConnection(db.LayChuoiKetNoi()))
                {
                    string query = "SELECT TenDangNhap, Avatar FROM nguoidung WHERE MaNguoiDung = @uid";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@uid", PhienDangNhap.MaNguoiDungHienTai);
                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtTenDangNhap.Text = reader.GetString("TenDangNhap");

                                tenFileAvatarHienTai = reader.IsDBNull(reader.GetOrdinal("Avatar")) ? "" : reader.GetString("Avatar");
                                LoadAnhAvatar(tenFileAvatarHienTai);
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải thông tin: " + ex.Message); }
        }

        // Đọc ảnh an toàn và ÉP LUÔN THÀNH TRÒN 
        // Đọc ảnh an toàn tuyệt đối bằng MemoryStream
        private void LoadAnhAvatar(string tenFile)
        {
            string thuMucAvatar = Path.Combine(Application.StartupPath, "Avatars");
            string duongDanDayDu = Path.Combine(thuMucAvatar, tenFile);

            try
            {
                if (!string.IsNullOrEmpty(tenFile) && File.Exists(duongDanDayDu))
                {
                    // Đọc file thành mảng byte rồi ném vào RAM
                    byte[] imageBytes = File.ReadAllBytes(duongDanDayDu);
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        using (Image tempImg = Image.FromStream(ms))
                        {
                            picAvatar.Image = TaoAnhTron(tempImg);
                        }
                    }
                }
                else
                {
                    string defaultPath = Path.Combine(Application.StartupPath, "Icon", "avatar_default.png");
                    if (File.Exists(defaultPath))
                    {
                        byte[] imageBytes = File.ReadAllBytes(defaultPath);
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            using (Image tempImg = Image.FromStream(ms))
                            {
                                picAvatar.Image = TaoAnhTron(tempImg);
                            }
                        }
                    }
                }
            }
            catch { /* Lỗi thì bỏ qua, để khung trống */ }
        }

        // ===============================================
        // 2. CHỌN ẢNH TỪ MÁY TÍNH
        // ===============================================
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh đại diện";
                ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        duongDanAnhMoi = ofd.FileName;

                        // Đọc file vừa chọn thành mảng byte
                        byte[] imageBytes = File.ReadAllBytes(duongDanAnhMoi);
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            using (Image tempImg = Image.FromStream(ms))
                            {
                                picAvatar.Image = TaoAnhTron(tempImg);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("File ảnh bị lỗi hoặc không đúng định dạng: " + ex.Message, "Lỗi đọc ảnh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ===============================================
        // 3. XỬ LÝ LƯU (ĐỔI TÊN, MK, LƯU ẢNH TRÒN)
        // ===============================================
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string tenMoi = txtTenDangNhap.Text.Trim();
            string mkCu = txtMatKhauCu.Text;
            string mkMoi = txtMatKhauMoi.Text;
            string mkXacNhan = txtXacNhanMatKhau.Text;

            if (string.IsNullOrEmpty(tenMoi))
            {
                MessageBox.Show("Tên đăng nhập không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                KetNoiDuLieu db = new KetNoiDuLieu();
                using (MySqlConnection conn = new MySqlConnection(db.LayChuoiKetNoi()))
                {
                    conn.Open();
                    string matKhauUpdate = "";

                    // Nếu muốn đổi mật khẩu
                    if (!string.IsNullOrEmpty(mkMoi) || !string.IsNullOrEmpty(mkCu))
                    {
                        if (mkMoi != mkXacNhan)
                        {
                            MessageBox.Show("Mật khẩu xác nhận không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Check MK cũ
                        string qCheck = "SELECT MatKhau FROM nguoidung WHERE MaNguoiDung = @uid";
                        using (MySqlCommand cmdCheck = new MySqlCommand(qCheck, conn))
                        {
                            cmdCheck.Parameters.AddWithValue("@uid", PhienDangNhap.MaNguoiDungHienTai);
                            string mkThucTe = cmdCheck.ExecuteScalar()?.ToString();

                            if (mkCu != mkThucTe)
                            {
                                MessageBox.Show("Mật khẩu hiện tại không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        matKhauUpdate = mkMoi;
                    }

                    // XỬ LÝ LƯU ẢNH ĐÃ CẮT TRÒN (Save PNG)
                    string tenFileLuuDB = tenFileAvatarHienTai;
                    if (!string.IsNullOrEmpty(duongDanAnhMoi) && picAvatar.Image != null)
                    {
                        string thuMucAvatar = Path.Combine(Application.StartupPath, "Avatars");
                        if (!Directory.Exists(thuMucAvatar)) Directory.CreateDirectory(thuMucAvatar);

                        // Bắt buộc lưu đuôi .png để giữ nền trong suốt của 4 góc bị cắt
                        tenFileLuuDB = $"user_{PhienDangNhap.MaNguoiDungHienTai}_{DateTime.Now.Ticks}.png";
                        string duongDanDich = Path.Combine(thuMucAvatar, tenFileLuuDB);

                        // Lưu ảnh tròn thay vì copy ảnh chữ nhật cũ
                        picAvatar.Image.Save(duongDanDich, ImageFormat.Png);
                    }

                    // Cập nhật DB
                    string qUpdate = "UPDATE nguoidung SET TenDangNhap = @ten, Avatar = @avatar";
                    if (!string.IsNullOrEmpty(matKhauUpdate)) qUpdate += ", MatKhau = @mk";
                    qUpdate += " WHERE MaNguoiDung = @uid";

                    using (MySqlCommand cmdUp = new MySqlCommand(qUpdate, conn))
                    {
                        cmdUp.Parameters.AddWithValue("@ten", tenMoi);
                        cmdUp.Parameters.AddWithValue("@avatar", tenFileLuuDB);
                        cmdUp.Parameters.AddWithValue("@uid", PhienDangNhap.MaNguoiDungHienTai);
                        if (!string.IsNullOrEmpty(matKhauUpdate)) cmdUp.Parameters.AddWithValue("@mk", matKhauUpdate);

                        cmdUp.ExecuteNonQuery();
                    }

                    PhienDangNhap.TenDangNhapHienTai = tenMoi;
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi cập nhật: " + ex.Message); }
        }

        // ===============================================
        // 4. XÓA TÀI KHOẢN
        // ===============================================
        private void btnXoaTaiKhoan_Click(object sender, EventArgs e)
        {
            DialogResult xacNhan = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa VĨNH VIỄN tài khoản này?\nToàn bộ dữ liệu gói cước, lịch sử sẽ bị xóa sạch!",
                "CẢNH BÁO ĐỎ", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

            if (xacNhan == DialogResult.Yes)
            {
                try
                {
                    KetNoiDuLieu db = new KetNoiDuLieu();
                    using (MySqlConnection conn = new MySqlConnection(db.LayChuoiKetNoi()))
                    {
                        conn.Open();
                        string qXoa = @"
                            DELETE FROM lichsuhoatdong WHERE MaNguoiDung = @uid;
                            DELETE FROM goimau WHERE MaNguoiDung = @uid;
                            DELETE FROM nguoidung WHERE MaNguoiDung = @uid;";

                        using (MySqlCommand cmd = new MySqlCommand(qXoa, conn))
                        {
                            cmd.Parameters.AddWithValue("@uid", PhienDangNhap.MaNguoiDungHienTai);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Đã xóa tài khoản. Tạm biệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                }
                catch (Exception ex) { MessageBox.Show("Lỗi xóa tài khoản: " + ex.Message); }
            }
        }
    }
}