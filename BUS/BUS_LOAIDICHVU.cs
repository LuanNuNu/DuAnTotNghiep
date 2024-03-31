using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_LOAIDICHVU
    {
        static DAL_LOAIDICHVU dAL_LoaiDichVu = new DAL_LOAIDICHVU();

        public void Insert(LoaiDichVu loaiDichVu)
        {
            int temp = dAL_LoaiDichVu.Insert(loaiDichVu);
        }

        public List<LoaiDichVu> GetAll()
        {
            return dAL_LoaiDichVu.GetAll();
        }
    }
}
