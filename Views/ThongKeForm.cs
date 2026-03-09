using LiveCharts;
using LiveCharts.Wpf;
using MySql.Data.MySqlClient;
using QuanLyDangKy.Data;
using QuanLyDangKy.Models;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using DotNetEnv; // Bắt buộc phải có để đọc file .env

namespace QuanLyDangKy.Views
{
    public partial class ThongKeForm : Form
    {
        // Bộ nhớ tạm để lưu tỷ giá lấy từ API
        private Dictionary<string, decimal> tyGiaCache = new Dictionary<string, decimal>();

        public ThongKeForm()
        {
            InitializeComponent();
            this.Load += ThongKeForm_Load;
        }

        private void ThongKeForm_Load(object sender, EventArgs e)
        {
            // Tải lịch sử ngay lập tức vì không phụ thuộc vào API
            LoadLichSu();

            // Gọi hàm tải API Tỷ giá chạy ngầm
            TaiTyGiaRealTime();
        }

        // ===============================================
        // 1. KẾT NỐI API & XỬ LÝ QUY ĐỔI TIỀN TỆ
        // ===============================================
        private async void TaiTyGiaRealTime()
        {
            try
            {
                // Tải biến môi trường từ file .env
                Env.Load();
                string apiKey = Environment.GetEnvironmentVariable("EXCHANGE_RATE_API_KEY");

                if (string.IsNullOrEmpty(apiKey) || apiKey == "YOUR_API_KEY_CUA_BAN_O_DAY")
                {
                    MessageBox.Show("Chưa cấu hình API Key trong file .env!\nHệ thống sẽ tạm thời không quy đổi tiền tệ.", "Cảnh báo bảo mật", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadTongQuan();
                    LoadBieuDoDonut();
                    return;
                }

                using (HttpClient client = new HttpClient())
                {
                    // Lấy tỷ giá gốc là USD
                    string url = $"https://v6.exchangerate-api.com/v6/{apiKey}/latest/USD";
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(responseBody);

                    // Xóa cache cũ và lưu tỷ giá mới vào bộ nhớ
                    tyGiaCache.Clear();
                    var rates = json["conversion_rates"].ToObject<Dictionary<string, decimal>>();
                    foreach (var rate in rates)
                    {
                        tyGiaCache.Add(rate.Key, rate.Value);
                    }

                    // Tải xong API thì tự động kích hoạt sự kiện vẽ biểu đồ
                    if (cmbTienTeThongKe.Items.Count > 0)
                    {
                        cmbTienTeThongKe.SelectedIndex = 0; // Mặc định chọn dòng đầu tiên (Thường là VND)
                    }
                    else
                    {
                        LoadTongQuan();
                        LoadBieuDoDonut();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể lấy tỷ giá Real-time: " + ex.Message, "Lỗi mạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadTongQuan();
                LoadBieuDoDonut();
            }
        }

        // Sự kiện khi người dùng chọn đổi loại tiền tệ trên giao diện
        private void cmbTienTeThongKe_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Vẽ lại toàn bộ biểu đồ và tổng tiền dựa trên mệnh giá mới
            LoadTongQuan();
            LoadBieuDoDonut();
        }

        // Siêu hàm tính toán quy đổi
        private decimal QuyDoiTienTe(decimal soTienGoc, string donViGoc, string donViDich)
        {
            // Nếu mất mạng, chưa có API, hoặc 2 đơn vị giống nhau -> Trả về tiền gốc
            if (tyGiaCache.Count == 0 || !tyGiaCache.ContainsKey(donViGoc) || !tyGiaCache.ContainsKey(donViDich) || donViGoc == donViDich)
            {
                return soTienGoc;
            }

            // Công thức: Tiền Gốc -> USD -> Tiền Đích
            decimal tienUSD = soTienGoc / tyGiaCache[donViGoc];
            return tienUSD * tyGiaCache[donViDich];
        }

        // ===============================================
        // 2. TẢI TỔNG QUAN (CÓ ÁP DỤNG QUY ĐỔI)
        // ===============================================
        private void LoadTongQuan()
        {
            // Mặc định là VND nếu người dùng chưa chọn gì
            string tienTeDich = cmbTienTeThongKe.SelectedItem != null ? cmbTienTeThongKe.SelectedItem.ToString() : "VND";

            try
            {
                KetNoiDuLieu db = new KetNoiDuLieu();
                decimal tongTienQuyDoi = 0;

                using (MySqlConnection conn = new MySqlConnection(db.LayChuoiKetNoi()))
                {
                    conn.Open();

                    // 1. Tính tổng tiền (Lấy từng gói ra để nhân tỷ giá)
                    string queryTien = "SELECT GiaGoc, DonViTienTe FROM GoiDangKy WHERE MaNguoiDung = @uid AND TrangThaiHoatDong = 1";
                    using (MySqlCommand cmd = new MySqlCommand(queryTien, conn))
                    {
                        cmd.Parameters.AddWithValue("@uid", PhienDangNhap.MaNguoiDungHienTai);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                decimal giaGoc = reader.GetDecimal("GiaGoc");
                                string donViGoc = reader.GetString("DonViTienTe");
                                tongTienQuyDoi += QuyDoiTienTe(giaGoc, donViGoc, tienTeDich);
                            }
                        }
                    }
                    lblTongChiPhi.Text = $"{tongTienQuyDoi:N0} {tienTeDich}";

                    // 2. Đếm số gói đang hoạt động
                    string queryDem = "SELECT COUNT(*) FROM GoiDangKy WHERE MaNguoiDung = @uid AND TrangThaiHoatDong = 1";
                    using (MySqlCommand cmdDem = new MySqlCommand(queryDem, conn))
                    {
                        cmdDem.Parameters.AddWithValue("@uid", PhienDangNhap.MaNguoiDungHienTai);
                        lblSoGoi.Text = cmdDem.ExecuteScalar().ToString() + " Gói";
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi Tổng quan: " + ex.Message); }
        }

        // ===============================================
        // 3. VẼ BIỂU ĐỒ DONUT (CÓ ÁP DỤNG QUY ĐỔI)
        // ===============================================
        private void LoadBieuDoDonut()
        {
            string tienTeDich = cmbTienTeThongKe.SelectedItem != null ? cmbTienTeThongKe.SelectedItem.ToString() : "VND";

            try
            {
                // Cấu hình UI cho Biểu đồ
                chartTheLoai.InnerRadius = 60; // Tạo lỗ khuyết ở giữa (Donut)
                chartTheLoai.LegendLocation = LegendLocation.Right;
                chartTheLoai.BackColor = Color.White;

                SeriesCollection series = new SeriesCollection();
                Dictionary<string, decimal> tongTienTheoLoai = new Dictionary<string, decimal>();

                KetNoiDuLieu db = new KetNoiDuLieu();
                using (MySqlConnection conn = new MySqlConnection(db.LayChuoiKetNoi()))
                {
                    // Lấy tất cả gói ra để tính tỷ giá thay vì dùng hàm SUM của SQL
                    string query = @"SELECT TheLoai, GiaGoc, DonViTienTe 
                                     FROM GoiDangKy 
                                     WHERE MaNguoiDung = @uid AND TrangThaiHoatDong = 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@uid", PhienDangNhap.MaNguoiDungHienTai);
                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string theLoai = reader.GetString("TheLoai");
                                decimal giaGoc = reader.GetDecimal("GiaGoc");
                                string donViGoc = reader.GetString("DonViTienTe");

                                // Áp dụng tỷ giá
                                decimal giaDaQuyDoi = QuyDoiTienTe(giaGoc, donViGoc, tienTeDich);

                                // Cộng dồn tiền vào Thể Loại tương ứng
                                if (!tongTienTheoLoai.ContainsKey(theLoai))
                                    tongTienTheoLoai[theLoai] = 0;

                                tongTienTheoLoai[theLoai] += giaDaQuyDoi;
                            }
                        }
                    }
                }

                // Đổ dữ liệu đã cộng dồn vào Biểu đồ
                foreach (var item in tongTienTheoLoai)
                {
                    series.Add(new PieSeries
                    {
                        Title = item.Key,
                        Values = new ChartValues<double> { (double)item.Value },
                        DataLabels = true,
                        LabelPoint = point => $"{point.Y:N0} {tienTeDich} ({point.Participation:P0})"
                    });
                }

                chartTheLoai.Series = series;
            }
            catch (Exception ex) { MessageBox.Show("Lỗi Biểu đồ: " + ex.Message); }
        }

        // ===============================================
        // 4. TẢI LỊCH SỬ HOẠT ĐỘNG
        // ===============================================
        private void LoadLichSu()
        {
            try
            {
                KetNoiDuLieu db = new KetNoiDuLieu();
                using (MySqlConnection conn = new MySqlConnection(db.LayChuoiKetNoi()))
                {
                    string query = @"SELECT NgayThucHien, HanhDong, TenDichVu, SoTien 
                                     FROM LichSuHoatDong 
                                     WHERE MaNguoiDung = @uid 
                                     ORDER BY NgayThucHien DESC LIMIT 15";

                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@uid", PhienDangNhap.MaNguoiDungHienTai);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLichSu.DataSource = dt;

                        if (dgvLichSu.Columns.Count > 0)
                        {
                            dgvLichSu.Columns["NgayThucHien"].HeaderText = "Thời gian";
                            dgvLichSu.Columns["NgayThucHien"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                            dgvLichSu.Columns["HanhDong"].HeaderText = "Hành động";
                            dgvLichSu.Columns["TenDichVu"].HeaderText = "Dịch vụ";
                            dgvLichSu.Columns["SoTien"].HeaderText = "Số tiền";
                            dgvLichSu.Columns["SoTien"].DefaultCellStyle.Format = "N0";
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi Lịch sử: " + ex.Message); }
        }

    }
}