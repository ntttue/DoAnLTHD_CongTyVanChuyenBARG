using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDienThoaiVien
{
    public class KhachHang
    {
        public int id { get; set; }
        public string HoTen { get; set; }
        public string SDT { get; set; }
        public string DiaChiDon { get; set; }
        public string GhiChu { get; set; }
        public int LoaiXe { get; set; }
        public DateTime ThoiDiemDat { get; set; }
        public string TinhTrang { get; set; }
    }
}
