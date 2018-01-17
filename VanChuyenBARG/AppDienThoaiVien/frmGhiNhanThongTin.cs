using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
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
            //if (!ServerStatusBy("http://localhost:4771/"))
            //{
            //    MessageBox.Show("Hiện tại server chưa sẵn sàng, vui lòng quay lại sau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            InitializeComponent();
           
        }
        public static Boolean  ServerStatusBy(string url)
        {
            try
            {
                var myRequest = (HttpWebRequest)WebRequest.Create(url);

                var response = (HttpWebResponse)myRequest.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
                //  not available at all, for some reason
                Debug.Write(string.Format("{0} unavailable: {1}", url, ex.Message));
            }
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

                    MessageBox.Show("Đã gửi", "Thông báo",  MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            kh.TinhTrang = "Chưa được định vị";
            this.callServer();
            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }
    }

}
