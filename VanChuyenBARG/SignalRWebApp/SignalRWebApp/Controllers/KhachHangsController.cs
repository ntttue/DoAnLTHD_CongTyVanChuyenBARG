using SignalRWebApp.Models;
using SignalRWebApp.SqlServerNotifier;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SignalRWebApp.Controllers
{
    public class KhachHangsController : Controller
    {
        private VCBargContext db = new VCBargContext();
        private VanChuyenBargEntities entityBarg = new VanChuyenBargEntities();

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

        public JsonResult GetListTaiXe()
        {
            List<TaiXe> dsTaiXe = entityBarg.TaiXes.ToList();
            return Json(dsTaiXe);
        }

        // GET: KhachHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            KhachHang khachHang = db.KhachHangs.Find(id);
            khachHang.TinhTrang = "Đã định vị xong";
            db.SaveChanges();

            if (khachHang == null)
            {
                return HttpNotFound();
            }

            return View(khachHang);
        }

        // GET: KhachHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }
        [HttpPost]
        public ActionResult ChangeStatus(int id, string status)
        {
            KhachHang khachHang = db.KhachHangs.Find(id);
            khachHang.TinhTrang = status;
            db.SaveChanges();
            return Json(status, JsonRequestBehavior.AllowGet);
        }

        // POST: KhachHangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,HoTen,SDT,DiaChiDon,GhiChu,LoaiXe,ThoiDiemDat,TinhTrang")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khachHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khachHang);
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