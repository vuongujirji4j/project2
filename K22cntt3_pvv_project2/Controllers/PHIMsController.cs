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
    public class PHIMsController : Controller
    {
        private PVVEntities db = new PVVEntities();

        // GET: PHIMs
        public ActionResult Index()
        {
            var pHIM = db.PHIM.Include(p => p.KHACH_HANG);
            return View(pHIM.ToList());
        }

        // GET: PHIMs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIM pHIM = db.PHIM.Find(id);
            if (pHIM == null)
            {
                return HttpNotFound();
            }
            return View(pHIM);
        }

        // GET: PHIMs/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KHACH_HANG, "MaKH", "Ho_ten");
            return View();
        }

        // POST: PHIMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPhim,MaKH,TenPhim,The_loai,Nam_sx,Trang_thai")] PHIM pHIM)
        {
            if (ModelState.IsValid)
            {
                db.PHIM.Add(pHIM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KHACH_HANG, "MaKH", "Ho_ten", pHIM.MaKH);
            return View(pHIM);
        }

        // GET: PHIMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIM pHIM = db.PHIM.Find(id);
            if (pHIM == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KHACH_HANG, "MaKH", "Ho_ten", pHIM.MaKH);
            ViewBag.TrangThaiList = new SelectList(new[]
{
        new { Value = 1, Text = "Hoạt động" },
        new { Value = 0, Text = "Không hoạt động" }
    }, "Value", "Text", pHIM.Trang_thai);
            return View(pHIM);
        }

        // POST: PHIMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPhim,MaKH,TenPhim,The_loai,Nam_sx,Trang_thai")] PHIM pHIM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHIM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KHACH_HANG, "MaKH", "Ho_ten", pHIM.MaKH);
            return View(pHIM);
        }

        // GET: PHIMs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIM pHIM = db.PHIM.Find(id);
            if (pHIM == null)
            {
                return HttpNotFound();
            }
            return View(pHIM);
        }

        // POST: PHIMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PHIM pHIM = db.PHIM.Find(id);
            db.PHIM.Remove(pHIM);
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
