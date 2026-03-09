using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json.Linq;
using DotNetEnv;
using MySql.Data.MySqlClient;
using QuanLyDangKy.Data;
using QuanLyDangKy.Models;

namespace QuanLyDangKy.Views
{
    public partial class ThemGoiForm : Form
    {
        // Khởi tạo màu mặc định và biến lưu nút đang chọn
        private string mauSacDaChon = "#34A853";
        private Guna.UI2.WinForms.Guna2CircleButton nutMauDangChon = null;

        public ThemGoiForm()
        {
            InitializeComponent();
        }

        // ===============================================
        // SỰ KIỆN LOAD FORM
        // ===============================================
        private void ThemGoiForm_Load(object sender, EventArgs e)
        {
            TaiDanhSachMau();
            HieuUngChonMau(btnMau1); // Mặc định tô viền cho nút màu đầu tiên
        }

        // ===============================================
        // LOGIC CHỌN MÀU SẮC
        // ===============================================
        private void HieuUngChonMau(Guna.UI2.WinForms.Guna2CircleButton nutDuocChon)
        {
            // Tắt viền nút cũ
            if (nutMauDangChon != null)
            {
                nutMauDangChon.BorderThickness = 0;
                if (nutMauDangChon == btnMauCustom) nutMauDangChon.BorderThickness = 1;
            }

            // Bật viền nút mới
            nutMauDangChon = nutDuocChon;
            nutMauDangChon.BorderColor = Color.Black;
            nutMauDangChon.BorderThickness = 3;

            // Lưu mã HEX
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
            colorDialog.FullOpen = true; // Mở sẵn bảng dải màu Gradient

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                btnMauCustom.FillColor = colorDialog.Color;
                btnMauCustom.Text = "";
                HieuUngChonMau(btnMauCustom);
            }
        }

        // ===============================================
        // AI XỬ LÝ NGÔN NGỮ TỰ NHIÊN (GROQ API)
        // ===============================================
        private async void btnPhanTich_Click(object sender, EventArgs e)
        {
            string prompt = txtNhapNhanh.Text.Trim();
            if (string.IsNullOrEmpty(prompt)) return;

            btnPhanTich.Enabled = false;
            btnPhanTich.Text = "⏳ AI đang phân tích...";

            try
            {
                Env.Load();
                string apiKey = Environment.GetEnvironmentVariable("GROQ_API_KEY");
                if (string.IsNullOrEmpty(apiKey)) throw new Exception("Thiếu GROQ_API_KEY trong file .env!");

                string systemPrompt = $@"Bạn là một Chuyên gia AI trích xuất dữ liệu tài chính. Hôm nay là ngày {DateTime.Now:yyyy-MM-dd}.
                Nhiệm vụ của bạn là đọc câu mô tả của người dùng và trích xuất thông tin thành MỘT CHUỖI JSON DUY NHẤT. Tuyệt đối không sinh ra markdown (như ```json), không có lời chào, không có giải thích.

                QUY TẮC XỬ LÝ DỮ LIỆU ĐỊA PHƯƠNG VÀ ĐA TIỀN TỆ:
                1. TenDichVu: Lấy chính xác tên dịch vụ (VD: Netflix, Spotify, Bilibili, ChatGPT). Chuẩn hóa viết hoa chữ cái đầu.
                2. TheLoai: CHỈ ĐƯỢC CHỌN 1 TRONG 5 GIÁ TRỊ: ""Giải trí"", ""Công việc"", ""Học tập"", ""Tiện ích"", ""Khác"".
                3. DonViTienTe: Suy luận từ ký hiệu hoặc từ khóa trong câu. CHỈ XUẤT 1 TRONG 8 MÃ SAU:
                   - 'VND': Nếu có 'k', 'nghìn', 'ngàn', 'tr', 'triệu', 'củ', 'đ', 'vnđ', 'đồng' HOẶC không nhắc đến tiền tệ.
                   - 'USD': Nếu có '$', 'đô', 'usd', 'bucks'.
                   - 'EUR': Nếu có '€', 'euro', 'ơ rô'.
                   - 'JPY': Nếu có '¥', 'yên', 'yen', 'jpy'.
                   - 'GBP': Nếu có '£', 'bảng', 'bảng anh', 'gbp'.
                   - 'CNY': Nếu có 'tệ', 'nhân dân tệ', 'cny', 'rmb'.
                   - 'KRW': Nếu có 'won', 'krw'.
                   - 'AUD': Nếu có 'aud', 'đô úc'.
                4. GiaGoc: Chỉ xuất số nguyên. Xử lý nhân tỷ giá lóng (chỉ áp dụng nếu là VND): 
                   - Có 'k', 'nghìn' -> Nhân 1000 (VD: '50k' -> 50000).
                   - Có 'tr', 'triệu', 'củ' -> Nhân 1000000 (VD: '1.5 củ' -> 1500000).
                   - Các ngoại tệ khác (USD, EUR, JPY...) -> GIỮ NGUYÊN CON SỐ (VD: '20$' -> 20, '1500 yên' -> 1500).
                5. NgayGiaHan: Định dạng chuẩn 'yyyy-MM-dd'. Suy luận dựa trên mốc hôm nay ({DateTime.Now:yyyy-MM-dd}):
                   - Nếu ghi 'ngày X', 'mùng X': Lấy ngày X trong tháng này. NẾU NGÀY ĐÓ ĐÃ QUA so với hôm nay, hãy tự động cộng lên THÁNG TIẾP THEO.
                   - Nếu ghi 'ngày mai': Lấy hôm nay + 1 ngày.
                   - Nếu không nhắc đến: Lấy đúng ngày hôm nay ({DateTime.Now:yyyy-MM-dd}).

                CẤU TRÚC JSON BẮT BUỘC ĐẦU RA:
                {{
                    ""TenDichVu"": ""Tên dịch vụ"",
                    ""TheLoai"": ""Tên thể loại"",
                    ""GiaGoc"": <Số nguyên>,
                    ""DonViTienTe"": ""Mã tiền tệ (VND/USD/EUR/JPY/GBP/CNY/KRW/AUD)"",
                    ""NgayGiaHan"": ""yyyy-MM-dd""
                }}";

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

                    var requestBody = new
                    {
                        model = "llama-3.3-70b-versatile",
                        messages = new[] { new { role = "system", content = systemPrompt }, new { role = "user", content = prompt } },
                        temperature = 0.1,
                        response_format = new { type = "json_object" }
                    };

                    string jsonBody = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
                    var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("https://api.groq.com/openai/v1/chat/completions", content);
                    string resultString = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode) throw new Exception("Lỗi API");

                    JObject aiJson = JObject.Parse(JObject.Parse(resultString)["choices"][0]["message"]["content"].ToString());

                    // Đổ dữ liệu
                    txtTenDichVu.Text = aiJson["TenDichVu"]?.ToString();
                    txtGiaTien.Text = aiJson["GiaGoc"]?.ToString();

                    string theLoaiAI = aiJson["TheLoai"]?.ToString();
                    if (cmbTheLoai.Items.Contains(theLoaiAI)) cmbTheLoai.SelectedItem = theLoaiAI;
                    else cmbTheLoai.SelectedItem = "Khác";

                    string tienTeAI = aiJson["DonViTienTe"]?.ToString();
                    if (cmbTienTe.Items.Contains(tienTeAI)) cmbTienTe.SelectedItem = tienTeAI;

                    if (DateTime.TryParse(aiJson["NgayGiaHan"]?.ToString(), out DateTime ngayPhanTich))
                        dtpNgayGiaHan.Value = ngayPhanTich;
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            finally { btnPhanTich.Enabled = true; btnPhanTich.Text = "Phân Tích"; }
        }

        // ===============================================
        // TẢI VÀ SỬ DỤNG MẪU GÓI (TEMPLATE)
        // ===============================================
        private void TaiDanhSachMau()
        {
            cmbMauDaLuu.Items.Clear();
            cmbMauDaLuu.Items.Add("-- Chọn từ mẫu gói đã lưu --");

            try
            {
                KetNoiDuLieu db = new KetNoiDuLieu();
                using (MySqlConnection conn = new MySqlConnection(db.LayChuoiKetNoi()))
                {
                    string query = "SELECT TenDichVu FROM GoiMau WHERE MaNguoiDung = @uid";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@uid", PhienDangNhap.MaNguoiDungHienTai);
                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read()) cmbMauDaLuu.Items.Add(reader.GetString("TenDichVu"));
                        }
                    }
                }
            }
            catch { }
            cmbMauDaLuu.SelectedIndex = 0;
        }

        private void cmbMauDaLuu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMauDaLuu.SelectedIndex <= 0) return;
            string tenMau = cmbMauDaLuu.SelectedItem.ToString();

            try
            {
                KetNoiDuLieu db = new KetNoiDuLieu();
                using (MySqlConnection conn = new MySqlConnection(db.LayChuoiKetNoi()))
                {
                    string query = "SELECT TheLoai, GiaGoc, DonViTienTe, MauSac FROM GoiMau WHERE MaNguoiDung = @uid AND TenDichVu = @ten LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@uid", PhienDangNhap.MaNguoiDungHienTai);
                        cmd.Parameters.AddWithValue("@ten", tenMau);
                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtTenDichVu.Text = tenMau;
                                txtGiaTien.Text = reader.GetDecimal("GiaGoc").ToString("0");
                                cmbTheLoai.SelectedItem = reader.GetString("TheLoai");

                                string tienTeLuu = reader.GetString("DonViTienTe");
                                if (cmbTienTe.Items.Contains(tienTeLuu)) cmbTienTe.SelectedItem = tienTeLuu;

                                // Custom màu sắc từ DB gán thẳng vào nút Custom
                                mauSacDaChon = reader.GetString("MauSac");
                                btnMauCustom.FillColor = ColorTranslator.FromHtml(mauSacDaChon);
                                btnMauCustom.Text = "";
                                HieuUngChonMau(btnMauCustom);
                            }
                        }
                    }
                }
            }
            catch { }
        }

        // ===============================================
        // LƯU GÓI ĐĂNG KÝ VÀO CƠ SỞ DỮ LIỆU
        // ===============================================
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string ten = txtTenDichVu.Text.Trim();
            string loai = cmbTheLoai.SelectedItem?.ToString();
            string tienTe = cmbTienTe.SelectedItem?.ToString();
            DateTime ngay = dtpNgayGiaHan.Value;

            if (string.IsNullOrWhiteSpace(ten) || !decimal.TryParse(txtGiaTien.Text, out decimal gia) || gia <= 0)
            {
                MessageBox.Show("Vui lòng kiểm tra lại Tên dịch vụ và Giá tiền!", "Lỗi");
                return;
            }

            try
            {
                KetNoiDuLieu db = new KetNoiDuLieu();
                using (MySqlConnection conn = new MySqlConnection(db.LayChuoiKetNoi()))
                {
                    conn.Open();

                    string qInsertGoi = @"INSERT INTO GoiDangKy (MaNguoiDung, TenDichVu, TheLoai, GiaGoc, DonViTienTe, NgayGiaHan, TrangThaiHoatDong, MauSac) 
                                          VALUES (@uid, @ten, @loai, @gia, @tiente, @ngay, 1, @mau)";
                    using (MySqlCommand cmd = new MySqlCommand(qInsertGoi, conn))
                    {
                        cmd.Parameters.AddWithValue("@uid", PhienDangNhap.MaNguoiDungHienTai);
                        cmd.Parameters.AddWithValue("@ten", ten);
                        cmd.Parameters.AddWithValue("@loai", loai);
                        cmd.Parameters.AddWithValue("@gia", gia);
                        cmd.Parameters.AddWithValue("@tiente", tienTe);
                        cmd.Parameters.AddWithValue("@ngay", ngay.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@mau", mauSacDaChon);
                        cmd.ExecuteNonQuery();
                    }

                    if (chkLuuMau.Checked)
                    {
                        string qXoaMauCu = "DELETE FROM GoiMau WHERE MaNguoiDung = @uid AND TenDichVu = @ten";
                        using (MySqlCommand cmdXoa = new MySqlCommand(qXoaMauCu, conn))
                        {
                            cmdXoa.Parameters.AddWithValue("@uid", PhienDangNhap.MaNguoiDungHienTai);
                            cmdXoa.Parameters.AddWithValue("@ten", ten);
                            cmdXoa.ExecuteNonQuery();
                        }

                        string qInsertMau = @"INSERT INTO GoiMau (MaNguoiDung, TenDichVu, TheLoai, GiaGoc, DonViTienTe, MauSac) 
                                              VALUES (@uid, @ten, @loai, @gia, @tiente, @mau)";
                        using (MySqlCommand cmdMau = new MySqlCommand(qInsertMau, conn))
                        {
                            cmdMau.Parameters.AddWithValue("@uid", PhienDangNhap.MaNguoiDungHienTai);
                            cmdMau.Parameters.AddWithValue("@ten", ten);
                            cmdMau.Parameters.AddWithValue("@loai", loai);
                            cmdMau.Parameters.AddWithValue("@gia", gia);
                            cmdMau.Parameters.AddWithValue("@tiente", tienTe);
                            cmdMau.Parameters.AddWithValue("@mau", mauSacDaChon);
                            cmdMau.ExecuteNonQuery();
                        }
                    }
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }
    }
}