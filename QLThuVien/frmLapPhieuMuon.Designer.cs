namespace QLThuVien
{
    partial class frmLapPhieuMuon
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDocGia = new System.Windows.Forms.Label();
            this.cboDocGia = new System.Windows.Forms.ComboBox();
            this.lblNgayMuon = new System.Windows.Forms.Label();
            this.dtpNgayMuon = new System.Windows.Forms.DateTimePicker();
            this.lblThongTinDocGia = new System.Windows.Forms.Label();
            this.lblHanTra = new System.Windows.Forms.Label();
            this.dtpHanTra = new System.Windows.Forms.DateTimePicker();
            this.grpSach = new System.Windows.Forms.GroupBox();
            this.lblTimSach = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dgvSach = new System.Windows.Forms.DataGridView();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.btnThem = new System.Windows.Forms.Button();
            this.grpPhieu = new System.Windows.Forms.GroupBox();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.btnXoa = new System.Windows.Forms.Button();
            this.lblTongSach = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.panel1.SuspendLayout();
            this.grpSach.SuspendLayout();
            this.grpPhieu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTieuDe.Location = new System.Drawing.Point(12, 9);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(500, 30);
            this.lblTieuDe.Text = "LẬP PHIẾU MƯỢN SÁCH";
            this.lblTieuDe.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblDocGia);
            this.panel1.Controls.Add(this.cboDocGia);
            this.panel1.Controls.Add(this.lblNgayMuon);
            this.panel1.Controls.Add(this.dtpNgayMuon);
            this.panel1.Controls.Add(this.lblThongTinDocGia);
            this.panel1.Controls.Add(this.lblHanTra);
            this.panel1.Controls.Add(this.dtpHanTra);
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(12, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(976, 85);
            this.panel1.TabIndex = 1;
            // 
            // lblDocGia
            // 
            this.lblDocGia.AutoSize = true;
            this.lblDocGia.Location = new System.Drawing.Point(15, 18);
            this.lblDocGia.Name = "lblDocGia";
            this.lblDocGia.Size = new System.Drawing.Size(64, 16);
            this.lblDocGia.Text = "Độc giả:";
            this.lblDocGia.TabIndex = 0;
            // 
            // cboDocGia
            // 
            this.cboDocGia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocGia.FormattingEnabled = true;
            this.cboDocGia.Location = new System.Drawing.Point(135, 15);
            this.cboDocGia.Name = "cboDocGia";
            this.cboDocGia.Size = new System.Drawing.Size(320, 24);
            this.cboDocGia.TabIndex = 1;
            this.cboDocGia.SelectedIndexChanged += new System.EventHandler(this.cboDocGia_SelectedIndexChanged);
            // 
            // lblNgayMuon
            // 
            this.lblNgayMuon.AutoSize = true;
            this.lblNgayMuon.Location = new System.Drawing.Point(495, 18);
            this.lblNgayMuon.Name = "lblNgayMuon";
            this.lblNgayMuon.Size = new System.Drawing.Size(80, 16);
            this.lblNgayMuon.Text = "Ngày mượn:";
            this.lblNgayMuon.TabIndex = 2;
            // 
            // dtpNgayMuon
            // 
            this.dtpNgayMuon.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayMuon.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayMuon.Location = new System.Drawing.Point(615, 15);
            this.dtpNgayMuon.Name = "dtpNgayMuon";
            this.dtpNgayMuon.Size = new System.Drawing.Size(150, 22);
            this.dtpNgayMuon.TabIndex = 3;
            this.dtpNgayMuon.ValueChanged += new System.EventHandler(this.dtpNgayMuon_ValueChanged);
            // 
            // lblThongTinDocGia
            // 
            this.lblThongTinDocGia.ForeColor = System.Drawing.Color.DarkRed;
            this.lblThongTinDocGia.Location = new System.Drawing.Point(135, 55);
            this.lblThongTinDocGia.Name = "lblThongTinDocGia";
            this.lblThongTinDocGia.Size = new System.Drawing.Size(340, 22);
            this.lblThongTinDocGia.Text = "";
            this.lblThongTinDocGia.TabIndex = 4;
            // 
            // lblHanTra
            // 
            this.lblHanTra.AutoSize = true;
            this.lblHanTra.Location = new System.Drawing.Point(495, 53);
            this.lblHanTra.Name = "lblHanTra";
            this.lblHanTra.Size = new System.Drawing.Size(64, 16);
            this.lblHanTra.Text = "Hạn trả:";
            this.lblHanTra.TabIndex = 5;
            // 
            // dtpHanTra
            // 
            this.dtpHanTra.CustomFormat = "dd/MM/yyyy";
            this.dtpHanTra.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHanTra.Location = new System.Drawing.Point(615, 50);
            this.dtpHanTra.Name = "dtpHanTra";
            this.dtpHanTra.Size = new System.Drawing.Size(150, 22);
            this.dtpHanTra.TabIndex = 6;
            // 
            // grpSach
            // 
            this.grpSach.Controls.Add(this.lblTimSach);
            this.grpSach.Controls.Add(this.txtTimKiem);
            this.grpSach.Controls.Add(this.btnTimKiem);
            this.grpSach.Controls.Add(this.dgvSach);
            this.grpSach.Controls.Add(this.lblSoLuong);
            this.grpSach.Controls.Add(this.nudSoLuong);
            this.grpSach.Controls.Add(this.btnThem);
            this.grpSach.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            this.grpSach.Location = new System.Drawing.Point(12, 140);
            this.grpSach.Name = "grpSach";
            this.grpSach.Size = new System.Drawing.Size(580, 420);
            this.grpSach.TabStop = false;
            this.grpSach.Text = "Sách còn trong kho";
            this.grpSach.TabIndex = 2;
            // 
            // lblTimSach
            // 
            this.lblTimSach.AutoSize = true;
            this.lblTimSach.Location = new System.Drawing.Point(10, 30);
            this.lblTimSach.Name = "lblTimSach";
            this.lblTimSach.Size = new System.Drawing.Size(72, 16);
            this.lblTimSach.Text = "Tìm sách:";
            this.lblTimSach.TabIndex = 0;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(85, 27);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(380, 22);
            this.txtTimKiem.TabIndex = 1;
            this.txtTimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimKiem_KeyDown);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(475, 24);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(95, 30);
            this.btnTimKiem.Text = "Tìm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // dgvSach
            // 
            this.dgvSach.AllowUserToAddRows = false;
            this.dgvSach.AllowUserToDeleteRows = false;
            this.dgvSach.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.dgvSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSach.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSach.Location = new System.Drawing.Point(10, 62);
            this.dgvSach.MultiSelect = false;
            this.dgvSach.Name = "dgvSach";
            this.dgvSach.ReadOnly = true;
            this.dgvSach.RowHeadersWidth = 51;
            this.dgvSach.RowTemplate.Height = 24;
            this.dgvSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSach.Size = new System.Drawing.Size(560, 310);
            this.dgvSach.TabIndex = 3;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(10, 386);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(72, 16);
            this.lblSoLuong.Text = "Số lượng:";
            this.lblSoLuong.TabIndex = 4;
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            this.nudSoLuong.Location = new System.Drawing.Point(85, 383);
            this.nudSoLuong.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudSoLuong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(80, 22);
            this.nudSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSoLuong.TabIndex = 5;
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            this.btnThem.Location = new System.Drawing.Point(175, 379);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(160, 30);
            this.btnThem.Text = "Thêm vào phiếu >>";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.TabIndex = 6;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // grpPhieu
            // 
            this.grpPhieu.Controls.Add(this.dgvChiTiet);
            this.grpPhieu.Controls.Add(this.btnXoa);
            this.grpPhieu.Controls.Add(this.lblTongSach);
            this.grpPhieu.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.grpPhieu.Location = new System.Drawing.Point(602, 140);
            this.grpPhieu.Name = "grpPhieu";
            this.grpPhieu.Size = new System.Drawing.Size(386, 420);
            this.grpPhieu.TabStop = false;
            this.grpPhieu.Text = "Sách trong phiếu mượn";
            this.grpPhieu.TabIndex = 3;
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.AllowUserToDeleteRows = false;
            this.dgvChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.dgvChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTiet.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTiet.Location = new System.Drawing.Point(10, 27);
            this.dgvChiTiet.MultiSelect = false;
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.RowHeadersWidth = 51;
            this.dgvChiTiet.RowTemplate.Height = 24;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Size = new System.Drawing.Size(366, 345);
            this.dgvChiTiet.TabIndex = 0;
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            this.btnXoa.Location = new System.Drawing.Point(10, 379);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(160, 30);
            this.btnXoa.Text = "<< Bỏ khỏi phiếu";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // lblTongSach
            // 
            this.lblTongSach.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            this.lblTongSach.AutoSize = true;
            this.lblTongSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongSach.Location = new System.Drawing.Point(185, 386);
            this.lblTongSach.Name = "lblTongSach";
            this.lblTongSach.Size = new System.Drawing.Size(180, 17);
            this.lblTongSach.Text = "Tổng: 0 cuốn";
            this.lblTongSach.TabIndex = 2;
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            this.btnLuu.Location = new System.Drawing.Point(12, 572);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(170, 36);
            this.btnLuu.Text = "Lập phiếu mượn";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.TabIndex = 4;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            this.btnHuy.Location = new System.Drawing.Point(192, 572);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(120, 36);
            this.btnHuy.Text = "Làm mới";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.TabIndex = 5;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // frmLapPhieuMuon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 620);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grpSach);
            this.Controls.Add(this.grpPhieu);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnHuy);
            this.MinimumSize = new System.Drawing.Size(1018, 667);
            this.Name = "frmLapPhieuMuon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lập phiếu mượn";
            this.Load += new System.EventHandler(this.frmLapPhieuMuon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grpSach.ResumeLayout(false);
            this.grpSach.PerformLayout();
            this.grpPhieu.ResumeLayout(false);
            this.grpPhieu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDocGia;
        private System.Windows.Forms.ComboBox cboDocGia;
        private System.Windows.Forms.Label lblNgayMuon;
        private System.Windows.Forms.DateTimePicker dtpNgayMuon;
        private System.Windows.Forms.Label lblThongTinDocGia;
        private System.Windows.Forms.Label lblHanTra;
        private System.Windows.Forms.DateTimePicker dtpHanTra;
        private System.Windows.Forms.GroupBox grpSach;
        private System.Windows.Forms.Label lblTimSach;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvSach;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.GroupBox grpPhieu;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Label lblTongSach;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
    }
}
