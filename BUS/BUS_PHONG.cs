using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_PHONG
    {
        static DAL_PHONG Dal_PHONG= new DAL_PHONG();
        public List<DanhSachThongTinPhong> SelectAllPhong()
        {
            return Dal_PHONG.getValuePhong().ToList();
        }
        public List<DanhSachThongTinPhong> SelectPhongDon()
        {
            return Dal_PHONG.getValuePhong().Where(c => c.TenLoaiPhong.Equals("Phòng đơn")).ToList();
        }
        public List<DanhSachThongTinPhong> SelectPhongDoi()
        {
            return Dal_PHONG.getValuePhong().Where(c => c.TenLoaiPhong.Equals("Phòng đôi")).ToList();
        }
        public List<DanhSachThongTinPhong> SelectPhongFamily()
        {
            return Dal_PHONG.getValuePhong().Where(c => c.TenLoaiPhong.Equals("Phòng gia đình")).ToList();
        }
        public void UpdatePhong(Phong thongTinPhong)
        {
            Dal_PHONG.UpdatePhong(thongTinPhong);
        }

        public List<Phong> SelectPhong()
        {
            return Dal_PHONG.getPhong().ToList();
        }

        public int Insert(Phong Phong)
        {
            return Dal_PHONG.InsertPhong(Phong);
        }


        public List<DanhSachThongTinPhong> GetPhongsByDate(DateTime selectedDate)
        {
            // Gọi phương thức từ lớp DAL để lấy dữ liệu từ function
            var danhSachPhongs = Dal_PHONG.GetPhongInfoByDate(selectedDate);
            return danhSachPhongs;
        }
    }
}
