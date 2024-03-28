-------View ViewPhong-----

EXEC InsertPhieuDatPhong 'KH0003','NV0003',2,N'Chưa thanh toán'
GO
EXEC InsertPhieuDatPhong 'KH0004','NV0003',2,N'Chưa thanh toán'
GO
EXEC InsertPhieuDatPhong 'KH0005','NV0004',1,N'Chưa thanh toán'
GO
EXEC InsertPhieuDatPhong 'KH0002','NV0002',1,N'Chưa thanh toán'
GO
EXEC InsertChiTietPhieuDatPhong 'PDP0003','P3001','2024-03-30','2024-03-31','12:00:00','12:00:00'
EXEC InsertChiTietPhieuDatPhong 'PDP0004','P1001','2024-03-30','2024-03-31','14:00:00','14:00:00 PM'
GO
GO
EXEC InsertChiTietPhieuDatPhong 'PDP0005','P2002','2024-03-28','2024-03-28','13:00:00','19:00:00'
GO
EXEC InsertChiTietPhieuDatPhong 'PDP0007','P3002','2024-03-27','2024-03-28','12:00:00','12:00:00'
GO
EXEC InsertChiTietDVPhieuDatPhong 'PDP0003','P3001','DV0001',2
GO


-------------------------------------------------------------

CREATE VIEW DanhSachThongTinPhong AS
SELECT
    MaPhong, 
    MaPDP,
    TenLoaiPhong, 
    TinhTrang, 
    Tang, 
    GhiChu, 
    SoNguoi, 
    TinhTrangThanhToan,
    TenKH, 
    MaKH, 
    NgayDat, 
    NgayKetThuc, 
    GioDat, 
    GioKetThuc,
    CASE 
        WHEN TinhTrang = N'Phòng trống' THEN 0
        ELSE DATEDIFF(day, NgayDat, NgayKetThuc)
    END AS SoNgay,
    CASE 
        WHEN TinhTrang = N'Phòng trống' THEN 0
        ELSE
            CASE
                WHEN TinhTrang = N'Đã thanh toán' OR TinhTrangThanhToan IS NULL THEN NULL 
                ELSE 
                    CASE 
                        WHEN NgayKetThuc = NgayDat THEN DATEDIFF(hour, GioDat, GioKetThuc)
                        ELSE DATEDIFF(day, NgayDat, NgayKetThuc) * 24 + DATEDIFF(hour, GioDat, GioKetThuc)
                    END
            END
    END AS SoGio
FROM (
    SELECT
        Phong.MaPhong,
        PhieuDatPhong.MaPDP,
        LoaiPhong.TenLoaiPhong,
        Phong.TinhTrang,
        Phong.Tang,
        Phong.GhiChu,
        PhieuDatPhong.SoNguoi,
        PhieuDatPhong.TinhTrang AS TinhTrangThanhToan,
        KhachHang.TenKH,
        KhachHang.MaKH,
        ChiTietPhieuDatPhong.NgayDat,
        ChiTietPhieuDatPhong.NgayKetThuc,
        ChiTietPhieuDatPhong.GioDat,
        ChiTietPhieuDatPhong.GioKetThuc,
        ROW_NUMBER() OVER(PARTITION BY Phong.MaPhong ORDER BY ChiTietPhieuDatPhong.NgayDat DESC) AS RowNumber
    FROM
        Phong
    INNER JOIN LoaiPhong ON Phong.MaLoaiPhong = LoaiPhong.MaLoaiPhong
    LEFT JOIN ChiTietPhieuDatPhong ON Phong.MaPhong = ChiTietPhieuDatPhong.MaPhong
    LEFT JOIN PhieuDatPhong ON ChiTietPhieuDatPhong.MaPDP = PhieuDatPhong.MaPDP
    LEFT JOIN KhachHang ON PhieuDatPhong.MaKH = KhachHang.MaKH
       WHERE 
        (CAST(GETDATE() AS DATE) BETWEEN ChiTietPhieuDatPhong.NgayDat AND ChiTietPhieuDatPhong.NgayKetThuc) OR (ChiTietPhieuDatPhong.NgayKetThuc > CAST(GETDATE() AS DATE) AND ChiTietPhieuDatPhong.NgayDat > CAST(GETDATE() AS DATE))
		OR ChiTietPhieuDatPhong.NgayDat IS NULL
) AS Subquery
WHERE RowNumber = 1;


CREATE FUNCTION dbo.GetPhongInfoByDate(@selectedDate DATETIME)
RETURNS TABLE
AS
RETURN
(
    SELECT
        MaPhong,
        MaPDP,
        TenLoaiPhong,
        CASE
            WHEN @selectedDate = CONVERT(DATETIME, NgayDat) + CAST(GioDat AS DATETIME) THEN TinhTrang
            WHEN @selectedDate BETWEEN CONVERT(DATETIME, NgayDat) + CAST(GioDat AS DATETIME) 
			AND CONVERT(DATETIME, NgayKetThuc) + CAST(GioKetThuc AS DATETIME) THEN TinhTrang
            WHEN @selectedDate > CONVERT(DATETIME, NgayKetThuc) + CAST(GioKetThuc AS DATETIME) THEN N'Phòng trống'
            WHEN @selectedDate < CONVERT(DATETIME, NgayDat) + CAST(GioDat AS DATETIME) THEN N'Phòng trống'
            ELSE N'Phòng trống'
        END AS TinhTrang,
        GioDat,
        GioKetThuc,
        SoNguoi,
        NgayDat,
        NgayKetThuc,
        Tang,
        GhiChu,
        TinhTrangThanhToan,
        TenKH,
        MaKH,
        CASE 
            WHEN TinhTrang != N'Phòng đang thuê' THEN 0
            ELSE 
                CASE
                    WHEN SoGio >= 24 THEN FLOOR(SoGio / 24)
                    ELSE 0
                END
        END AS SoNgay,
        CASE 
            WHEN TinhTrang != N'Phòng đang thuê' THEN 0
            ELSE 
                CASE
                    WHEN TinhTrang = N'Đã thanh toán' OR TinhTrangThanhToan IS NULL THEN NULL 
                    ELSE 
                        CASE 
                            WHEN NgayKetThuc = NgayDat THEN DATEDIFF(hour, GioDat, GioKetThuc)
                            ELSE DATEDIFF(day, NgayDat, NgayKetThuc) * 24 + DATEDIFF(hour, GioDat, GioKetThuc)
                        END
                END
        END AS SoGio,
		RowNumber
    FROM (
           SELECT
        Phong.MaPhong,
        PhieuDatPhong.MaPDP,
        LoaiPhong.TenLoaiPhong,
        Phong.TinhTrang,
        Phong.Tang,
        Phong.GhiChu,
        PhieuDatPhong.SoNguoi,
        PhieuDatPhong.TinhTrang AS TinhTrangThanhToan,
        KhachHang.TenKH,
        KhachHang.MaKH,
        ChiTietPhieuDatPhong.NgayDat,
        ChiTietPhieuDatPhong.NgayKetThuc,
        ChiTietPhieuDatPhong.GioDat,
        ChiTietPhieuDatPhong.GioKetThuc,
		COALESCE(DATEDIFF(day, ChiTietPhieuDatPhong.NgayDat, ChiTietPhieuDatPhong.NgayKetThuc), '') AS SoNgay,
		COALESCE(DATEDIFF(hour, ChiTietPhieuDatPhong.NgayDat, ChiTietPhieuDatPhong.NgayKetThuc), '') AS SoGio,
        ROW_NUMBER() OVER(PARTITION BY Phong.MaPhong ORDER BY ChiTietPhieuDatPhong.NgayDat DESC) AS RowNumber
    FROM
        Phong
    INNER JOIN LoaiPhong ON Phong.MaLoaiPhong = LoaiPhong.MaLoaiPhong
    LEFT JOIN ChiTietPhieuDatPhong ON Phong.MaPhong = ChiTietPhieuDatPhong.MaPhong
    LEFT JOIN PhieuDatPhong ON ChiTietPhieuDatPhong.MaPDP = PhieuDatPhong.MaPDP
    LEFT JOIN KhachHang ON PhieuDatPhong.MaKH = KhachHang.MaKH
       WHERE 
        (CAST(GETDATE() AS DATE) BETWEEN ChiTietPhieuDatPhong.NgayDat AND ChiTietPhieuDatPhong.NgayKetThuc) OR (ChiTietPhieuDatPhong.NgayKetThuc > CAST(GETDATE() AS DATE) AND ChiTietPhieuDatPhong.NgayDat > CAST(GETDATE() AS DATE))
		OR ChiTietPhieuDatPhong.NgayDat IS NULL
) AS Subquery
    WHERE RowNumber = 1
)


-----------------------------------






---------
create view ListDichVu as
SELECT        LoaiDichVu.TenLoaiDV, DichVu.TenDV, DichVu.GiaTien,DichVu.MaDV
FROM            DichVu INNER JOIN
                         LoaiDichVu ON DichVu.MaLoaiDV = LoaiDichVu.MaLoaiDV

-------------------
create view ListLoaiPhong as
SELECT        MaLoaiPhong, TenLoaiPhong, GiaTheoGio, GiaTheoNgay
FROM            LoaiPhong						 

create view ThongTinHoaDon as
SELECT        HD.MaHD, HD.TongGiaTri, HD.NgayInHD, HD.MaPDP ,CTPDP.MaPhong, P.MaLoaiPhong, LP.GiaTheoGio, LP.GiaTheoNgay, 
				DV.TenDV, CTDV.MaDV, CTDV.SoLuongDV, DV.GiaTien, CTDV.TongGiaTri AS ThanhTien, PDP.SoNguoi
FROM            ChiTietDichVuPhieuDatPhong AS CTDV INNER JOIN
                         ChiTietPhieuDatPhong AS CTPDP ON CTDV.MaPDP = CTPDP.MaPDP AND CTDV.MaPhong = CTPDP.MaPhong INNER JOIN
                         HoaDon AS HD ON CTDV.MaPDP = HD.MaPDP INNER JOIN
                         DichVu AS DV ON CTDV.MaDV = DV.MaDV INNER JOIN
                         Phong AS P ON CTPDP.MaPhong = P.MaPhong INNER JOIN
                         LoaiPhong AS LP ON P.MaLoaiPhong = LP.MaLoaiPhong INNER JOIN
                         PhieuDatPhong as PDP ON CTPDP.MaPDP = PDP.MaPDP AND HD.MaPDP = PDP.MaPDP

create view DichVuTheoPDP as
SELECT        ChiTietDichVuPhieuDatPhong.MaPDP, ChiTietDichVuPhieuDatPhong.MaPhong, ChiTietDichVuPhieuDatPhong.MaDV, DichVu.TenDV, ChiTietDichVuPhieuDatPhong.SoLuongDV, ChiTietDichVuPhieuDatPhong.TongGiaTri, 
                         DichVu.GiaTien, DichVu.DonVi
FROM            ChiTietDichVuPhieuDatPhong INNER JOIN
                         DichVu ON ChiTietDichVuPhieuDatPhong.MaDV = DichVu.MaDV



CREATE TRIGGER UpdateTongGiaTri
ON ChiTietDichVuPhieuDatPhong
AFTER UPDATE
AS
BEGIN
    -- Kiểm tra xem các cột SoLuongDV hoặc TongGiaTri có được cập nhật không
    IF UPDATE(SoLuongDV) OR UPDATE(TongGiaTri)
    BEGIN
        -- Cập nhật tổng giá trị dựa trên số lượng dịch vụ và đơn giá
        UPDATE ChiTietDichVuPhieuDatPhong
        SET TongGiaTri = SoLuongDV * (select GiaTien from DichVu where MaDV = (select MaDV from inserted))  -- Giả sử GiaTien là đơn giá của dịch vụ
        FROM ChiTietDichVuPhieuDatPhong
		where MaDV =(select MaDV from inserted) and MaPDP = (select MaPDP from inserted) and MaPhong = (select MaPhong from inserted);
    END
END;


CREATE PROCEDURE UpdatePhieuDatPhong
    @MaPDP char(10),
    @MaKH char(10),
    @MaNV char(10),
    @TongGiaTri float,
    @NgayTao DATETIME,
    @SoNguoi INT,
    @TinhTrang NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE PhieuDatPhong
    SET MaKH = @MaKH,
        MaNV = @MaNV,
        TongGiaTri = @TongGiaTri,
        NgayTao = @NgayTao,
        SoNguoi = @SoNguoi,
        TinhTrang = @TinhTrang
    WHERE MaPDP = @MaPDP;
END;







