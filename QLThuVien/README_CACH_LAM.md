# HƯỚNG DẪN DÀNH CHO M2, M3, M4 (Đọc kỹ trước khi code)

Chào các bạn, M1 đã dựng xong bộ khung Core. Mọi người làm đúng theo kiến trúc sau nhé:

## 1. Dành cho M2 (Hệ thống, Bảo mật & RBAC)
- **Đăng nhập:** Dùng `NguoiDungRepository.GetByTenDangNhap()`. Mật khẩu dưới DB đã được hash SHA-256 (Salt = TenDangNhap). Code verify: `HashPassword(pass, user) == user.MatKhau`.
- **Phân quyền:** Đã có sẵn hàm `PhanQuyenHelper.CoQuyen("Tên Chức Năng", MaVaiTro)` trong thư mục Helpers. Chỉ cần gọi trong `frmMain_Load` để ẩn/hiện menu.

## 2. Dành cho M3 (Danh mục & Nghiệp vụ)
- **Làm form CRUD:** Đã có sẵn `frmMauCRUD`. Hãy copy form này, đổi tên thành `frmQuanLySach`, `frmQuanLyDocGia`... 
- **Gọi dữ liệu:** Không viết LINQ trong Form. Hãy gọi qua Repository. VD: `new SachRepository().GetAll()`.
- **Nghiệp vụ mượn sách:** Dùng hàm `new PhieuMuonRepository().LapPhieuMuon(phieu, listChiTiet)`. Hàm này đã tích hợp sẵn `TransactionScope`, tự động kiểm tra tồn kho và rollback nếu lỗi.

## 3. Dành cho M4 (Report & Chart)
- **Lấy số liệu:** Vào thư mục Repositories, viết thêm các hàm LINQ `GroupBy`, `Sum` (VD: viết trong `SachRepository`) để lấy data đổ vào Chart.
- **Report:** Dùng dữ liệu từ Repository để đẩy vào `ReportDataSource`.

## 4. M3 đã làm (Danh mục & Nghiệp vụ)
- **8 form** (đều theo bố cục `frmMauCRUD`: `panel1` nhập liệu + Thêm/Sửa/Xóa/Lưu + `dgvData`): `frmQuanLySach`, `frmQuanLyDocGia`, `frmQuanLyTheLoai`, `frmQuanLyNhaXuatBan`, `frmLapPhieuMuon`, `frmTraSach`, `frmDatTruoc`, `frmQuanLyPhat`. Mở từ menu **Danh mục** / **Nghiệp vụ** của `frmMain`.
- **Repository mới:** `TheLoaiRepository`, `NhaXuatBanRepository`, `DatTruocRepository`, `PhatRepository`; các lớp hiển thị lưới nằm trong `Repositories/ViewModels.cs` (truy vấn LINQ `select new ...View`).
- **Trả sách:** `PhieuMuonRepository.TraSach(maPhieu, ngayTra, donGia)` chạy trong `TransactionScope`: cập nhật phiếu → cộng lại tồn kho → tự lập `Phat` nếu quá hạn (tiền = số ngày trễ × đơn giá × số cuốn).
- **Quy tắc:** mượn tối đa 5 cuốn, hạn mặc định 14 ngày, phạt 5.000đ/cuốn/ngày (hằng số trong `PhieuMuonRepository`); độc giả có phiếu quá hạn hoặc nợ phạt không được mượn; chỉ đặt trước được sách đã hết; lập phiếu mượn tự chuyển đặt trước của độc giả sang "Đã nhận".
- **Phân quyền:** Thể loại/NXB dùng quyền "Quản lý Sách"; Trả sách/Đặt trước/Phạt dùng quyền "Lập phiếu mượn".
- Mỗi thao tác ghi dữ liệu trong form tạo `new XxxRepository()` mới để DataContext luôn sạch (nhất là sau khi transaction bị rollback).
