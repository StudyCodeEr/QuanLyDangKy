using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDangKy.Models
{
    public static class PhienDangNhap
    {
        // Lưu mã người dùng đang đăng nhập để load đúng dữ liệu của người đó
        public static int MaNguoiDungHienTai { get; set; } = -1;
        public static string TenDangNhapHienTai { get; set; } = "";
        public static string TienTeMacDinh = "VND";
        public static bool CheDoToi = false;
        public static int SoNgayNhac = 3;   
    }
}
