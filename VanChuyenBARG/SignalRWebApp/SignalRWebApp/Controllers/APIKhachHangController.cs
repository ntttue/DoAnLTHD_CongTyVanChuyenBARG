using SignalRWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SignalRWebApp.Controllers
{
    public class APIKhachHangController : ApiController
    {
        [HttpGet]
        [Route("api/khachhang/hello")]
        public IHttpActionResult Hello()
        {
            return Ok("hello");
        }

        [HttpPost]
        [Route("api/khachhang/add")]
        public HttpResponseMessage Add([FromBody]KhachHang kh)
        {
            using (VanChuyenBargEntities ctx = new VanChuyenBargEntities())
            {
                ctx.KhachHangs.Add(kh);
                ctx.SaveChanges();
            }

            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}
