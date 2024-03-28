using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_LOAIPHONG
    {
        static DAL_LOAIPHONG dal_LoaiPhong = new DAL_LOAIPHONG();
        public List<ListLoaiPhong> SelectLoaiPhong()
        {
            return dal_LoaiPhong.getValueLoaiPhong().ToList();
        }
    }
}
