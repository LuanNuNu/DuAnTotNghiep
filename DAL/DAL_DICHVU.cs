using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_DICHVU
    {
        public List<ListDichVu> danhSachDichVu()
        {
            using (var db = new QL_KhachSanEntities())
            {
                List<ListDichVu> danhsachdichvu = db.ListDichVus.ToList();
                return danhsachdichvu;
            }
        }
    }
}
