namespace QLThuVien
{
    partial class frmTraSach
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
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.dgvPhieuMuon = new System.Windows.Forms.DataGridView();
            this.grpChiTiet = new System.Windows.Forms.GroupBox();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.GroupBox();
            this.lblMaPhieu = new System.Windows.Forms.Label();
            this.lblDocGia = new System.Windows.Forms.Label();
            this.lblHanTra = new System.Windows.Forms.Label();
            this.lblNgayTra = new System.Windows.Forms.Label();
            this.lblDonGiaPhat = new System.Windows.Forms.Label();
            this.lblSoNgayTre = new System.Windows.Forms.Label();
            this.lblTienPhat = new System.Windows.Forms.Label();
            this.txtMaPhieu = new System.Windows.Forms.TextBox();
            this.txtDocGia = new System.Windows.Forms.TextBox();
            this.txtHanTra = new System.Windows.Forms.TextBox();
            this.dtpNgayTra = new System.Windows.Forms.DateTimePicker();
            this.nudDonGiaPhat = new System.Windows.Forms.NumericUpDown();
            this.txtSoNgayTre = new System.Windows.Forms.TextBox();
            this.txtTienPhat = new System.Windows.Forms.TextBox();
            this.btnLuu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuMuon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDonGiaPhat)).BeginInit();
            this.grpChiTiet.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTieuDe.Location = new System.Drawing.Point(12, 9);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(600, 30);
            this.lblTieuDe.Text = "TRẢ SÁCH - TÍNH PHẠT QUÁ HẠN";
            this.lblTieuDe.TabIndex = 0;
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location = new System.Drawing.Point(12, 51);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(72, 16);
            this.lblTimKiem.Text = "Tìm kiếm:";
            this.lblTimKiem.TabIndex = 1;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(90, 48);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(300, 22);
            this.txtTimKiem.TabIndex = 2;
            this.txtTimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimKiem_KeyDown);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(400, 44);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(90, 30);
            this.btnTimKiem.Text = "Tìm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.TabIndex = 3;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.ForeColor = System.Drawing.Color.Red;
            this.lblGhiChu.Location = new System.Drawing.Point(510, 51);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(260, 16);
            this.lblGhiChu.Text = "Dòng màu đỏ: phiếu đã quá hạn trả";
            this.lblGhiChu.TabIndex = 4;
            // 
            // dgvPhieuMuon
            // 
            this.dgvPhieuMuon.AllowUserToAddRows = false;
            this.dgvPhieuMuon.AllowUserToDeleteRows = false;
            this.dgvPhieuMuon.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.dgvPhieuMuon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhieuMuon.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPhieuMuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuMuon.Location = new System.Drawing.Point(12, 82);
            this.dgvPhieuMuon.MultiSelect = false;
            this.dgvPhieuMuon.Name = "dgvPhieuMuon";
            this.dgvPhieuMuon.ReadOnly = true;
            this.dgvPhieuMuon.RowHeadersWidth = 51;
            this.dgvPhieuMuon.RowTemplate.Height = 24;
            this.dgvPhieuMuon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhieuMuon.Size = new System.Drawing.Size(976, 230);
            this.dgvPhieuMuon.TabIndex = 5;
            this.dgvPhieuMuon.SelectionChanged += new System.EventHandler(this.dgvPhieuMuon_SelectionChanged);
            this.dgvPhieuMuon.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPhieuMuon_CellFormatting);
            // 
            // grpChiTiet
            // 
            this.grpChiTiet.Controls.Add(this.dgvChiTiet);
            this.grpChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            this.grpChiTiet.Location = new System.Drawing.Point(12, 322);
            this.grpChiTiet.Name = "grpChiTiet";
            this.grpChiTiet.Size = new System.Drawing.Size(560, 286);
            this.grpChiTiet.TabStop = false;
            this.grpChiTiet.Text = "Sách trong phiếu";
            this.grpChiTiet.TabIndex = 6;
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.AllowUserToDeleteRows = false;
            this.dgvChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.dgvChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTiet.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTiet.Location = new System.Drawing.Point(10, 25);
            this.dgvChiTiet.MultiSelect = false;
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.RowHeadersWidth = 51;
            this.dgvChiTiet.RowTemplate.Height = 24;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Size = new System.Drawing.Size(540, 250);
            this.dgvChiTiet.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblMaPhieu);
            this.panel1.Controls.Add(this.lblDocGia);
            this.panel1.Controls.Add(this.lblHanTra);
            this.panel1.Controls.Add(this.lblNgayTra);
            this.panel1.Controls.Add(this.lblDonGiaPhat);
            this.panel1.Controls.Add(this.lblSoNgayTre);
            this.panel1.Controls.Add(this.lblTienPhat);
            this.panel1.Controls.Add(this.txtMaPhieu);
            this.panel1.Controls.Add(this.txtDocGia);
            this.panel1.Controls.Add(this.txtHanTra);
            this.panel1.Controls.Add(this.dtpNgayTra);
            this.panel1.Controls.Add(this.nudDonGiaPhat);
            this.panel1.Controls.Add(this.txtSoNgayTre);
            this.panel1.Controls.Add(this.txtTienPhat);
            this.panel1.Controls.Add(this.btnLuu);
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.panel1.Location = new System.Drawing.Point(582, 322);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(406, 286);
            this.panel1.TabStop = false;
            this.panel1.Text = "Thông tin trả sách";
            this.panel1.TabIndex = 7;
            // 
            // lblMaPhieu
            // 
            this.lblMaPhieu.AutoSize = true;
            this.lblMaPhieu.Location = new System.Drawing.Point(12, 31);
            this.lblMaPhieu.Name = "lblMaPhieu";
            this.lblMaPhieu.Size = new System.Drawing.Size(72, 16);
            this.lblMaPhieu.Text = "Mã phiếu:";
            this.lblMaPhieu.TabIndex = 0;
            // 
            // lblDocGia
            // 
            this.lblDocGia.AutoSize = true;
            this.lblDocGia.Location = new System.Drawing.Point(12, 63);
            this.lblDocGia.Name = "lblDocGia";
            this.lblDocGia.Size = new System.Drawing.Size(64, 16);
            this.lblDocGia.Text = "Độc giả:";
            this.lblDocGia.TabIndex = 1;
            // 
            // lblHanTra
            // 
            this.lblHanTra.AutoSize = true;
            this.lblHanTra.Location = new System.Drawing.Point(12, 95);
            this.lblHanTra.Name = "lblHanTra";
            this.lblHanTra.Size = new System.Drawing.Size(64, 16);
            this.lblHanTra.Text = "Hạn trả:";
            this.lblHanTra.TabIndex = 2;
            // 
            // lblNgayTra
            // 
            this.lblNgayTra.AutoSize = true;
            this.lblNgayTra.Location = new System.Drawing.Point(12, 127);
            this.lblNgayTra.Name = "lblNgayTra";
            this.lblNgayTra.Size = new System.Drawing.Size(72, 16);
            this.lblNgayTra.Text = "Ngày trả:";
            this.lblNgayTra.TabIndex = 3;
            // 
            // lblDonGiaPhat
            // 
            this.lblDonGiaPhat.AutoSize = true;
            this.lblDonGiaPhat.Location = new System.Drawing.Point(12, 159);
            this.lblDonGiaPhat.Name = "lblDonGiaPhat";
            this.lblDonGiaPhat.Size = new System.Drawing.Size(184, 16);
            this.lblDonGiaPhat.Text = "Đơn giá phạt/cuốn/ngày:";
            this.lblDonGiaPhat.TabIndex = 4;
            // 
            // lblSoNgayTre
            // 
            this.lblSoNgayTre.AutoSize = true;
            this.lblSoNgayTre.Location = new System.Drawing.Point(12, 191);
            this.lblSoNgayTre.Name = "lblSoNgayTre";
            this.lblSoNgayTre.Size = new System.Drawing.Size(96, 16);
            this.lblSoNgayTre.Text = "Số ngày trễ:";
            this.lblSoNgayTre.TabIndex = 5;
            // 
            // lblTienPhat
            // 
            this.lblTienPhat.AutoSize = true;
            this.lblTienPhat.Location = new System.Drawing.Point(12, 223);
            this.lblTienPhat.Name = "lblTienPhat";
            this.lblTienPhat.Size = new System.Drawing.Size(112, 16);
            this.lblTienPhat.Text = "Tiền phạt (đ):";
            this.lblTienPhat.TabIndex = 6;
            // 
            // txtMaPhieu
            // 
            this.txtMaPhieu.Location = new System.Drawing.Point(185, 28);
            this.txtMaPhieu.Name = "txtMaPhieu";
            this.txtMaPhieu.ReadOnly = true;
            this.txtMaPhieu.Size = new System.Drawing.Size(205, 22);
            this.txtMaPhieu.TabIndex = 7;
            // 
            // txtDocGia
            // 
            this.txtDocGia.Location = new System.Drawing.Point(185, 60);
            this.txtDocGia.Name = "txtDocGia";
            this.txtDocGia.ReadOnly = true;
            this.txtDocGia.Size = new System.Drawing.Size(205, 22);
            this.txtDocGia.TabIndex = 8;
            // 
            // txtHanTra
            // 
            this.txtHanTra.Location = new System.Drawing.Point(185, 92);
            this.txtHanTra.Name = "txtHanTra";
            this.txtHanTra.ReadOnly = true;
            this.txtHanTra.Size = new System.Drawing.Size(205, 22);
            this.txtHanTra.TabIndex = 9;
            // 
            // dtpNgayTra
            // 
            this.dtpNgayTra.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayTra.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayTra.Location = new System.Drawing.Point(185, 124);
            this.dtpNgayTra.Name = "dtpNgayTra";
            this.dtpNgayTra.Size = new System.Drawing.Size(205, 22);
            this.dtpNgayTra.TabIndex = 10;
            this.dtpNgayTra.ValueChanged += new System.EventHandler(this.TinhPhatXemTruoc);
            // 
            // nudDonGiaPhat
            // 
            this.nudDonGiaPhat.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudDonGiaPhat.Location = new System.Drawing.Point(185, 156);
            this.nudDonGiaPhat.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudDonGiaPhat.Name = "nudDonGiaPhat";
            this.nudDonGiaPhat.Size = new System.Drawing.Size(205, 22);
            this.nudDonGiaPhat.ThousandsSeparator = true;
            this.nudDonGiaPhat.TabIndex = 11;
            this.nudDonGiaPhat.ValueChanged += new System.EventHandler(this.TinhPhatXemTruoc);
            // 
            // txtSoNgayTre
            // 
            this.txtSoNgayTre.Location = new System.Drawing.Point(185, 188);
            this.txtSoNgayTre.Name = "txtSoNgayTre";
            this.txtSoNgayTre.ReadOnly = true;
            this.txtSoNgayTre.Size = new System.Drawing.Size(205, 22);
            this.txtSoNgayTre.TabIndex = 12;
            // 
            // txtTienPhat
            // 
            this.txtTienPhat.Location = new System.Drawing.Point(185, 220);
            this.txtTienPhat.Name = "txtTienPhat";
            this.txtTienPhat.ReadOnly = true;
            this.txtTienPhat.Size = new System.Drawing.Size(205, 22);
            this.txtTienPhat.TabIndex = 13;
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(185, 245);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(205, 32);
            this.btnLuu.Text = "Xác nhận trả sách";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.TabIndex = 14;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // frmTraSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 620);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.lblTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.dgvPhieuMuon);
            this.Controls.Add(this.grpChiTiet);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(1018, 667);
            this.Name = "frmTraSach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trả sách";
            this.Load += new System.EventHandler(this.frmTraSach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuMuon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDonGiaPhat)).EndInit();
            this.grpChiTiet.ResumeLayout(false);
            this.grpChiTiet.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.DataGridView dgvPhieuMuon;
        private System.Windows.Forms.GroupBox grpChiTiet;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.GroupBox panel1;
        private System.Windows.Forms.Label lblMaPhieu;
        private System.Windows.Forms.Label lblDocGia;
        private System.Windows.Forms.Label lblHanTra;
        private System.Windows.Forms.Label lblNgayTra;
        private System.Windows.Forms.Label lblDonGiaPhat;
        private System.Windows.Forms.Label lblSoNgayTre;
        private System.Windows.Forms.Label lblTienPhat;
        private System.Windows.Forms.TextBox txtMaPhieu;
        private System.Windows.Forms.TextBox txtDocGia;
        private System.Windows.Forms.TextBox txtHanTra;
        private System.Windows.Forms.DateTimePicker dtpNgayTra;
        private System.Windows.Forms.NumericUpDown nudDonGiaPhat;
        private System.Windows.Forms.TextBox txtSoNgayTre;
        private System.Windows.Forms.TextBox txtTienPhat;
        private System.Windows.Forms.Button btnLuu;
    }
}
