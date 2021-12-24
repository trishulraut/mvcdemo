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
using mvcdemo.Data;

namespace mvcdemo.Controllers
{
    public class MVCAPIController : ApiController
    {
        private mvcdemoEntities db = new mvcdemoEntities();

        // GET: api/MVCAPI
        public IQueryable<tbl_mvcdemo> Gettbl_mvcdemo()
        {
            return db.tbl_mvcdemo;
        }

        // GET: api/MVCAPI/5
        [ResponseType(typeof(tbl_mvcdemo))]
        public IHttpActionResult Gettbl_mvcdemo(int id)
        {
            tbl_mvcdemo tbl_mvcdemo = db.tbl_mvcdemo.Find(id);
            if (tbl_mvcdemo == null)
            {
                return NotFound();
            }

            return Ok(tbl_mvcdemo);
        }

        // PUT: api/MVCAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_mvcdemo(int id, tbl_mvcdemo tbl_mvcdemo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_mvcdemo.ID)
            {
                return BadRequest();
            }

            db.Entry(tbl_mvcdemo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_mvcdemoExists(id))
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

        // POST: api/MVCAPI
        [ResponseType(typeof(tbl_mvcdemo))]
        public IHttpActionResult Posttbl_mvcdemo(tbl_mvcdemo tbl_mvcdemo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_mvcdemo.Add(tbl_mvcdemo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_mvcdemo.ID }, tbl_mvcdemo);
        }

        // DELETE: api/MVCAPI/5
        [ResponseType(typeof(tbl_mvcdemo))]
        public IHttpActionResult Deletetbl_mvcdemo(int id)
        {
            tbl_mvcdemo tbl_mvcdemo = db.tbl_mvcdemo.Find(id);
            if (tbl_mvcdemo == null)
            {
                return NotFound();
            }

            db.tbl_mvcdemo.Remove(tbl_mvcdemo);
            db.SaveChanges();

            return Ok(tbl_mvcdemo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_mvcdemoExists(int id)
        {
            return db.tbl_mvcdemo.Count(e => e.ID == id) > 0;
        }
    }
}