//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DTO_QLKS
{
    using System;
    using System.Collections.Generic;
    
    public partial class LoaiPhong
    {
        public LoaiPhong()
        {
            this.Phongs = new HashSet<Phong>();
            this.TienNghiPhongs = new HashSet<TienNghiPhong>();
        }
    
        public string MaLoaiPhong { get; set; }
        public string TenLoaiPhong { get; set; }
        public double GiaTheoGio { get; set; }
        public double GiaTheoNgay { get; set; }
    
        public virtual ICollection<Phong> Phongs { get; set; }
        public virtual ICollection<TienNghiPhong> TienNghiPhongs { get; set; }
    }
}
