using System;
using System.ComponentModel;

namespace QLThuVien.Repositories
{
    /// <summary>
    /// Các hằng trạng thái dùng chung cho nghiệp vụ mượn - trả - đặt trước - phạt.
    /// </summary>
    public static class TrangThai
    {
        public const string DangMuon = "Đang mượn";
        public const string DaTra = "Đã trả";

        public const string DangCho = "Đang chờ";
        public const string DaNhan = "Đã nhận";
        public const string DaHuy = "Đã hủy";

        public const string ChuaThanhToan = "Chưa thanh toán";
        public const string DaThanhToan = "Đã thanh toán";
    }

    // =====================================================================
    // Các lớp hiển thị (kết quả của câu lệnh LINQ "select new ...View")
    // dùng để đổ vào DataGridView. [DisplayName] = tiêu đề cột,
    // [Browsable(false)] = ẩn cột khỏi lưới nhưng vẫn lấy được qua DataBoundItem.
    // =====================================================================

    public class TheLoaiView
    {
        [DisplayName("Mã thể loại")] public int MaTheLoai { get; set; }
        [DisplayName("Tên thể loại")] public string TenTheLoai { get; set; }
        [DisplayName("Số đầu sách")] public int SoDauSach { get; set; }
    }

    public class NhaXuatBanView
    {
        [DisplayName("Mã NXB")] public int MaNXB { get; set; }
        [DisplayName("Tên nhà xuất bản")] public string TenNXB { get; set; }
        [DisplayName("Địa chỉ")] public string DiaChi { get; set; }
        [DisplayName("Số điện thoại")] public string SoDienThoai { get; set; }
        [DisplayName("Số đầu sách")] public int SoDauSach { get; set; }
    }

    public class SachView
    {
        [DisplayName("Mã sách")] public int MaSach { get; set; }
        [DisplayName("Tên sách")] public string TenSach { get; set; }
        [DisplayName("Tác giả")] public string TacGia { get; set; }
        [Browsable(false)] public int? MaTheLoai { get; set; }
        [DisplayName("Thể loại")] public string TenTheLoai { get; set; }
        [Browsable(false)] public int? MaNXB { get; set; }
        [DisplayName("Nhà xuất bản")] public string TenNXB { get; set; }
        [DisplayName("Năm XB")] public int? NamXuatBan { get; set; }
        [DisplayName("SL tổng")] public int? SoLuongTong { get; set; }
        [DisplayName("SL còn")] public int? SoLuongCon { get; set; }

        /// <summary>Chuỗi hiển thị trong ComboBox (ẩn trên lưới bằng code).</summary>
        [DisplayName("Hiển thị")]
        public string TenHienThi => $"{TenSach} (còn {SoLuongCon ?? 0})";
    }

    public class DocGiaView
    {
        [DisplayName("Mã độc giả")] public int MaDocGia { get; set; }
        [DisplayName("Họ tên")] public string HoTen { get; set; }
        [DisplayName("Ngày sinh")] public DateTime? NgaySinh { get; set; }
        [DisplayName("Địa chỉ")] public string DiaChi { get; set; }
        [DisplayName("Số điện thoại")] public string SoDienThoai { get; set; }
        [DisplayName("Email")] public string Email { get; set; }
        [DisplayName("Loại độc giả")] public string LoaiDocGia { get; set; }
        [DisplayName("Sách đang mượn")] public int SoSachDangMuon { get; set; }
    }

    public class PhieuMuonView
    {
        [DisplayName("Mã phiếu")] public int MaPhieu { get; set; }
        [Browsable(false)] public int? MaDocGia { get; set; }
        [DisplayName("Độc giả")] public string HoTen { get; set; }
        [DisplayName("Ngày mượn")] public DateTime? NgayMuon { get; set; }
        [DisplayName("Hạn trả")] public DateTime? HanTra { get; set; }
        [DisplayName("Ngày trả")] public DateTime? NgayTraThucTe { get; set; }
        [DisplayName("Trạng thái")] public string TrangThai { get; set; }
        [DisplayName("Tổng số sách")] public int TongSoSach { get; set; }

        [DisplayName("Số ngày quá hạn")]
        public int SoNgayQuaHan
        {
            get
            {
                if (HanTra == null) return 0;
                DateTime moc = NgayTraThucTe ?? DateTime.Today;
                int soNgay = (moc.Date - HanTra.Value.Date).Days;
                return soNgay > 0 ? soNgay : 0;
            }
        }

        /// <summary>Chuỗi hiển thị trong ComboBox (ẩn trên lưới bằng code).</summary>
        [DisplayName("Hiển thị")]
        public string TenHienThi => $"Phiếu {MaPhieu} - {HoTen} ({TrangThai})";
    }

    public class ChiTietMuonView
    {
        [DisplayName("Mã sách")] public int MaSach { get; set; }
        [DisplayName("Tên sách")] public string TenSach { get; set; }
        [DisplayName("Tác giả")] public string TacGia { get; set; }
        [DisplayName("Số lượng")] public int SoLuong { get; set; }
    }

    public class DatTruocView
    {
        [DisplayName("Mã đặt")] public int MaDatTruoc { get; set; }
        [Browsable(false)] public int? MaDocGia { get; set; }
        [DisplayName("Độc giả")] public string HoTen { get; set; }
        [Browsable(false)] public int? MaSach { get; set; }
        [DisplayName("Tên sách")] public string TenSach { get; set; }
        [DisplayName("SL còn")] public int? SoLuongCon { get; set; }
        [DisplayName("Ngày đặt")] public DateTime? NgayDat { get; set; }
        [DisplayName("Trạng thái")] public string TrangThai { get; set; }
    }

    public class PhatView
    {
        [DisplayName("Mã phạt")] public int MaPhat { get; set; }
        [DisplayName("Mã phiếu")] public int? MaPhieu { get; set; }
        [DisplayName("Độc giả")] public string HoTen { get; set; }
        [DisplayName("Số ngày trễ")] public int? SoNgayTre { get; set; }
        [DisplayName("Đơn giá phạt")] public decimal? DonGiaPhat { get; set; }
        [DisplayName("Số tiền")] public decimal? SoTien { get; set; }
        [DisplayName("Lý do")] public string LyDo { get; set; }
        [DisplayName("Ngày phạt")] public DateTime? NgayPhat { get; set; }
        [DisplayName("Thanh toán")] public string TrangThaiThanhToan { get; set; }
    }

    /// <summary>Một dòng trong "giỏ" sách khi lập phiếu mượn.</summary>
    public class GioMuonItem
    {
        [DisplayName("Mã sách")] public int MaSach { get; set; }
        [DisplayName("Tên sách")] public string TenSach { get; set; }
        [DisplayName("Số lượng")] public int SoLuong { get; set; }
    }
}
