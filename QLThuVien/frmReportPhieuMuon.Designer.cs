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
            this.SuspendLayout();
            // 
            // reportViewerPhieuMuon
            // 
            this.reportViewerPhieuMuon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerPhieuMuon.LocalReport.ReportEmbeddedResource = "QLThuVien.rptPhieuMuon.rdlc";
            this.reportViewerPhieuMuon.Location = new System.Drawing.Point(0, 0);
            this.reportViewerPhieuMuon.Name = "reportViewerPhieuMuon";
            this.reportViewerPhieuMuon.ServerReport.BearerToken = null;
            this.reportViewerPhieuMuon.Size = new System.Drawing.Size(800, 450);
            this.reportViewerPhieuMuon.TabIndex = 0;
            // 
            // frmReportPhieuMuon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewerPhieuMuon);
            this.Name = "frmReportPhieuMuon";
            this.Text = "frmReportPhieuMuon";
            this.Load += new System.EventHandler(this.frmReportPhieuMuon_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerPhieuMuon;
    }
}