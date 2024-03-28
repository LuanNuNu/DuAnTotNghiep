using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_CHITIETDICHVUPDP
    {
        static DAL_CHITIETDICHVUPDP dal_chiTietDichVuPDP = new DAL_CHITIETDICHVUPDP();
        public int InsertDichVuPhong(ChiTietDichVuPhieuDatPhong dichVuDaChon)
        {
            return dal_chiTietDichVuPDP.InsertChiTietDVPDP(dichVuDaChon);
        }
        public List<DichVuTheoPDP> SelectDichVu()
        {
            return dal_chiTietDichVuPDP.danhSachDichVuDaChon().ToList();
        }
        public List<ChiTietDichVuPhieuDatPhong> SelectDVPhong()
        {
            return dal_chiTietDichVuPDP.selectDichVu().ToList();
        }
        public void UpdateDichVu(ChiTietDichVuPhieuDatPhong dichvu)
        {
            dal_chiTietDichVuPDP.UpdateDichVuTheoPDP(dichvu);
        }

        public void DeleteDichVu(ChiTietDichVuPhieuDatPhong dichvu)
        {
            dal_chiTietDichVuPDP.deleteDichVuTheoPDP(dichvu);
        }
    }
}
