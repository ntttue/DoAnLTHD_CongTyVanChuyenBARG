using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SignalRWebApp.Models;

namespace SignalRWebApp.Controllers
{
    public class TaiXesController : Controller
    {
        private VanChuyenBargEntities db = new VanChuyenBargEntities();

        // GET: TaiXes
        public async Task<ActionResult> Index()
        {
            return View(await db.TaiXes.ToListAsync());
        }

        // GET: TaiXes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiXe taiXe = await db.TaiXes.FindAsync(id);
            if (taiXe == null)
            {
                return HttpNotFound();
            }
            return View(taiXe);
        }

        // GET: TaiXes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaiXes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,HoTen,Lat,Lng,TrangThai")] TaiXe taiXe)
        {
            if (ModelState.IsValid)
            {
                db.TaiXes.Add(taiXe);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(taiXe);
        }

        // GET: TaiXes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiXe taiXe = await db.TaiXes.FindAsync(id);
            if (taiXe == null)
            {
                return HttpNotFound();
            }
            return View(taiXe);
        }

        // POST: TaiXes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,HoTen,Lat,Lng,TrangThai")] TaiXe taiXe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taiXe).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(taiXe);
        }

        // GET: TaiXes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiXe taiXe = await db.TaiXes.FindAsync(id);
            if (taiXe == null)
            {
                return HttpNotFound();
            }
            return View(taiXe);
        }

        // POST: TaiXes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TaiXe taiXe = await db.TaiXes.FindAsync(id);
            db.TaiXes.Remove(taiXe);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
