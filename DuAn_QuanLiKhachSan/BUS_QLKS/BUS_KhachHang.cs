using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QLKS;
using DTO_QLKS;

namespace BUS_QLKS
{
    
    public class BUS_KhachHang
    {
        static DAL_KhachHang dAL_KhachHang = new DAL_KhachHang();

        public List<KhachHang> GetAll()
        {
            return dAL_KhachHang.GetAll();
        }

        public void Update(KhachHang khachHang)
        {
            dAL_KhachHang.Update(khachHang);
        }
    }
}
