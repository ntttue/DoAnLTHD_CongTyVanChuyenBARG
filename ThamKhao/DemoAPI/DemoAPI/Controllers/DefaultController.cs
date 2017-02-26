using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoAPI.Controllers
{
    public class DefaultController : ApiController
    {
        [HttpGet]
        [Route("api/khachhang/hello")]
        public IHttpActionResult Hello()
        {
            return Ok("hello");
        }
    }
}
