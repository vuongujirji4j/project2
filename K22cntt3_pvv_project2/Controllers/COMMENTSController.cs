using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using K22cntt3_pvv_project2.Models;

namespace K22cntt3_pvv_project2.Controllers
{
    public class COMMENTSController : Controller
    {
        private PVVEntities db = new PVVEntities();

        // GET: COMMENTS
        public ActionResult Index()
        {
            var cOMMENTS = db.COMMENTS.Include(c => c.KHACH_HANG).Include(c => c.PHIM);
            return View(cOMMENTS.ToList());
        }

        // GET: COMMENTS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMMENTS cOMMENTS = db.COMMENTS.Find(id);
            if (cOMMENTS == null)
            {
                return HttpNotFound();
            }
            return View(cOMMENTS);
        }

        // GET: COMMENTS/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KHACH_HANG, "MaKH", "Ho_ten");
            ViewBag.MaPhim = new SelectList(db.PHIM, "MaPhim", "TenPhim");
            return View();
        }

        // POST: COMMENTS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentID,MaKH,MaPhim,CommentText,CommentDate")] COMMENTS cOMMENTS)
        {
            if (ModelState.IsValid)
            {
                db.COMMENTS.Add(cOMMENTS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KHACH_HANG, "MaKH", "Ho_ten", cOMMENTS.MaKH);
            ViewBag.MaPhim = new SelectList(db.PHIM, "MaPhim", "TenPhim", cOMMENTS.MaPhim);
            return View(cOMMENTS);
        }

        // GET: COMMENTS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMMENTS cOMMENTS = db.COMMENTS.Find(id);
            if (cOMMENTS == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KHACH_HANG, "MaKH", "Ho_ten", cOMMENTS.MaKH);
            ViewBag.MaPhim = new SelectList(db.PHIM, "MaPhim", "TenPhim", cOMMENTS.MaPhim);
            return View(cOMMENTS);
        }

        // POST: COMMENTS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentID,MaKH,MaPhim,CommentText,CommentDate")] COMMENTS cOMMENTS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOMMENTS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KHACH_HANG, "MaKH", "Ho_ten", cOMMENTS.MaKH);
            ViewBag.MaPhim = new SelectList(db.PHIM, "MaPhim", "TenPhim", cOMMENTS.MaPhim);
            return View(cOMMENTS);
        }

        // GET: COMMENTS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMMENTS cOMMENTS = db.COMMENTS.Find(id);
            if (cOMMENTS == null)
            {
                return HttpNotFound();
            }
            return View(cOMMENTS);
        }

        // POST: COMMENTS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            COMMENTS cOMMENTS = db.COMMENTS.Find(id);
            db.COMMENTS.Remove(cOMMENTS);
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
