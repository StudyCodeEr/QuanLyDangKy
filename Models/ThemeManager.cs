using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace QuanLyDangKy.Views
{
    public static class ThemeManager
    {
        public static void ApDungGiaoDien(Form frm, bool isDarkMode)
        {
            // Bảng màu chuẩn Material Design
            Color mauNenForm = isDarkMode ? Color.FromArgb(32, 33, 36) : Color.FromArgb(244, 246, 249);
            Color mauNenPanel = isDarkMode ? Color.FromArgb(45, 45, 49) : Color.White;
            Color mauChuChinh = isDarkMode ? Color.White : Color.FromArgb(64, 64, 64);
            Color mauChuPhu = isDarkMode ? Color.DarkGray : Color.DimGray;

            frm.BackColor = mauNenForm;

            // Truyền tất cả các màu vào đệ quy
            DoiMauControls(frm.Controls, mauNenForm, mauNenPanel, mauChuChinh, mauChuPhu, isDarkMode);
        }

        private static void DoiMauControls(Control.ControlCollection controls, Color mauNenForm, Color mauPanel, Color mauChuChinh, Color mauChuPhu, bool isDarkMode)
        {
            foreach (Control ctrl in controls)
            {
                // 1. Nhận diện Guna2Panel
                if (ctrl is Guna2Panel gunaPanel)
                {
                    gunaPanel.FillColor = mauPanel;
                    gunaPanel.BackColor = Color.Transparent; // Chống lỗi viền đen khi bo góc
                }
                // 2. PHÁT HIỆN & ĐỔI MÀU PANEL THƯỜNG (Thủ phạm là đây!)
                else if (ctrl is Panel pnl)
                {
                    pnl.BackColor = mauPanel;
                }
                // 3. Xử lý GroupBox thường của Windows
                else if (ctrl is GroupBox gb)
                {
                    gb.ForeColor = mauChuChinh;
                    gb.BackColor = Color.Transparent;
                }
                // 4. Xử lý Chữ (Giữ nguyên các chữ có màu sắc đặc biệt)
                else if (ctrl is Label lbl)
                {
                    if (lbl.ForeColor == Color.Black || lbl.ForeColor == Color.White ||
                        lbl.ForeColor == Color.FromArgb(64, 64, 64) || lbl.ForeColor == Color.DimGray || lbl.ForeColor == Color.DarkGray)
                    {
                        lbl.ForeColor = lbl.Font.Bold ? mauChuChinh : mauChuPhu;
                    }
                    lbl.BackColor = Color.Transparent; // Tránh nhòe nền
                }
                // 5. Ô nhập liệu
                else if (ctrl is Guna2TextBox txt)
                {
                    txt.FillColor = isDarkMode ? Color.FromArgb(55, 55, 58) : Color.White;
                    txt.ForeColor = mauChuChinh;
                }
                // 6. Hộp chọn
                else if (ctrl is Guna2ComboBox cmb)
                {
                    cmb.FillColor = isDarkMode ? Color.FromArgb(55, 55, 58) : Color.White;
                    cmb.ForeColor = mauChuChinh;
                }
                // 7. Chọn ngày tháng
                else if (ctrl is Guna2DateTimePicker dtp)
                {
                    dtp.FillColor = isDarkMode ? Color.FromArgb(55, 55, 58) : Color.White;
                    dtp.ForeColor = mauChuChinh;
                }
                // 8. Bảng dữ liệu
                else if (ctrl is Guna2DataGridView dgv)
                {
                    dgv.BackgroundColor = isDarkMode ? mauPanel : Color.White;
                    dgv.DefaultCellStyle.BackColor = isDarkMode ? mauPanel : Color.White;
                    dgv.DefaultCellStyle.ForeColor = mauChuChinh;
                    dgv.AlternatingRowsDefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(55, 55, 58) : Color.WhiteSmoke;

                    // Đổi màu cả thanh tiêu đề cột của Bảng
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(60, 60, 65) : Color.FromArgb(232, 234, 237);
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = mauChuChinh;
                }
                // 9. SỬA LỖI VIỀN TRẮNG CỦA CÁC NÚT BẤM BO TRÒN
                else if (ctrl is Guna2Button btn)
                {
                    // Ép màu nền của nút thành Trong suốt để nó ăn nhập với mọi màu Panel phía dưới
                    btn.BackColor = Color.Transparent;
                    btn.UseTransparentBackground = true; // Kích hoạt tính năng xóa nền xuyên thấu của Guna2
                }
                else if (ctrl is Guna2CircleButton circleBtn)
                {
                    circleBtn.BackColor = Color.Transparent;
                    circleBtn.UseTransparentBackground = true;
                }
                // 10. XỬ LÝ BIỂU ĐỒ LIVECHARTS (PieChart và CartesianChart)
                else if (ctrl is LiveCharts.WinForms.PieChart pieChart)
                {
                    pieChart.BackColor = mauPanel;       // Nền biểu đồ chìm vào nền Panel
                    pieChart.ForeColor = mauChuChinh;    // Đổi màu chữ (Chú thích / Legend) sang Trắng/Đen
                }
                else if (ctrl is LiveCharts.WinForms.CartesianChart barChart) // Đề phòng sau này bạn dùng thêm biểu đồ cột
                {
                    barChart.BackColor = mauPanel;
                    barChart.ForeColor = mauChuChinh;
                }
                {
                    DoiMauControls(ctrl.Controls, mauNenForm, mauPanel, mauChuChinh, mauChuPhu, isDarkMode);
                }
            }
        }
    }
}