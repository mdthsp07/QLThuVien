
CREATE DATABASE QLThuVien;
GO
USE QLThuVien;
GO

CREATE TABLE VaiTro (
    MaVaiTro INT PRIMARY KEY,
    TenVaiTro NVARCHAR(50)
);

CREATE TABLE ChucNang (
    MaChucNang INT PRIMARY KEY,
    TenChucNang NVARCHAR(100)
);

CREATE TABLE PhanQuyen (
    MaVaiTro INT FOREIGN KEY REFERENCES VaiTro(MaVaiTro),
    MaChucNang INT FOREIGN KEY REFERENCES ChucNang(MaChucNang),
    PRIMARY KEY (MaVaiTro, MaChucNang)
);

CREATE TABLE NguoiDung (
    MaND INT IDENTITY(1,1) PRIMARY KEY,
    TenDangNhap VARCHAR(50) UNIQUE,
    MatKhau NVARCHAR(200),
    HoTen NVARCHAR(100),
    MaVaiTro INT FOREIGN KEY REFERENCES VaiTro(MaVaiTro)
);

CREATE TABLE TheLoai (
    MaTheLoai INT IDENTITY(1,1) PRIMARY KEY,
    TenTheLoai NVARCHAR(100)
);

CREATE TABLE NhaXuatBan (
    MaNXB INT IDENTITY(1,1) PRIMARY KEY,
    TenNXB NVARCHAR(150),
    DiaChi NVARCHAR(200),
    SoDienThoai VARCHAR(15)
);

CREATE TABLE Sach (
    MaSach INT IDENTITY(1,1) PRIMARY KEY,
    TenSach NVARCHAR(200),
    TacGia NVARCHAR(100),
    MaTheLoai INT FOREIGN KEY REFERENCES TheLoai(MaTheLoai),
    MaNXB INT FOREIGN KEY REFERENCES NhaXuatBan(MaNXB),
    NamXuatBan INT,
    SoLuongTong INT,
    SoLuongCon INT
);

CREATE TABLE DocGia (
    MaDocGia INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100),
    NgaySinh DATE,
    DiaChi NVARCHAR(200),
    SoDienThoai VARCHAR(15),
    Email VARCHAR(100),
    LoaiDocGia NVARCHAR(50)
);

CREATE TABLE PhieuMuon (
    MaPhieu INT IDENTITY(1,1) PRIMARY KEY,
    MaDocGia INT FOREIGN KEY REFERENCES DocGia(MaDocGia),
    NgayMuon DATE,
    HanTra DATE,
    NgayTraThucTe DATE,
    TrangThai NVARCHAR(20)
);

CREATE TABLE ChiTietMuon (
    MaPhieu INT FOREIGN KEY REFERENCES PhieuMuon(MaPhieu),
    MaSach INT FOREIGN KEY REFERENCES Sach(MaSach),
    SoLuong INT,
    PRIMARY KEY (MaPhieu, MaSach)
);

CREATE TABLE DatTruoc (
    MaDatTruoc INT IDENTITY(1,1) PRIMARY KEY,
    MaDocGia INT FOREIGN KEY REFERENCES DocGia(MaDocGia),
    MaSach INT FOREIGN KEY REFERENCES Sach(MaSach),
    NgayDat DATE,
    TrangThai NVARCHAR(20)
);

CREATE TABLE Phat (
    MaPhat INT IDENTITY(1,1) PRIMARY KEY,
    MaPhieu INT FOREIGN KEY REFERENCES PhieuMuon(MaPhieu),
    SoNgayTre INT,
    DonGiaPhat DECIMAL(18,0),
    SoTien DECIMAL(18,0),
    LyDo NVARCHAR(200),
    NgayPhat DATE,
    TrangThaiThanhToan NVARCHAR(20)
);
GO

INSERT INTO VaiTro VALUES 
(1, N'Quản trị viên (Admin)'), 
(2, N'Thủ thư'), 
(3, N'Độc giả');

INSERT INTO ChucNang VALUES 
(1, N'Quản lý Sách'), (2, N'Quản lý Độc giả'), (3, N'Lập phiếu mượn'),
(4, N'Báo cáo - Thống kê'), (5, N'Quản lý Tài khoản'),
(6, N'Quản lý Thể loại'), (7, N'Quản lý Nhà xuất bản'),
(8, N'Trả sách'), (9, N'Đặt trước'), (10, N'Quản lý Phạt');

INSERT INTO PhanQuyen VALUES 
(1,1),(1,2),(1,3),(1,4),(1,5),(1,6),(1,7),(1,8),(1,9),(1,10),  
(2,1),(2,2),(2,3),(2,8);                                          


INSERT INTO NguoiDung (TenDangNhap, MatKhau, HoTen, MaVaiTro) VALUES 
('admin',     CONVERT(NVARCHAR(64), HASHBYTES('SHA2_256', '123' + 'admin'), 2),     N'Nguyễn Quản Trị', 1),
('thuthu01',  CONVERT(NVARCHAR(64), HASHBYTES('SHA2_256', '123' + 'thuthu01'), 2),  N'Trần Thị Thủ Thư', 2),
('docgia01',  CONVERT(NVARCHAR(64), HASHBYTES('SHA2_256', '123' + 'docgia01'), 2),  N'Lê Văn Độc Giả', 3);


INSERT INTO TheLoai (TenTheLoai) VALUES 
(N'Công nghệ thông tin'), (N'Kinh tế'), (N'Văn học'), (N'Kỹ năng sống');

INSERT INTO NhaXuatBan (TenNXB, DiaChi, SoDienThoai) VALUES 
(N'NXB Bách Khoa', N'Hà Nội', '02438684566'),
(N'NXB Trẻ',       N'TP.HCM', '02838234227'),
(N'NXB Văn Học',   N'Hà Nội', '02438229922'),
(N'NXB Lao Động',  N'Hà Nội', '02438257467');


INSERT INTO Sach (TenSach, TacGia, MaTheLoai, MaNXB, NamXuatBan, SoLuongTong, SoLuongCon) VALUES 
(N'Lập trình C# căn bản', N'Phạm Hữu Khang', 1, 1, 2022, 50, 49),  
(N'Clean Code', N'Robert C. Martin', 1, 2, 2020, 20, 20),
(N'SQL Server 2019', N'Đỗ Mạnh Hùng', 1, 1, 2021, 30, 30),
(N'Kinh tế vi mô', N'NXB Kinh Tế', 2, 4, 2019, 15, 15),
(N'Cha giàu cha nghèo', N'Robert Kiyosaki', 2, 2, 2018, 40, 40),
(N'Nhà giả kim', N'Paulo Coelho', 3, 3, 2017, 25, 25),
(N'Số đỏ', N'Vũ Trọng Phụng', 3, 3, 2015, 10, 10),
(N'Đắc nhân tâm', N'Dale Carnegie', 4, 2, 2019, 60, 60),
(N'Lập trình WinForms', N'Nguyễn Văn A', 1, 1, 2023, 10, 10),
(N'Cấu trúc dữ liệu và giải thuật', N'Nguyễn Đức Nghĩa', 1, 1, 2020, 35, 35);


INSERT INTO DocGia (HoTen, NgaySinh, DiaChi, SoDienThoai, Email, LoaiDocGia) VALUES 
(N'Lê Văn Độc Giả', '2000-01-15', N'Hà Nội',    '0912345678', 'levan@gmail.com', N'Sinh viên'),
(N'Nguyễn Thị B',   '1999-05-20', N'Hà Nội',    '0987654321', 'thib@gmail.com',  N'Sinh viên'),
(N'Trần Văn C',     '1995-10-30', N'Hải Phòng', '0905123456', 'vanc@gmail.com',  N'Giáo viên'),
(N'Hoàng Thị D',    '2001-03-12', N'Đà Nẵng',   '0333456789', 'thid@gmail.com',  N'Sinh viên'),
(N'Đặng Văn E',     '1985-07-08', N'TP.HCM',    '0777888999', 'vane@gmail.com',  N'Khách');


INSERT INTO PhieuMuon (MaDocGia, NgayMuon, HanTra, NgayTraThucTe, TrangThai) VALUES 
(1, '2024-01-15', '2024-01-22', '2024-01-20', 'DaTra'),      
(2, '2024-01-20', '2024-01-27', '2024-01-27', 'DaTra'),      
(3, '2024-02-10', '2024-02-17', '2024-02-20', 'DaTra'),     
(1, '2024-03-05', '2024-03-12', '2024-03-10', 'DaTra'),      
(4, '2024-03-15', '2024-03-22', NULL,         'DangMuon');  


INSERT INTO ChiTietMuon (MaPhieu, MaSach, SoLuong) VALUES 
(1, 1, 2), (1, 2, 1),
(2, 5, 1),
(3, 8, 3),
(4, 4, 1), (4, 6, 2),
(5, 1, 1);


INSERT INTO Phat (MaPhieu, SoNgayTre, DonGiaPhat, SoTien, LyDo, NgayPhat, TrangThaiThanhToan) VALUES 
(3, 3, 5000, 15000, N'Trả trễ 3 ngày', '2024-02-20', N'DaThanhToan');


INSERT INTO DatTruoc (MaDocGia, MaSach, NgayDat, TrangThai) VALUES 
(5, 2, '2024-03-20', 'ChoXuLy');
GO