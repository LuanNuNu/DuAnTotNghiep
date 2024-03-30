using DAL_QLKS;
using DTO_QLKS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLKS
{
    public class BUS_DichVu
    {
        static DAL_DichVu dAL_DichVu = new DAL_DichVu();
        public void Insert(DichVu dichVu)
        {
            int temp = dAL_DichVu.Insert(dichVu);
        }

        public List<DichVu> GetAll()
        {
            return dAL_DichVu.GetAll();
        }

        public List<ViewDV> ViewGet()
        {
            return dAL_DichVu.ViewGet();
        }
        public List<DichVu> TimKiem()
        {
            return dAL_DichVu.TimKiem();
        }

        public void Update(DichVu dichVu)
        {
            dAL_DichVu.Update(dichVu);
        }

        public void Delete(string maDV)
        {
            // Assuming dAL_DichVu.Delete method accepts the MaDV for deletion
            dAL_DichVu.Delete(maDV);
        }


    }
}

            