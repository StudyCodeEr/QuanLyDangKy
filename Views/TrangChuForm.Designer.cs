namespace QuanLyDangKy
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
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.btnMoDangNhap = new Guna.UI2.WinForms.Guna2Button();
            this.menuTaiKhoan = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.menuSuaThongTin = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.btnThongKe = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btnCaiDat = new Guna.UI2.WinForms.Guna2CircleButton();
            this.pnlTop.SuspendLayout();
            this.menuTaiKhoan.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
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
            this.btnMoDangNhap.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.btnMoDangNhap.ForeColor = System.Drawing.Color.White;
            this.btnMoDangNhap.Location = new System.Drawing.Point(1156, 9);
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
            // 
            // menuDangXuat
            // 
            this.menuDangXuat.Name = "menuDangXuat";
            this.menuDangXuat.Size = new System.Drawing.Size(222, 24);
            this.menuDangXuat.Text = "Đăng xuất";
            // 
            // btnThongKe
            // 
            this.btnThongKe.BackColor = System.Drawing.Color.Transparent;
            this.btnThongKe.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThongKe.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThongKe.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThongKe.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThongKe.FillColor = System.Drawing.Color.Transparent;
            this.btnThongKe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThongKe.ForeColor = System.Drawing.Color.White;
            this.btnThongKe.Image = global::QuanLyDangKy.Properties.Resources.ThongKe_icon1;
            this.btnThongKe.ImageSize = new System.Drawing.Size(40, 40);
            this.btnThongKe.Location = new System.Drawing.Point(1033, 9);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnThongKe.Size = new System.Drawing.Size(40, 40);
            this.btnThongKe.TabIndex = 3;
            // 
            // btnCaiDat
            // 
            this.btnCaiDat.BackColor = System.Drawing.Color.Transparent;
            this.btnCaiDat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCaiDat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCaiDat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCaiDat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCaiDat.FillColor = System.Drawing.Color.Transparent;
            this.btnCaiDat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCaiDat.ForeColor = System.Drawing.Color.White;
            this.btnCaiDat.Image = global::QuanLyDangKy.Properties.Resources.settings_icon1;
            this.btnCaiDat.ImageSize = new System.Drawing.Size(40, 40);
            this.btnCaiDat.Location = new System.Drawing.Point(1094, 9);
            this.btnCaiDat.Name = "btnCaiDat";
            this.btnCaiDat.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnCaiDat.Size = new System.Drawing.Size(40, 40);
            this.btnCaiDat.TabIndex = 2;
            // 
            // TrangChuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.pnlTop);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TrangChuForm";
            this.Text = "Form1";
            this.pnlTop.ResumeLayout(false);
            this.menuTaiKhoan.ResumeLayout(false);
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
    }
}

