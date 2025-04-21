-- Tạo CSDL
CREATE DATABASE QLKhachSan;
GO
USE QLKhachSan;
GO
-- Drop Database
DROP DATABASE QL_KhachSan
-- Bảng chức vụ
CREATE TABLE CHUCVU (
    MaChucVu NVARCHAR(5) PRIMARY KEY,
    TenChucVu NVARCHAR(30) NOT NULL,
    LUONG INT NOT NULL
);

-- Bảng nhân viên
CREATE TABLE NHANVIEN (
    MaNhanVien NVARCHAR(5) PRIMARY KEY,
    MaChucVu NVARCHAR(5) NOT NULL,
    HoTen NVARCHAR(30) NOT NULL,
    GioiTinh NVARCHAR(3) NOT NULL CHECK (GioiTinh IN (N'Nam', N'Nữ')),
    NgaySinh DATE NOT NULL,
    SoDienThoai NVARCHAR(10) NOT NULL,
    DiaChi NVARCHAR(100),
    FOREIGN KEY (MaChucVu) REFERENCES CHUCVU(MaChucVu)
);

-- Bảng tài khoản
CREATE TABLE TAIKHOAN (
    MaTaiKhoan NVARCHAR(5) PRIMARY KEY,
    TenDangNhap NVARCHAR(20) NOT NULL,
    MatKhau NVARCHAR(20) NOT NULL,
    MaNhanVien NVARCHAR(5) NOT NULL,
    VaiTro NVARCHAR(10) NOT NULL CHECK (VaiTro IN (N'admin', N'lễ tân')),
    FOREIGN KEY (MaNhanVien) REFERENCES NHANVIEN(MaNhanVien)
);

-- Bảng khách hàng
CREATE TABLE KHACHHANG (
    MaKhachHang NVARCHAR(5) PRIMARY KEY,
    HoTen NVARCHAR(30) NOT NULL,
    GioiTinh NVARCHAR(3) NOT NULL CHECK (GioiTinh IN (N'Nam', N'Nữ')),
    NgaySinh DATE NOT NULL,
    SoDienThoai NVARCHAR(10) NOT NULL,
    CCCD NVARCHAR(12) NOT NULL,
    Email NVARCHAR(50),
    DiaChi NVARCHAR(100)
);

-- Bảng loại phòng
CREATE TABLE LOAIPHONG (
    MaLoaiPhong NVARCHAR(5) PRIMARY KEY,
    TenLoaiPhong NVARCHAR(30) NOT NULL,
    GiaPhong INT NOT NULL,
    MoTa NVARCHAR(100)
);
SELECT * FROM LOAIPHONG;
-- Bảng phòng
CREATE TABLE PHONG (
    MaPhong NVARCHAR(10) PRIMARY KEY,
    SoPhong NVARCHAR(5) NOT NULL,
    MaLoaiPhong NVARCHAR(5) NOT NULL,
    TrangThai NVARCHAR(20),
    FOREIGN KEY (MaLoaiPhong) REFERENCES LOAIPHONG(MaLoaiPhong)
);

-- Bảng dịch vụ
CREATE TABLE DICHVU (
    MaDichVu NVARCHAR(10) PRIMARY KEY,
    TenDichVu NVARCHAR(50) NOT NULL,
    GiaDichVu INT NOT NULL,
    MoTa NVARCHAR(100)
);

-- Bảng đặt phòng
CREATE TABLE DATPHONG (
    MaDatPhong NVARCHAR(10) PRIMARY KEY,
    MaKhachHang NVARCHAR(5) NOT NULL,
    MaPhong NVARCHAR(5) NOT NULL,
    NgayDat DATE NOT NULL,
    NgayNhanPhong DATE NOT NULL,
    NgayTraPhong DATE,
    TrangThai NVARCHAR(20),
    FOREIGN KEY (MaKhachHang) REFERENCES KHACHHANG(MaKhachHang),
    FOREIGN KEY (MaPhong) REFERENCES PHONG(MaPhong)
);

-- Bảng hóa đơn
CREATE TABLE HOADON (
    MaHoaDon NVARCHAR(10) PRIMARY KEY,
    MaKhachHang NVARCHAR(5) NOT NULL,
    MaNhanVien NVARCHAR(5) NOT NULL,
    NgayTao DATE,
    Thue DECIMAL(4,1),
    TongTien INT,
    TinhTrangThanhToan NVARCHAR(20) CHECK (TinhTrangThanhToan IN (N'Đã thanh toán', N'Chưa thanh toán')),
    FOREIGN KEY (MaKhachHang) REFERENCES KHACHHANG(MaKhachHang),
    FOREIGN KEY (MaNhanVien) REFERENCES NHANVIEN(MaNhanVien)
);

-- Bảng chi tiết hóa đơn
CREATE TABLE CHITIETHOADON (
    MaChiTietHoaDon NVARCHAR(10) PRIMARY KEY,
    MaHoaDon NVARCHAR(5) NOT NULL,
    MaPhong NVARCHAR(5) NOT NULL,
    NgayNhanPhong DATE NOT NULL,
    NgayTraPhong DATE NOT NULL,
    FOREIGN KEY (MaHoaDon) REFERENCES HOADON(MaHoaDon),
    FOREIGN KEY (MaPhong) REFERENCES PHONG(MaPhong)
);

-- Bảng chi tiết dịch vụ
CREATE TABLE CHITIETDICHVU (
    MaChiTietDichVu NVARCHAR(10) PRIMARY KEY,
    MaHoaDon NVARCHAR(5) NOT NULL,
    MaDichVu NVARCHAR(5) NOT NULL,
    SoLuong INT NOT NULL,
    FOREIGN KEY (MaHoaDon) REFERENCES HOADON(MaHoaDon),
    FOREIGN KEY (MaDichVu) REFERENCES DICHVU(MaDichVu)
);

-- Dữ liệu mẫu (CÁI NÀY KHÔNG CẦN INSERT CŨNG ĐƯỢC)
INSERT INTO CHUCVU VALUES
(N'CV01', N'Lễ tân ca sáng', 8000000),
(N'CV02', N'Lễ tân ca tối', 8500000),
(N'CV03', N'Quản lý tầng', 12000000),
(N'CV04', N'Kế toán', 10000000),
(N'CV05', N'Giám đốc', 20000000);

INSERT INTO NHANVIEN VALUES
(N'NV01', N'CV01', N'Phạm Minh Khoa', N'Nam', '1993-08-25', N'0934567812', N'25 Trường Sơn, Quận Tân Bình, TP.HCM'),
(N'NV02', N'CV02', N'Lê Thanh Huyền', N'Nữ', '1990-04-18', N'0987654322', N'42 Pasteur, Quận 1, TP.HCM'),
(N'NV03', N'CV03', N'Trần Quốc Cường', N'Nam', '1985-11-11', N'0911222333', N'135 Phan Xích Long, Phú Nhuận, TP.HCM');

INSERT INTO TAIKHOAN VALUES
(N'TK01', N'admin', N'admin', N'NV03', N'admin'),
(N'TK02', N'huyenlt', N'letan456', N'NV02', N'lễ tân');

INSERT INTO KHACHHANG VALUES
(N'KH01', N'Nguyễn Hải Nam', N'Nam', '1995-06-12', N'0909123456', N'079123456789', N'hainam95@gmail.com', N'78 Trần Não, Quận 2, TP.HCM'),
(N'KH02', N'Võ Thị Kim Yến', N'Nữ', '1988-09-22', N'0933456777', N'079998877665', N'kimyen.vo@gmail.com', N'120 Nguyễn Văn Cừ, Quận 5, TP.HCM'),
(N'KH03', N'Huỳnh Ngọc Sơn', N'Nam', '1990-12-10', N'0977223344', N'072334455667', N'sonhn1980@yahoo.com', N'45/2B Lê Văn Sỹ, Quận 3, TP.HCM');

INSERT INTO LOAIPHONG VALUES
(N'LP01', N'Standard', 350000, N'1 giường đơn, điều hòa, wifi'),
(N'LP02', N'Deluxe', 600000, N'1 giường đôi, view thành phố'),
(N'LP03', N'Suite', 1200000, N'Phòng rộng, ban công lớn, bồn tắm'),
(N'LP04', N'Presidential Suite', 3000000, N'Siêu cao cấp, đầy đủ tiện nghi');

INSERT INTO PHONG VALUES
(N'P101', N'101', N'LP01', N'Trống'),
(N'P102', N'102', N'LP02', N'Đang đặt'),
(N'P201', N'201', N'LP03', N'Đang sử dụng'),
(N'P301', N'301', N'LP04', N'Trống');

INSERT INTO DICHVU VALUES
(N'DV01', N'Ăn sáng tại phòng', 100000, N'Bữa ăn sáng phục vụ tận phòng'),
(N'DV02', N'Dọn phòng', 50000, N'Dọn dẹp hằng ngày'),
(N'DV03', N'Trả đồ giặt', 80000, N'Giặt ủi đồ trong ngày'),
(N'DV04', N'Spa cao cấp', 400000, N'Massage & xông hơi thư giãn');

INSERT INTO DATPHONG VALUES
(N'DP01', N'KH01', N'P102', '2025-04-10', '2025-04-12', '2025-04-14', N'Đã đặt'),
(N'DP02', N'KH02', N'P201', '2025-04-11', '2025-04-11', '2025-04-15', N'Đã nhận'),
(N'DP03', N'KH03', N'P301', '2025-04-12', '2025-04-20', NULL, N'Trống');

INSERT INTO HOADON VALUES
(N'HD01', N'KH02', N'NV01', '2025-04-15', 10.0, 2450000, N'Đã thanh toán'),
(N'HD02', N'KH01', N'NV02', '2025-04-14', 10.0, NULL, N'Chưa thanh toán');

INSERT INTO CHITIETHOADON VALUES
(N'CTHD01', N'HD01', N'P201', '2025-04-11', '2025-04-15'),
(N'CTHD02', N'HD02', N'P102', '2025-04-12', '2025-04-14');

INSERT INTO CHITIETDICHVU VALUES
(N'CTDV01', N'HD01', N'DV01', 2),
(N'CTDV02', N'HD01', N'DV04', 1),
(N'CTDV03', N'HD02', N'DV02', 3);

-- Thủ tục thêm khách hàng mới
CREATE PROCEDURE sp_ThemKhachHang
    @MaKhachHang NVARCHAR(5),
    @HoTen NVARCHAR(30),
    @GioiTinh NVARCHAR(3),
    @NgaySinh DATE,
    @SoDienThoai NVARCHAR(10),
    @CCCD NVARCHAR(12),
    @Email NVARCHAR(50),
    @DiaChi NVARCHAR(100)
AS
BEGIN
    INSERT INTO KHACHHANG VALUES (@MaKhachHang, @HoTen, @GioiTinh, @NgaySinh, @SoDienThoai, @CCCD, @Email, @DiaChi)
END

-- Thủ tục tìm phòng trống theo loại
CREATE PROCEDURE sp_TimPhongTrongTheoLoai
    @MaLoaiPhong NVARCHAR(5)
AS
BEGIN
    SELECT * FROM PHONG
    WHERE MaLoaiPhong = @MaLoaiPhong AND TrangThai = N'Trống'
END

-- Thủ tục đặt phòng và kiểm tra
DROP PROCEDURE sp_DatPhong;
CREATE PROCEDURE sp_DatPhong
    @MaDatPhong NVARCHAR(5),
    @MaKhachHang NVARCHAR(5),
    @MaPhong NVARCHAR(5),
    @NgayNhanPhong DATETIME,
    @NgayTraPhong DATETIME,
    @TrangThai NVARCHAR(20)
AS
BEGIN
    -- Thêm dữ liệu vào bảng DATPHONG
    INSERT INTO DATPHONG (MaDatPhong, MaKhachHang, MaPhong, NgayDat, NgayNhanPhong, NgayTraPhong, TrangThai)
    VALUES (@MaDatPhong, @MaKhachHang, @MaPhong, GETDATE(), @NgayNhanPhong, @NgayTraPhong, @TrangThai);

    -- Cập nhật trạng thái phòng thành 'Đang sử dụng'
    UPDATE PHONG
    SET TrangThai = N'Đang sử dụng'
    WHERE MaPhong = @MaPhong;

    -- Tạo mã hóa đơn mới tự động
    DECLARE @MaHoaDon NVARCHAR(5);
    SELECT @MaHoaDon = 'HD' + RIGHT('00' + CAST(COUNT(*) + 1 AS VARCHAR), 3) FROM HOADON;

    -- Thêm hóa đơn mới với tình trạng chưa thanh toán và các thông tin cần thiết
    INSERT INTO HOADON (MaHoaDon, MaKhachHang, NgayTao, Thue, TongTien, TinhTrangThanhToan)
    VALUES (@MaHoaDon, @MaKhachHang, GETDATE(), 0, 0, N'Chưa thanh toán');

    -- Ghi vào bảng CHITIETHOADON để liên kết hóa đơn với phòng
    INSERT INTO CHITIETHOADON (MaHoaDon, MaPhong)
    VALUES (@MaHoaDon, @MaPhong);
END

EXEC sp_helptext 'sp_DatPhong';

-- Thủ tục thanh toán hoá đơn
CREATE PROCEDURE sp_ThanhToanHoaDon
    @MaHoaDon NVARCHAR(5),
    @TongTien INT
AS
BEGIN
    UPDATE HOADON
    SET TongTien = @TongTien,
        TinhTrangThanhToan = N'Đã thanh toán'
    WHERE MaHoaDon = @MaHoaDon
END

-- Thống kê doanh thu
CREATE PROCEDURE sp_ThongKeDoanhThuTheoThang
    @Thang INT,
    @Nam INT
AS
BEGIN
    SELECT 
        MONTH(NgayTao) AS Thang,
        SUM(TongTien) AS TongDoanhThu
    FROM HOADON
    WHERE MONTH(NgayTao) = @Thang AND YEAR(NgayTao) = @Nam AND TinhTrangThanhToan = N'Đã thanh toán'
    GROUP BY MONTH(NgayTao)
END
SELECT * FROM PHONG WHERE TrangThai = N'Còn Trống'