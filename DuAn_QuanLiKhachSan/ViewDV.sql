

CREATE VIEW ViewDV AS
SELECT dv.MaDV, dv.TenDV, dv.GiaTien, ldv.TenLoaiDV
FROM DichVu dv
INNER JOIN LoaiDichVu ldv ON dv.MaLoaiDV = ldv.MaLoaiDV;
