using SignalRWebApp.Models;
using SignalRWebApp.SqlServerNotifier;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SignalRWebApp.Controllers
{
    public class KhachHangsController : Controller
    {
        //// GET: KhachHangs
        //public ActionResult Index()
        //{
        //    return View();
        //}

        private VanChuyenBargEntities db = new VanChuyenBargEntities();

        public async Task<ActionResult> Index()
        {
            var collection = db.KhachHangs;
            ViewBag.NotifierEntity = db.GetNotifierEntity<KhachHang>(collection).ToJson();
            return View(await collection.ToListAsync());
        }

        public async Task<ActionResult> IndexPartial()
        {
            var collection = db.KhachHangs;
            ViewBag.NotifierEntity = db.GetNotifierEntity<KhachHang>(collection).ToJson();
            return PartialView(await collection.ToListAsync());
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }

}