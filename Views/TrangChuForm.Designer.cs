namespace QuanLyDangKy.Views
{
    partial class TrangChuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlTop = new Guna.UI2.WinForms.Guna2Panel();
            this.lblHomNay = new System.Windows.Forms.Label();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.btnMoDangNhap = new Guna.UI2.WinForms.Guna2Button();
            this.menuTaiKhoan = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.menuSuaThongTin = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlSidebar = new Guna.UI2.WinForms.Guna2Panel();
            this.btnThemLich = new Guna.UI2.WinForms.Guna2Button();
            this.btnToggleBoLoc = new Guna.UI2.WinForms.Guna2Button();
            this.pnlDanhSachBoLoc = new Guna.UI2.WinForms.Guna2Panel();
            this.chkLocKhac = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkLocTienIch = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkLocCongViec = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkLocHocTap = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkLocGiaiTri = new Guna.UI2.WinForms.Guna2CheckBox();
            this.calMini = new System.Windows.Forms.MonthCalendar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tlpLich = new System.Windows.Forms.TableLayoutPanel();
            this.btnThongKe = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btnCaiDat = new Guna.UI2.WinForms.Guna2CircleButton();
            this.pnlTop.SuspendLayout();
            this.menuTaiKhoan.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.pnlDanhSachBoLoc.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblHomNay);
            this.pnlTop.Controls.Add(this.btnThongKe);
            this.pnlTop.Controls.Add(this.btnCaiDat);
            this.pnlTop.Controls.Add(this.guna2Separator1);
            this.pnlTop.Controls.Add(this.btnMoDangNhap);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1262, 60);
            this.pnlTop.TabIndex = 0;
            // 
            // lblHomNay
            // 
            this.lblHomNay.AutoSize = true;
            this.lblHomNay.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHomNay.ForeColor = System.Drawing.Color.DimGray;
            this.lblHomNay.Location = new System.Drawing.Point(20, 15);
            this.lblHomNay.Name = "lblHomNay";
            this.lblHomNay.Size = new System.Drawing.Size(0, 31);
            this.lblHomNay.TabIndex = 4;
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Separator1.Location = new System.Drawing.Point(0, 55);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(1262, 5);
            this.guna2Separator1.TabIndex = 1;
            // 
            // btnMoDangNhap
            // 
            this.btnMoDangNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoDangNhap.BackColor = System.Drawing.Color.White;
            this.btnMoDangNhap.BorderRadius = 15;
            this.btnMoDangNhap.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMoDangNhap.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMoDangNhap.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMoDangNhap.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMoDangNhap.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(97)))), ((int)(((byte)(242)))));
            this.btnMoDangNhap.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            this.btnMoDangNhap.ForeColor = System.Drawing.Color.White;
            this.btnMoDangNhap.Location = new System.Drawing.Point(1126, 9);
            this.btnMoDangNhap.Name = "btnMoDangNhap";
            this.btnMoDangNhap.Size = new System.Drawing.Size(100, 40);
            this.btnMoDangNhap.TabIndex = 0;
            this.btnMoDangNhap.Text = "ĐĂNG NHẬP";
            this.btnMoDangNhap.Click += new System.EventHandler(this.btnMoDangNhap_Click);
            // 
            // menuTaiKhoan
            // 
            this.menuTaiKhoan.BackColor = System.Drawing.Color.White;
            this.menuTaiKhoan.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuTaiKhoan.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSuaThongTin,
            this.menuDangXuat});
            this.menuTaiKhoan.Name = "menuTaiKhoan";
            this.menuTaiKhoan.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.menuTaiKhoan.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.menuTaiKhoan.RenderStyle.ColorTable = null;
            this.menuTaiKhoan.RenderStyle.RoundedEdges = true;
            this.menuTaiKhoan.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.menuTaiKhoan.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.menuTaiKhoan.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.menuTaiKhoan.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.menuTaiKhoan.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.menuTaiKhoan.Size = new System.Drawing.Size(223, 52);
            // 
            // menuSuaThongTin
            // 
            this.menuSuaThongTin.Name = "menuSuaThongTin";
            this.menuSuaThongTin.Size = new System.Drawing.Size(222, 24);
            this.menuSuaThongTin.Text = "Sửa thông tin cá nhân";
            this.menuSuaThongTin.Click += new System.EventHandler(this.menuSuaThongTin_Click);
            // 
            // menuDangXuat
            // 
            this.menuDangXuat.Name = "menuDangXuat";
            this.menuDangXuat.Size = new System.Drawing.Size(222, 24);
            this.menuDangXuat.Text = "Đăng xuất";
            this.menuDangXuat.Click += new System.EventHandler(this.menuDangXuat_Click);
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.Controls.Add(this.btnThemLich);
            this.pnlSidebar.Controls.Add(this.btnToggleBoLoc);
            this.pnlSidebar.Controls.Add(this.pnlDanhSachBoLoc);
            this.pnlSidebar.Controls.Add(this.calMini);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.pnlSidebar.Location = new System.Drawing.Point(0, 60);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(220, 613);
            this.pnlSidebar.TabIndex = 1;
            // 
            // btnThemLich
            // 
            this.btnThemLich.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnThemLich.BackColor = System.Drawing.Color.Transparent;
            this.btnThemLich.BorderColor = System.Drawing.Color.Gray;
            this.btnThemLich.BorderRadius = 15;
            this.btnThemLich.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThemLich.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThemLich.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThemLich.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThemLich.FillColor = System.Drawing.Color.White;
            this.btnThemLich.Font = new System.Drawing.Font("Segoe UI Variable Display", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemLich.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnThemLich.Location = new System.Drawing.Point(18, 517);
            this.btnThemLich.Name = "btnThemLich";
            this.btnThemLich.ShadowDecoration.BorderRadius = 15;
            this.btnThemLich.ShadowDecoration.Enabled = true;
            this.btnThemLich.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(-3, 0, 3, 5);
            this.btnThemLich.Size = new System.Drawing.Size(180, 54);
            this.btnThemLich.TabIndex = 3;
            this.btnThemLich.Text = "Thêm Lịch";
            this.btnThemLich.Click += new System.EventHandler(this.btnThemLich_Click);
            // 
            // btnToggleBoLoc
            // 
            this.btnToggleBoLoc.BackColor = System.Drawing.Color.Transparent;
            this.btnToggleBoLoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToggleBoLoc.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnToggleBoLoc.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnToggleBoLoc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnToggleBoLoc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnToggleBoLoc.FillColor = System.Drawing.Color.Transparent;
            this.btnToggleBoLoc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnToggleBoLoc.ForeColor = System.Drawing.Color.DimGray;
            this.btnToggleBoLoc.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.btnToggleBoLoc.Location = new System.Drawing.Point(0, 233);
            this.btnToggleBoLoc.Name = "btnToggleBoLoc";
            this.btnToggleBoLoc.Size = new System.Drawing.Size(220, 36);
            this.btnToggleBoLoc.TabIndex = 2;
            this.btnToggleBoLoc.Text = "▼ Lọc Theo Thể Loại";
            this.btnToggleBoLoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnToggleBoLoc.Click += new System.EventHandler(this.btnToggleBoLoc_Click);
            // 
            // pnlDanhSachBoLoc
            // 
            this.pnlDanhSachBoLoc.Controls.Add(this.chkLocKhac);
            this.pnlDanhSachBoLoc.Controls.Add(this.chkLocTienIch);
            this.pnlDanhSachBoLoc.Controls.Add(this.chkLocCongViec);
            this.pnlDanhSachBoLoc.Controls.Add(this.chkLocHocTap);
            this.pnlDanhSachBoLoc.Controls.Add(this.chkLocGiaiTri);
            this.pnlDanhSachBoLoc.Location = new System.Drawing.Point(0, 269);
            this.pnlDanhSachBoLoc.Name = "pnlDanhSachBoLoc";
            this.pnlDanhSachBoLoc.Size = new System.Drawing.Size(220, 161);
            this.pnlDanhSachBoLoc.TabIndex = 1;
            // 
            // chkLocKhac
            // 
            this.chkLocKhac.AutoSize = true;
            this.chkLocKhac.BackColor = System.Drawing.Color.Transparent;
            this.chkLocKhac.CheckedState.BorderColor = System.Drawing.Color.LightGray;
            this.chkLocKhac.CheckedState.BorderRadius = 0;
            this.chkLocKhac.CheckedState.BorderThickness = 0;
            this.chkLocKhac.CheckedState.FillColor = System.Drawing.Color.Green;
            this.chkLocKhac.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLocKhac.ForeColor = System.Drawing.Color.Black;
            this.chkLocKhac.Location = new System.Drawing.Point(34, 125);
            this.chkLocKhac.Name = "chkLocKhac";
            this.chkLocKhac.Size = new System.Drawing.Size(58, 21);
            this.chkLocKhac.TabIndex = 6;
            this.chkLocKhac.Text = "Khác";
            this.chkLocKhac.UncheckedState.BorderColor = System.Drawing.Color.LimeGreen;
            this.chkLocKhac.UncheckedState.BorderRadius = 0;
            this.chkLocKhac.UncheckedState.BorderThickness = 0;
            this.chkLocKhac.UncheckedState.FillColor = System.Drawing.Color.White;
            this.chkLocKhac.UseVisualStyleBackColor = false;
            // 
            // chkLocTienIch
            // 
            this.chkLocTienIch.AutoSize = true;
            this.chkLocTienIch.BackColor = System.Drawing.Color.Transparent;
            this.chkLocTienIch.CheckedState.BorderColor = System.Drawing.Color.LightGray;
            this.chkLocTienIch.CheckedState.BorderRadius = 0;
            this.chkLocTienIch.CheckedState.BorderThickness = 0;
            this.chkLocTienIch.CheckedState.FillColor = System.Drawing.Color.Green;
            this.chkLocTienIch.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLocTienIch.ForeColor = System.Drawing.Color.Black;
            this.chkLocTienIch.Location = new System.Drawing.Point(34, 98);
            this.chkLocTienIch.Name = "chkLocTienIch";
            this.chkLocTienIch.Size = new System.Drawing.Size(74, 21);
            this.chkLocTienIch.TabIndex = 5;
            this.chkLocTienIch.Text = "Tiện ích";
            this.chkLocTienIch.UncheckedState.BorderColor = System.Drawing.Color.LimeGreen;
            this.chkLocTienIch.UncheckedState.BorderRadius = 0;
            this.chkLocTienIch.UncheckedState.BorderThickness = 0;
            this.chkLocTienIch.UncheckedState.FillColor = System.Drawing.Color.White;
            this.chkLocTienIch.UseVisualStyleBackColor = false;
            // 
            // chkLocCongViec
            // 
            this.chkLocCongViec.AutoSize = true;
            this.chkLocCongViec.BackColor = System.Drawing.Color.Transparent;
            this.chkLocCongViec.CheckedState.BorderColor = System.Drawing.Color.LightGray;
            this.chkLocCongViec.CheckedState.BorderRadius = 0;
            this.chkLocCongViec.CheckedState.BorderThickness = 0;
            this.chkLocCongViec.CheckedState.FillColor = System.Drawing.Color.Blue;
            this.chkLocCongViec.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLocCongViec.ForeColor = System.Drawing.Color.Black;
            this.chkLocCongViec.Location = new System.Drawing.Point(34, 41);
            this.chkLocCongViec.Name = "chkLocCongViec";
            this.chkLocCongViec.Size = new System.Drawing.Size(87, 21);
            this.chkLocCongViec.TabIndex = 3;
            this.chkLocCongViec.Text = "Công việc";
            this.chkLocCongViec.UncheckedState.BorderColor = System.Drawing.Color.RoyalBlue;
            this.chkLocCongViec.UncheckedState.BorderRadius = 0;
            this.chkLocCongViec.UncheckedState.BorderThickness = 0;
            this.chkLocCongViec.UncheckedState.FillColor = System.Drawing.Color.White;
            this.chkLocCongViec.UseVisualStyleBackColor = false;
            // 
            // chkLocHocTap
            // 
            this.chkLocHocTap.AutoSize = true;
            this.chkLocHocTap.BackColor = System.Drawing.Color.Transparent;
            this.chkLocHocTap.CheckedState.BorderColor = System.Drawing.Color.LightGray;
            this.chkLocHocTap.CheckedState.BorderRadius = 0;
            this.chkLocHocTap.CheckedState.BorderThickness = 0;
            this.chkLocHocTap.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.chkLocHocTap.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLocHocTap.ForeColor = System.Drawing.Color.Black;
            this.chkLocHocTap.Location = new System.Drawing.Point(34, 71);
            this.chkLocHocTap.Name = "chkLocHocTap";
            this.chkLocHocTap.Size = new System.Drawing.Size(76, 21);
            this.chkLocHocTap.TabIndex = 4;
            this.chkLocHocTap.Text = "Học tập";
            this.chkLocHocTap.UncheckedState.BorderColor = System.Drawing.Color.Orange;
            this.chkLocHocTap.UncheckedState.BorderRadius = 0;
            this.chkLocHocTap.UncheckedState.BorderThickness = 0;
            this.chkLocHocTap.UncheckedState.FillColor = System.Drawing.Color.White;
            this.chkLocHocTap.UseVisualStyleBackColor = false;
            // 
            // chkLocGiaiTri
            // 
            this.chkLocGiaiTri.AutoSize = true;
            this.chkLocGiaiTri.BackColor = System.Drawing.Color.Transparent;
            this.chkLocGiaiTri.CheckedState.BorderColor = System.Drawing.Color.LightGray;
            this.chkLocGiaiTri.CheckedState.BorderRadius = 0;
            this.chkLocGiaiTri.CheckedState.BorderThickness = 0;
            this.chkLocGiaiTri.CheckedState.FillColor = System.Drawing.Color.Red;
            this.chkLocGiaiTri.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLocGiaiTri.ForeColor = System.Drawing.Color.Black;
            this.chkLocGiaiTri.Location = new System.Drawing.Point(34, 14);
            this.chkLocGiaiTri.Name = "chkLocGiaiTri";
            this.chkLocGiaiTri.Size = new System.Drawing.Size(68, 21);
            this.chkLocGiaiTri.TabIndex = 2;
            this.chkLocGiaiTri.Text = "Giải trí";
            this.chkLocGiaiTri.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.chkLocGiaiTri.UncheckedState.BorderRadius = 0;
            this.chkLocGiaiTri.UncheckedState.BorderThickness = 0;
            this.chkLocGiaiTri.UncheckedState.FillColor = System.Drawing.Color.White;
            this.chkLocGiaiTri.UseVisualStyleBackColor = false;
            // 
            // calMini
            // 
            this.calMini.Cursor = System.Windows.Forms.Cursors.Hand;
            this.calMini.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calMini.Location = new System.Drawing.Point(7, 10);
            this.calMini.MaxSelectionCount = 1;
            this.calMini.Name = "calMini";
            this.calMini.TabIndex = 0;
            this.calMini.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.calMini_DateSelected);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.tlpLich);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(220, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1042, 613);
            this.panel1.TabIndex = 2;
            this.panel1.Resize += new System.EventHandler(this.panel1_Resize);
            // 
            // tlpLich
            // 
            this.tlpLich.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpLich.ColumnCount = 8;
            this.tlpLich.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpLich.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpLich.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpLich.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpLich.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpLich.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpLich.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpLich.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpLich.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpLich.Location = new System.Drawing.Point(0, 0);
            this.tlpLich.Name = "tlpLich";
            this.tlpLich.RowCount = 24;
            this.tlpLich.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpLich.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpLich.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpLich.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpLich.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpLich.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpLich.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpLich.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpLich.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpLich.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpLich.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpLich.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpLich.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpLich.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpLich.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpLich.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpLich.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpLich.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpLich.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpLich.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpLich.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpLich.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpLich.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpLich.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpLich.Size = new System.Drawing.Size(1021, 1200);
            this.tlpLich.TabIndex = 0;
            // 
            // btnThongKe
            // 
            this.btnThongKe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThongKe.BackColor = System.Drawing.Color.Transparent;
            this.btnThongKe.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThongKe.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThongKe.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThongKe.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThongKe.FillColor = System.Drawing.Color.Transparent;
            this.btnThongKe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThongKe.ForeColor = System.Drawing.Color.White;
            this.btnThongKe.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.btnThongKe.Image = global::QuanLyDangKy.Properties.Resources.ThongKe_icon1;
            this.btnThongKe.ImageSize = new System.Drawing.Size(30, 30);
            this.btnThongKe.Location = new System.Drawing.Point(1006, 10);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnThongKe.Size = new System.Drawing.Size(40, 40);
            this.btnThongKe.TabIndex = 3;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnCaiDat
            // 
            this.btnCaiDat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCaiDat.BackColor = System.Drawing.Color.Transparent;
            this.btnCaiDat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCaiDat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCaiDat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCaiDat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCaiDat.FillColor = System.Drawing.Color.Transparent;
            this.btnCaiDat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCaiDat.ForeColor = System.Drawing.Color.White;
            this.btnCaiDat.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.btnCaiDat.Image = global::QuanLyDangKy.Properties.Resources.settings_icon1;
            this.btnCaiDat.ImageSize = new System.Drawing.Size(35, 35);
            this.btnCaiDat.Location = new System.Drawing.Point(1064, 9);
            this.btnCaiDat.Name = "btnCaiDat";
            this.btnCaiDat.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnCaiDat.Size = new System.Drawing.Size(40, 40);
            this.btnCaiDat.TabIndex = 2;
            this.btnCaiDat.Click += new System.EventHandler(this.btnCaiDat_Click);
            // 
            // TrangChuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlTop);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "TrangChuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trang chủ";
            this.Load += new System.EventHandler(this.TrangChuForm_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.menuTaiKhoan.ResumeLayout(false);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlDanhSachBoLoc.ResumeLayout(false);
            this.pnlDanhSachBoLoc.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlTop;
        private Guna.UI2.WinForms.Guna2Button btnMoDangNhap;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip menuTaiKhoan;
        private System.Windows.Forms.ToolStripMenuItem menuSuaThongTin;
        private System.Windows.Forms.ToolStripMenuItem menuDangXuat;
        private Guna.UI2.WinForms.Guna2CircleButton btnCaiDat;
        private Guna.UI2.WinForms.Guna2CircleButton btnThongKe;
        private Guna.UI2.WinForms.Guna2Panel pnlSidebar;
        private System.Windows.Forms.Label lblHomNay;
        private System.Windows.Forms.MonthCalendar calMini;
        private Guna.UI2.WinForms.Guna2CheckBox chkLocGiaiTri;
        private Guna.UI2.WinForms.Guna2Panel pnlDanhSachBoLoc;
        private Guna.UI2.WinForms.Guna2CheckBox chkLocTienIch;
        private Guna.UI2.WinForms.Guna2CheckBox chkLocCongViec;
        private Guna.UI2.WinForms.Guna2CheckBox chkLocHocTap;
        private Guna.UI2.WinForms.Guna2Button btnToggleBoLoc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tlpLich;
        private Guna.UI2.WinForms.Guna2Button btnThemLich;
        private Guna.UI2.WinForms.Guna2CheckBox chkLocKhac;
    }
}

