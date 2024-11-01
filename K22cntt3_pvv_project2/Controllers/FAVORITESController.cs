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
    public class FAVORITESController : Controller
    {
        private PVVEntities db = new PVVEntities();

        // GET: FAVORITES
        public ActionResult Index()
        {
            var fAVORITES = db.FAVORITES.Include(f => f.KHACH_HANG).Include(f => f.PHIM);
            return View(fAVORITES.ToList());
        }

        // GET: FAVORITES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAVORITES fAVORITES = db.FAVORITES.Find(id);
            if (fAVORITES == null)
            {
                return HttpNotFound();
            }
            return View(fAVORITES);
        }

        // GET: FAVORITES/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KHACH_HANG, "MaKH", "Ho_ten");
            ViewBag.MaPhim = new SelectList(db.PHIM, "MaPhim", "TenPhim");
            return View();
        }

        // POST: FAVORITES/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FavoriteID,MaKH,MaPhim,DateAdded")] FAVORITES fAVORITES)
        {
            if (ModelState.IsValid)
            {
                db.FAVORITES.Add(fAVORITES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KHACH_HANG, "MaKH", "Ho_ten", fAVORITES.MaKH);
            ViewBag.MaPhim = new SelectList(db.PHIM, "MaPhim", "TenPhim", fAVORITES.MaPhim);
            return View(fAVORITES);
        }

        // GET: FAVORITES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAVORITES fAVORITES = db.FAVORITES.Find(id);
            if (fAVORITES == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KHACH_HANG, "MaKH", "Ho_ten", fAVORITES.MaKH);
            ViewBag.MaPhim = new SelectList(db.PHIM, "MaPhim", "TenPhim", fAVORITES.MaPhim);
            return View(fAVORITES);
        }

        // POST: FAVORITES/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FavoriteID,MaKH,MaPhim,DateAdded")] FAVORITES fAVORITES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fAVORITES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KHACH_HANG, "MaKH", "Ho_ten", fAVORITES.MaKH);
            ViewBag.MaPhim = new SelectList(db.PHIM, "MaPhim", "TenPhim", fAVORITES.MaPhim);
            return View(fAVORITES);
        }

        // GET: FAVORITES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAVORITES fAVORITES = db.FAVORITES.Find(id);
            if (fAVORITES == null)
            {
                return HttpNotFound();
            }
            return View(fAVORITES);
        }

        // POST: FAVORITES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FAVORITES fAVORITES = db.FAVORITES.Find(id);
            db.FAVORITES.Remove(fAVORITES);
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
