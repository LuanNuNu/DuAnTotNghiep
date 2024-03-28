using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_HOADON
    {
        static DAL_HOADON dal_HoaDon = new DAL_HOADON();
        public List<ThongTinHoaDon> SelectChiTietHD()
        {
            return dal_HoaDon.selectHD().ToList();
        }
    }
}
