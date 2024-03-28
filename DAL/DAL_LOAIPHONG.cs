using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_LOAIPHONG
    {
        public List<ListLoaiPhong> getValueLoaiPhong()
        {
            using (var db = new QL_KhachSanEntities())
            {
                List<ListLoaiPhong> loaiPhongs = db.ListLoaiPhongs.ToList();
                return loaiPhongs;
            }
        }
    }
}
