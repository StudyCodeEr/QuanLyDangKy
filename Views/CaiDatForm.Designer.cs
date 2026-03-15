namespace QuanLyDangKy.Views
{
    partial class CaiDatForm
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label = new System.Windows.Forms.Label();
            this.cmbTienTe = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tgDarkMode = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSoNgayNhac = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnResetDuLieu = new Guna.UI2.WinForms.Guna2Button();
            this.btnLuuCaiDat = new Guna.UI2.WinForms.Guna2Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderRadius = 10;
            this.guna2Panel1.Controls.Add(this.tgDarkMode);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.cmbTienTe);
            this.guna2Panel1.Controls.Add(this.label);
            this.guna2Panel1.FillColor = System.Drawing.Color.White;
            this.guna2Panel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Panel1.Location = new System.Drawing.Point(22, 105);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.BorderRadius = 10;
            this.guna2Panel1.ShadowDecoration.Depth = 10;
            this.guna2Panel1.ShadowDecoration.Enabled = true;
            this.guna2Panel1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 6, 6);
            this.guna2Panel1.Size = new System.Drawing.Size(480, 150);
            this.guna2Panel1.TabIndex = 0;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(33, 91);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(165, 28);
            this.label.TabIndex = 0;
            this.label.Text = "Tiền tệ mặc định";
            // 
            // cmbTienTe
            // 
            this.cmbTienTe.BackColor = System.Drawing.Color.Transparent;
            this.cmbTienTe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbTienTe.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTienTe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTienTe.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbTienTe.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbTienTe.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTienTe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbTienTe.ItemHeight = 30;
            this.cmbTienTe.Items.AddRange(new object[] {
            "VND",
            "USD",
            "EUR",
            "JPY",
            "GBP",
            "CNY",
            "KRW",
            "AUD"});
            this.cmbTienTe.Location = new System.Drawing.Point(246, 89);
            this.cmbTienTe.Name = "cmbTienTe";
            this.cmbTienTe.Size = new System.Drawing.Size(196, 36);
            this.cmbTienTe.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chế độ Tối";
            // 
            // tgDarkMode
            // 
            this.tgDarkMode.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tgDarkMode.CheckedState.BorderThickness = 1;
            this.tgDarkMode.CheckedState.FillColor = System.Drawing.Color.Black;
            this.tgDarkMode.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.tgDarkMode.CheckedState.InnerBorderRadius = 9;
            this.tgDarkMode.CheckedState.InnerColor = System.Drawing.Color.White;
            this.tgDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tgDarkMode.Location = new System.Drawing.Point(393, 32);
            this.tgDarkMode.Name = "tgDarkMode";
            this.tgDarkMode.Size = new System.Drawing.Size(49, 27);
            this.tgDarkMode.TabIndex = 3;
            this.tgDarkMode.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tgDarkMode.UncheckedState.BorderThickness = 1;
            this.tgDarkMode.UncheckedState.FillColor = System.Drawing.Color.White;
            this.tgDarkMode.UncheckedState.InnerBorderColor = System.Drawing.Color.LightGray;
            this.tgDarkMode.UncheckedState.InnerBorderRadius = 9;
            this.tgDarkMode.UncheckedState.InnerColor = System.Drawing.Color.Black;
            this.tgDarkMode.CheckedChanged += new System.EventHandler(this.tgDarkMode_CheckedChanged);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.BorderRadius = 10;
            this.guna2Panel2.Controls.Add(this.cmbSoNgayNhac);
            this.guna2Panel2.Controls.Add(this.label2);
            this.guna2Panel2.FillColor = System.Drawing.Color.White;
            this.guna2Panel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Panel2.Location = new System.Drawing.Point(22, 285);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.BorderRadius = 10;
            this.guna2Panel2.ShadowDecoration.Depth = 10;
            this.guna2Panel2.ShadowDecoration.Enabled = true;
            this.guna2Panel2.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 6, 6);
            this.guna2Panel2.Size = new System.Drawing.Size(480, 130);
            this.guna2Panel2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nhắc nhở trước hạn";
            // 
            // cmbSoNgayNhac
            // 
            this.cmbSoNgayNhac.BackColor = System.Drawing.Color.Transparent;
            this.cmbSoNgayNhac.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbSoNgayNhac.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSoNgayNhac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSoNgayNhac.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbSoNgayNhac.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbSoNgayNhac.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbSoNgayNhac.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbSoNgayNhac.ItemHeight = 30;
            this.cmbSoNgayNhac.Items.AddRange(new object[] {
            "0 ngày (Đúng ngày hạn)",
            "",
            "1 ngày",
            "",
            "3 ngày",
            "",
            "7 ngày",
            "",
            "-1 (Tắt thông báo)"});
            this.cmbSoNgayNhac.Location = new System.Drawing.Point(246, 50);
            this.cmbSoNgayNhac.Name = "cmbSoNgayNhac";
            this.cmbSoNgayNhac.Size = new System.Drawing.Size(196, 36);
            this.cmbSoNgayNhac.TabIndex = 5;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel3.BorderRadius = 10;
            this.guna2Panel3.Controls.Add(this.label3);
            this.guna2Panel3.Controls.Add(this.btnResetDuLieu);
            this.guna2Panel3.FillColor = System.Drawing.Color.White;
            this.guna2Panel3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Panel3.Location = new System.Drawing.Point(22, 444);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.ShadowDecoration.BorderRadius = 10;
            this.guna2Panel3.ShadowDecoration.Depth = 10;
            this.guna2Panel3.ShadowDecoration.Enabled = true;
            this.guna2Panel3.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 6, 6);
            this.guna2Panel3.Size = new System.Drawing.Size(480, 110);
            this.guna2Panel3.TabIndex = 6;
            // 
            // btnResetDuLieu
            // 
            this.btnResetDuLieu.BorderRadius = 10;
            this.btnResetDuLieu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetDuLieu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnResetDuLieu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnResetDuLieu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnResetDuLieu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnResetDuLieu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(26)))), ((int)(((byte)(42)))));
            this.btnResetDuLieu.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetDuLieu.ForeColor = System.Drawing.Color.White;
            this.btnResetDuLieu.Location = new System.Drawing.Point(247, 27);
            this.btnResetDuLieu.Name = "btnResetDuLieu";
            this.btnResetDuLieu.Size = new System.Drawing.Size(196, 59);
            this.btnResetDuLieu.TabIndex = 0;
            this.btnResetDuLieu.Text = "Khôi Phục Cài Đặt Gốc";
            this.btnResetDuLieu.Click += new System.EventHandler(this.btnResetDuLieu_Click);
            // 
            // btnLuuCaiDat
            // 
            this.btnLuuCaiDat.BorderRadius = 10;
            this.btnLuuCaiDat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuuCaiDat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLuuCaiDat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLuuCaiDat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLuuCaiDat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLuuCaiDat.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnLuuCaiDat.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuCaiDat.ForeColor = System.Drawing.Color.White;
            this.btnLuuCaiDat.Location = new System.Drawing.Point(173, 589);
            this.btnLuuCaiDat.Name = "btnLuuCaiDat";
            this.btnLuuCaiDat.Size = new System.Drawing.Size(180, 55);
            this.btnLuuCaiDat.TabIndex = 7;
            this.btnLuuCaiDat.Text = "LƯU CÀI ĐẶT";
            this.btnLuuCaiDat.Click += new System.EventHandler(this.btnLuuCaiDat_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 28);
            this.label3.TabIndex = 6;
            this.label3.Text = "Xóa dữ liệu tài khoản";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(101, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(339, 46);
            this.label4.TabIndex = 4;
            this.label4.Text = "CÀI ĐẶT HỆ THỐNG";
            // 
            // CaiDatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(532, 670);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnLuuCaiDat);
            this.Controls.Add(this.guna2Panel3);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(35, 40);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CaiDatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cài Đặt Hệ Thống";
            this.Load += new System.EventHandler(this.CaiDatForm_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label;
        private Guna.UI2.WinForms.Guna2ComboBox cmbTienTe;
        private Guna.UI2.WinForms.Guna2ToggleSwitch tgDarkMode;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2ComboBox cmbSoNgayNhac;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2Button btnResetDuLieu;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button btnLuuCaiDat;
        private System.Windows.Forms.Label label4;
    }
}