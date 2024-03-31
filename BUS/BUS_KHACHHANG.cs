using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_KHACHHANG
    {
        static DAL_KHACHHANG dAL_KhachHang = new DAL_KHACHHANG();

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
