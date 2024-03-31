using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_KHACHHANG
    {
        public List<KhachHang> GetAll()
        {
            using (var conn = new QL_KhachSanEntities())
            {
                var getall = conn.KhachHangs.ToList();
                return getall;
            }
        }

        public void Update(KhachHang khachHang)
        {
            using (var conn = new QL_KhachSanEntities())
            {
                conn.KhachHangs.Attach(khachHang);
                conn.Entry(khachHang).State = System.Data.EntityState.Modified;
                conn.SaveChanges();
            }
        }
    }
}
