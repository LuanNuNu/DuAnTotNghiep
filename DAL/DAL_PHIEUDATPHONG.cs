using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_PHIEUDATPHONG
    {
        public void UpdatePDP(PhieuDatPhong phieudatPhong)
        {
            using (var db = new QL_KhachSanEntities())
            {
                db.PhieuDatPhongs.Attach(phieudatPhong);
                db.Entry(phieudatPhong).State = System.Data.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public List<PhieuDatPhong> getPDP()
        {
            using (var db = new QL_KhachSanEntities())
            {
                List<PhieuDatPhong> PDP = db.PhieuDatPhongs.ToList();
                return PDP;
            }
        }
    }
}
