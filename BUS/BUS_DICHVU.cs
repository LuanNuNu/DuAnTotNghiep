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
        public void Insert(DichVu dichVu)
        {
            int temp = dal_dichVu.Insert(dichVu);
        }
        public List<DichVu> GetAll()
        {
            return dal_dichVu.GetAll();
        }
        public List<DichVu> TimKiem()
        {
            return dal_dichVu.TimKiem();
        }

        public void Update(DichVu dichVu)
        {
            dal_dichVu.Update(dichVu);
        }

        public void Delete(string maDV)
        {
            // Assuming dAL_DichVu.Delete method accepts the MaDV for deletion
            dal_dichVu.Delete(maDV);
        }
    }
}
