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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnMoDangNhap = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.Controls.Add(this.btnMoDangNhap);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(800, 50);
            this.guna2Panel1.TabIndex = 0;
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
            this.btnMoDangNhap.Location = new System.Drawing.Point(704, 3);
            this.btnMoDangNhap.Name = "btnMoDangNhap";
            this.btnMoDangNhap.Size = new System.Drawing.Size(96, 44);
            this.btnMoDangNhap.TabIndex = 0;
            this.btnMoDangNhap.Text = "ĐĂNG NHẬP";
            this.btnMoDangNhap.Click += new System.EventHandler(this.btnMoDangNhap_Click);
            // 
            // TrangChuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "TrangChuForm";
            this.Text = "Form1";
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnMoDangNhap;
    }
}

