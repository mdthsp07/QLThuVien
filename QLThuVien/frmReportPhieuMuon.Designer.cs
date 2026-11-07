namespace QLThuVien
{
    partial class frmReportPhieuMuon
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
            this.reportViewerPhieuMuon = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaPhieu = new System.Windows.Forms.TextBox();
            this.btnIn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportViewerPhieuMuon
            // 
            this.reportViewerPhieuMuon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewerPhieuMuon.LocalReport.ReportEmbeddedResource = "QLThuVien.rptPhieuMuon.rdlc";
            this.reportViewerPhieuMuon.Location = new System.Drawing.Point(0, 64);
            this.reportViewerPhieuMuon.Name = "reportViewerPhieuMuon";
            this.reportViewerPhieuMuon.ServerReport.BearerToken = null;
            this.reportViewerPhieuMuon.Size = new System.Drawing.Size(800, 388);
            this.reportViewerPhieuMuon.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnIn);
            this.panel1.Controls.Add(this.txtMaPhieu);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 64);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nhập Mã Phiếu:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtMaPhieu
            // 
            this.txtMaPhieu.Location = new System.Drawing.Point(185, 22);
            this.txtMaPhieu.Name = "txtMaPhieu";
            this.txtMaPhieu.Size = new System.Drawing.Size(440, 22);
            this.txtMaPhieu.TabIndex = 3;
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(644, 23);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(133, 23);
            this.btnIn.TabIndex = 4;
            this.btnIn.Text = "In Báo Cáo";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // frmReportPhieuMuon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.reportViewerPhieuMuon);
            this.Name = "frmReportPhieuMuon";
            this.Text = "frmReportPhieuMuon";
            this.Load += new System.EventHandler(this.frmReportPhieuMuon_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerPhieuMuon;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.TextBox txtMaPhieu;
    }
}