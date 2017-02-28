using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppDienThoaiVien
{
    public partial class frmGhiNhanThongTin : Form
    {
        private KhachHang kh = new KhachHang();
        public frmGhiNhanThongTin()
        {
            InitializeComponent();
        }
        public void callServer()
        {
            try
            {
                using (var c = new HttpClient())
                {
                    c.DefaultRequestHeaders.Accept.Clear();
                    c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    string url = "http://localhost:4771/api/KhachHangs";
                    var response = c.PostAsJsonAsync(url, kh).Result;

                    MessageBox.Show(response.ToString());


                    //string url = "http://localhost:1898/api/simple/catList";

                    ////string str =
                    ////    c.GetStringAsync(url).Result;
                    ////Console.WriteLine(str);

                    //var response = c.GetAsync(url).Result;
                    //if (response.StatusCode == System.Net.HttpStatusCode.OK) {
                    //    var list = response.Content
                    //        .ReadAsAsync<DanhMuc[]>()
                    //        .Result;

                    //    Console.WriteLine("done");
                    //}
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi rầu!!!" + ex.Message);
            }
        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            kh.HoTen = this.txtHoTen.Text;
            kh.SDT = this.txtSDT.Text;
            kh.DiaChiDon = this.txtDiaChi.Text;
            kh.LoaiXe = this.rdoRremium.Checked == true ? 1 : 0;
            kh.GhiChu = this.txtGhiChu.Text;
            kh.ThoiDiemDat = DateTime.Now;
            kh.TinhTrang = "Chưa xử lý";
            this.callServer();
        }
    }

}
