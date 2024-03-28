using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_DICHVU
    {
        static DAL_DICHVU dal_dichVu = new DAL_DICHVU();
        public List<ListDichVu> SelectDichVu()
        {
            return dal_dichVu.danhSachDichVu().ToList();
        }
    }
}
