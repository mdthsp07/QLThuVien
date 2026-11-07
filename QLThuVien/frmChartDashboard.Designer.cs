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
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartTheLoai = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartDuong = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartTron = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.chartTheLoai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTron)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartTheLoai
            // 
            chartArea1.AxisX.Interval = 1D;
            chartArea1.Name = "ChartArea1";
            this.chartTheLoai.ChartAreas.Add(chartArea1);
            this.tableLayoutPanel1.SetColumnSpan(this.chartTheLoai, 2);
            this.chartTheLoai.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Enabled = false;
            legend3.Name = "Legend1";
            this.chartTheLoai.Legends.Add(legend3);
            this.chartTheLoai.Location = new System.Drawing.Point(3, 3);
            this.chartTheLoai.Name = "chartTheLoai";
            this.chartTheLoai.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartTheLoai.Series.Add(series3);
            this.chartTheLoai.Size = new System.Drawing.Size(784, 281);
            this.chartTheLoai.TabIndex = 0;
            this.chartTheLoai.Text = "chart1";
            title1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            title1.Name = "Title1";
            title1.Text = "Thống kê số lượng sách theo thể loại";
            this.chartTheLoai.Titles.Add(title1);
            this.chartTheLoai.Click += new System.EventHandler(this.chartTheLoai_Click);
            // 
            // chartDuong
            // 
            chartArea3.Name = "ChartArea1";
            this.chartDuong.ChartAreas.Add(chartArea3);
            this.chartDuong.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chartDuong.Legends.Add(legend2);
            this.chartDuong.Location = new System.Drawing.Point(3, 290);
            this.chartDuong.Name = "chartDuong";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartDuong.Series.Add(series2);
            this.chartDuong.Size = new System.Drawing.Size(389, 282);
            this.chartDuong.TabIndex = 1;
            this.chartDuong.Text = "chart1";
            // 
            // chartTron
            // 
            chartArea2.Name = "ChartArea1";
            this.chartTron.ChartAreas.Add(chartArea2);
            this.chartTron.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartTron.Legends.Add(legend1);
            this.chartTron.Location = new System.Drawing.Point(398, 290);
            this.chartTron.Name = "chartTron";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartTron.Series.Add(series1);
            this.chartTron.Size = new System.Drawing.Size(389, 282);
            this.chartTron.TabIndex = 2;
            this.chartTron.Text = "chart1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.chartTheLoai, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chartTron, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.chartDuong, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(790, 575);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // frmChartDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 575);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Name = "frmChartDashboard";
            this.Text = "frmChartDashboard";
            ((System.ComponentModel.ISupportInitialize)(this.chartTheLoai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTron)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartTheLoai;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDuong;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTron;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}