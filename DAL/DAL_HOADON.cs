using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_HOADON
    {
        public List<ThongTinHoaDon> selectHD()
        {
            using (var db = new QL_KhachSanEntities())
            {
                List<ThongTinHoaDon> loaiPhongs = db.ThongTinHoaDons.ToList();
                return loaiPhongs;
            }
        }
    }
}
