using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvcdemo.Data;

namespace mvcdemo.Controllers
{
    public class mvcdemo2Controller : Controller
    {
        private mvcdemoEntities db = new mvcdemoEntities();

        // GET: mvcdemo2
        public ActionResult Index()
        {
            return View(db.tbl_mvcdemo.ToList());
        }
        public ActionResult Index1()
        {
            return View();
        }

        // GET: mvcdemo2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_mvcdemo tbl_mvcdemo = db.tbl_mvcdemo.Find(id);
            if (tbl_mvcdemo == null)
            {
                return HttpNotFound();
            }
            return View(tbl_mvcdemo);
        }

        // GET: mvcdemo2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: mvcdemo2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NAME,MOBILE_NO,EMAIL")] tbl_mvcdemo tbl_mvcdemo)
        {
            if (ModelState.IsValid)
            {
                db.tbl_mvcdemo.Add(tbl_mvcdemo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_mvcdemo);
        }

        // GET: mvcdemo2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_mvcdemo tbl_mvcdemo = db.tbl_mvcdemo.Find(id);
            if (tbl_mvcdemo == null)
            {
                return HttpNotFound();
            }
            return View(tbl_mvcdemo);
        }

        // POST: mvcdemo2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NAME,MOBILE_NO,EMAIL")] tbl_mvcdemo tbl_mvcdemo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_mvcdemo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_mvcdemo);
        }

        // GET: mvcdemo2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_mvcdemo tbl_mvcdemo = db.tbl_mvcdemo.Find(id);
            if (tbl_mvcdemo == null)
            {
                return HttpNotFound();
            }
            return View(tbl_mvcdemo);
        }

        // POST: mvcdemo2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_mvcdemo tbl_mvcdemo = db.tbl_mvcdemo.Find(id);
            db.tbl_mvcdemo.Remove(tbl_mvcdemo);
            db.SaveChanges();
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
