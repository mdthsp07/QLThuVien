namespace QLThuVien
{
    partial class frmChartDashboard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chartTheLoai = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartTheLoai)).BeginInit();
            this.SuspendLayout();
            // 
            // chartTheLoai
            // 
            chartArea1.AxisX.Interval = 1D;
            chartArea1.Name = "ChartArea1";
            this.chartTheLoai.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chartTheLoai.Legends.Add(legend1);
            this.chartTheLoai.Location = new System.Drawing.Point(-3, 0);
            this.chartTheLoai.Name = "chartTheLoai";
            this.chartTheLoai.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartTheLoai.Series.Add(series1);
            this.chartTheLoai.Size = new System.Drawing.Size(907, 509);
            this.chartTheLoai.TabIndex = 0;
            this.chartTheLoai.Text = "chart1";
            title1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            title1.Name = "Title1";
            title1.Text = "Thống kê số lượng sách theo thể loại";
            this.chartTheLoai.Titles.Add(title1);
            // 
            // frmChartDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 506);
            this.Controls.Add(this.chartTheLoai);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Name = "frmChartDashboard";
            this.Text = "frmChartDashboard";
            ((System.ComponentModel.ISupportInitialize)(this.chartTheLoai)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartTheLoai;
    }
}