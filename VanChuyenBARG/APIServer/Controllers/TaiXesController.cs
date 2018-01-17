using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using APIServer.Models;

namespace APIServer.Controllers
{
    public class TaiXesController : ApiController
    {
        private VanChuyenBargEntities db = new VanChuyenBargEntities();

        // GET: api/TaiXes
        public IQueryable<TaiXe> GetTaiXes()
        {
            return db.TaiXes;
        }

        // GET: api/TaiXes/5
        [ResponseType(typeof(TaiXe))]
        public IHttpActionResult GetTaiXe(int id)
        {
            TaiXe taiXe = db.TaiXes.Find(id);
            if (taiXe == null)
            {
                return NotFound();
            }

            return Ok(taiXe);
        }

        // PUT: api/TaiXes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTaiXe(int id, TaiXe taiXe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taiXe.id)
            {
                return BadRequest();
            }

            db.Entry(taiXe).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaiXeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TaiXes
        [ResponseType(typeof(TaiXe))]
        public IHttpActionResult PostTaiXe(TaiXe taiXe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TaiXes.Add(taiXe);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = taiXe.id }, taiXe);
        }

        // DELETE: api/TaiXes/5
        [ResponseType(typeof(TaiXe))]
        public IHttpActionResult DeleteTaiXe(int id)
        {
            TaiXe taiXe = db.TaiXes.Find(id);
            if (taiXe == null)
            {
                return NotFound();
            }

            db.TaiXes.Remove(taiXe);
            db.SaveChanges();

            return Ok(taiXe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaiXeExists(int id)
        {
            return db.TaiXes.Count(e => e.id == id) > 0;
        }

        // POST: api/login
        [ResponseType(typeof(Boolean))]
        public IHttpActionResult Login(String username, String password)
        {
            return Ok(true);
        }
    }
}