//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SignalRWebApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class KhachHang:EntityBase
    {
        public int id { get; set; }
        public string HoTen { get; set; }
        public string SDT { get; set; }
        public string DiaChiDon { get; set; }
        public string GhiChu { get; set; }
        public Nullable<int> LoaiXe { get; set; }
        public Nullable<System.DateTime> ThoiDiemDat { get; set; }
        public string TinhTrang { get; set; }
    }
}
