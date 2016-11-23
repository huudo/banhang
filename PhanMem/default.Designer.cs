namespace PhanMem
{
    partial class Default
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnNhapHang = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBanHang = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCuoiNgay = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDoanhThu = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSanLuong = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLoiNhuan = new System.Windows.Forms.ToolStripMenuItem();
            this.btnKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.quànLýTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýNợToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNhapHang,
            this.btnBanHang,
            this.báoCáoToolStripMenuItem,
            this.btnKhachHang,
            this.quànLýTàiKhoảnToolStripMenuItem,
            this.quảnLýNợToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(927, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnNhapHang
            // 
            this.btnNhapHang.Name = "btnNhapHang";
            this.btnNhapHang.Size = new System.Drawing.Size(78, 20);
            this.btnNhapHang.Text = "Nhập hàng";
            this.btnNhapHang.Click += new System.EventHandler(this.btnNhapHang_Click);
            // 
            // btnBanHang
            // 
            this.btnBanHang.Name = "btnBanHang";
            this.btnBanHang.Size = new System.Drawing.Size(71, 20);
            this.btnBanHang.Text = "Bán Hàng";
            this.btnBanHang.Click += new System.EventHandler(this.btnBanHang_Click);
            // 
            // báoCáoToolStripMenuItem
            // 
            this.báoCáoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCuoiNgay,
            this.btnDoanhThu,
            this.btnSanLuong,
            this.btnLoiNhuan});
            this.báoCáoToolStripMenuItem.Name = "báoCáoToolStripMenuItem";
            this.báoCáoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.báoCáoToolStripMenuItem.Text = "Báo cáo";
            // 
            // btnCuoiNgay
            // 
            this.btnCuoiNgay.Name = "btnCuoiNgay";
            this.btnCuoiNgay.Size = new System.Drawing.Size(174, 22);
            this.btnCuoiNgay.Text = "Báo cáo cuối ngày";
            // 
            // btnDoanhThu
            // 
            this.btnDoanhThu.Name = "btnDoanhThu";
            this.btnDoanhThu.Size = new System.Drawing.Size(174, 22);
            this.btnDoanhThu.Text = "Báo cáo doanh thu";
            // 
            // btnSanLuong
            // 
            this.btnSanLuong.Name = "btnSanLuong";
            this.btnSanLuong.Size = new System.Drawing.Size(174, 22);
            this.btnSanLuong.Text = "Báo cáo sản lượng";
            this.btnSanLuong.Click += new System.EventHandler(this.btnSanLuong_Click);
            // 
            // btnLoiNhuan
            // 
            this.btnLoiNhuan.Name = "btnLoiNhuan";
            this.btnLoiNhuan.Size = new System.Drawing.Size(174, 22);
            this.btnLoiNhuan.Text = "Báo cáo lợi nhuận";
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Size = new System.Drawing.Size(125, 20);
            this.btnKhachHang.Text = "Quản lý khách hàng";
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            // 
            // quànLýTàiKhoảnToolStripMenuItem
            // 
            this.quànLýTàiKhoảnToolStripMenuItem.Name = "quànLýTàiKhoảnToolStripMenuItem";
            this.quànLýTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.quànLýTàiKhoảnToolStripMenuItem.Text = "Quàn lý tài khoản";
            this.quànLýTàiKhoảnToolStripMenuItem.Click += new System.EventHandler(this.quànLýTàiKhoảnToolStripMenuItem_Click);
            // 
            // quảnLýNợToolStripMenuItem
            // 
            this.quảnLýNợToolStripMenuItem.Name = "quảnLýNợToolStripMenuItem";
            this.quảnLýNợToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.quảnLýNợToolStripMenuItem.Text = "Quản Lý Nợ";
            // 
            // Default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 536);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Default";
            this.Text = "Default";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnNhapHang;
        private System.Windows.Forms.ToolStripMenuItem btnBanHang;
        private System.Windows.Forms.ToolStripMenuItem báoCáoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnCuoiNgay;
        private System.Windows.Forms.ToolStripMenuItem btnDoanhThu;
        private System.Windows.Forms.ToolStripMenuItem btnSanLuong;
        private System.Windows.Forms.ToolStripMenuItem btnLoiNhuan;
        private System.Windows.Forms.ToolStripMenuItem btnKhachHang;
        private System.Windows.Forms.ToolStripMenuItem quànLýTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýNợToolStripMenuItem;

    }
}