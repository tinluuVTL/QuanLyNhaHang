namespace QuanLyBanHang
{
    partial class Frm_Main
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
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.danhMụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnKhuVuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnMatHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnLoaiHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnHoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(230, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 42);
            this.label1.TabIndex = 3;
            this.label1.Text = "Quản lý Bán Hàng";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.danhMụcToolStripMenuItem,
            this.mnThoat});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(869, 25);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // danhMụcToolStripMenuItem
            // 
            this.danhMụcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnKhuVuc,
            this.mnNhanVien,
            this.mnMatHang,
            this.mnKhachHang,
            this.mnLoaiHang,
            this.mnHoaDon});
            this.danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
            this.danhMụcToolStripMenuItem.Size = new System.Drawing.Size(78, 21);
            this.danhMụcToolStripMenuItem.Text = "Danh mục";
            // 
            // mnKhuVuc
            // 
            this.mnKhuVuc.Name = "mnKhuVuc";
            this.mnKhuVuc.Size = new System.Drawing.Size(146, 24);
            this.mnKhuVuc.Text = "Khu vực";
            this.mnKhuVuc.Click += new System.EventHandler(this.mnKhuVuc_Click);
            // 
            // mnNhanVien
            // 
            this.mnNhanVien.Name = "mnNhanVien";
            this.mnNhanVien.Size = new System.Drawing.Size(146, 24);
            this.mnNhanVien.Text = "Nhân Viên";
            this.mnNhanVien.Click += new System.EventHandler(this.mnNhanVien_Click);
            // 
            // mnMatHang
            // 
            this.mnMatHang.Name = "mnMatHang";
            this.mnMatHang.Size = new System.Drawing.Size(146, 24);
            this.mnMatHang.Text = "Mặt hàng";
            this.mnMatHang.Click += new System.EventHandler(this.mnMatHang_Click);
            // 
            // mnKhachHang
            // 
            this.mnKhachHang.Name = "mnKhachHang";
            this.mnKhachHang.Size = new System.Drawing.Size(146, 24);
            this.mnKhachHang.Text = "Khách hàng";
            this.mnKhachHang.Click += new System.EventHandler(this.mnKhachHang_Click);
            // 
            // mnLoaiHang
            // 
            this.mnLoaiHang.Name = "mnLoaiHang";
            this.mnLoaiHang.Size = new System.Drawing.Size(146, 24);
            this.mnLoaiHang.Text = "Loại Hàng";
            this.mnLoaiHang.Click += new System.EventHandler(this.mnLoaiHang_Click);
            // 
            // mnHoaDon
            // 
            this.mnHoaDon.Name = "mnHoaDon";
            this.mnHoaDon.Size = new System.Drawing.Size(146, 24);
            this.mnHoaDon.Text = "Hóa đơn";
            this.mnHoaDon.Click += new System.EventHandler(this.mnHoaDon_Click);
            // 
            // mnThoat
            // 
            this.mnThoat.Name = "mnThoat";
            this.mnThoat.Size = new System.Drawing.Size(53, 21);
            this.mnThoat.Text = "Thoát";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(534, 454);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 26);
            this.label4.TabIndex = 5;
            this.label4.Text = "Lớp: 20CT112";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(534, 410);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tên: Lưu Văn Tín";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(534, 366);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 26);
            this.label2.TabIndex = 7;
            this.label2.Text = "MSSV: 120001347";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 608);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "Frm_Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem danhMụcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnKhuVuc;
        private System.Windows.Forms.ToolStripMenuItem mnNhanVien;
        private System.Windows.Forms.ToolStripMenuItem mnMatHang;
        private System.Windows.Forms.ToolStripMenuItem mnKhachHang;
        private System.Windows.Forms.ToolStripMenuItem mnLoaiHang;
        private System.Windows.Forms.ToolStripMenuItem mnHoaDon;
        private System.Windows.Forms.ToolStripMenuItem mnThoat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

