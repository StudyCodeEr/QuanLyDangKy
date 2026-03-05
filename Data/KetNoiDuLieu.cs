using System;
using MySql.Data.MySqlClient;
using DotNetEnv;

namespace QuanLyDangKy.Data
{
    public class KetNoiDuLieu
    {
        private string chuoiKetNoi;
        public KetNoiDuLieu()
        {
            // Tải biến môi trường từ file .env (Tuân thủ chuẩn bảo mật)
            Env.Load();
            chuoiKetNoi = Environment.GetEnvironmentVariable("DB_CONNECTION");

            if (string.IsNullOrEmpty(chuoiKetNoi))
            {
                throw new Exception("Lỗi bảo mật: Không tìm thấy DB_CONNECTION trong file .env!");
            }
        }
        // Hàm cung cấp chuỗi kết nối cho các chức năng khác
        public string LayChuoiKetNoi()
        {
            return chuoiKetNoi;
        }
        // Hàm test kết nối nhanh
        public bool KiemTraKetNoi()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(chuoiKetNoi))
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}