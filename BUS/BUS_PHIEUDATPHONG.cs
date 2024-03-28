using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_PHIEUDATPHONG
    {
        static DAL_PHIEUDATPHONG dal_PHIEUDATPHONG = new DAL_PHIEUDATPHONG();
        public void UpdatePDPhong(PhieuDatPhong phieudatPhong)
        {
            dal_PHIEUDATPHONG.UpdatePDP(phieudatPhong);
        }
        public List<PhieuDatPhong> SelectPDPhong()
        {
            return dal_PHIEUDATPHONG.getPDP().ToList();
        }
    }
}
