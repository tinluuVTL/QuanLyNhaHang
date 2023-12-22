namespace QuanLyBanHang
{
    partial class Frm_In
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
            this.rpvBanIn = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvBanIn
            // 
            this.rpvBanIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvBanIn.Location = new System.Drawing.Point(0, 0);
            this.rpvBanIn.Name = "rpvBanIn";
            this.rpvBanIn.Size = new System.Drawing.Size(687, 444);
            this.rpvBanIn.TabIndex = 0;
            // 
            // Frm_In
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 444);
            this.Controls.Add(this.rpvBanIn);
            this.Name = "Frm_In";
            this.Text = "Frm_In";
            this.Load += new System.EventHandler(this.Frm_In_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvBanIn;
    }
}