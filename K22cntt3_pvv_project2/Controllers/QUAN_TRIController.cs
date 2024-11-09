using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using K22cntt3_pvv_project2.Models;

namespace K22cntt3_pvv_project2.Controllers
{
    public class QUAN_TRIController : Controller
    {
        private readonly PVVEntities db = new PVVEntities();

        // GET: QUAN_TRI/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // POST: QUAN_TRI/Login
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = db.QUAN_TRI.FirstOrDefault(u => u.Tai_khoan == model.Tai_khoan && u.Mat_khau == model.Mat_khau);
                if (user != null && user.Trang_thai == 1) // Kiểm tra trạng thái người dùng là 1 (hoạt động)
                {
                    // Đăng nhập thành công, lưu thông tin vào session
                    Session["User"] = user.Tai_khoan;
                    return RedirectToAction("Index", "Home"); // Chuyển hướng sau khi đăng nhập
                }
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
            }
            return View(model);
        }

        // GET: QUAN_TRI/Register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        // POST: QUAN_TRI/Register
        [HttpPost]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra xem tài khoản đã tồn tại chưa
                var userExists = db.QUAN_TRI.Any(u => u.Tai_khoan == model.Tai_khoan);
                if (!userExists)
                {
                    // Lưu thông tin người dùng vào bảng QUAN_TRI
                    var newUser = new QUAN_TRI
                    {
                        Tai_khoan = model.Tai_khoan,
                        Mat_khau = model.Mat_khau,
                        Trang_thai = 1 // 1 để chỉ trạng thái hoạt động
                    };
                    db.QUAN_TRI.Add(newUser);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                ModelState.AddModelError("", "Tài khoản đã tồn tại.");
            }
            return View(model);
        }

        // Các phương thức khác của bạn
        // GET: QUAN_TRI
        public ActionResult Index()
        {
            return View(db.QUAN_TRI.ToList());
        }

        // GET: QUAN_TRI/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUAN_TRI qUAN_TRI = db.QUAN_TRI.Find(id);
            if (qUAN_TRI == null)
            {
                return HttpNotFound();
            }
            return View(qUAN_TRI);
        }

        // GET: QUAN_TRI/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QUAN_TRI/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Tai_khoan,Mat_khau,Trang_thai")] QUAN_TRI qUAN_TRI)
        {
            if (ModelState.IsValid)
            {
                db.QUAN_TRI.Add(qUAN_TRI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(qUAN_TRI);
        }

        // GET: QUAN_TRI/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUAN_TRI qUAN_TRI = db.QUAN_TRI.Find(id);
            if (qUAN_TRI == null)
            {
                return HttpNotFound();
            }
            return View(qUAN_TRI);
        }

        // POST: QUAN_TRI/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Tai_khoan,Mat_khau,Trang_thai")] QUAN_TRI qUAN_TRI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qUAN_TRI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(qUAN_TRI);
        }

        // GET: QUAN_TRI/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUAN_TRI qUAN_TRI = db.QUAN_TRI.Find(id);
            if (qUAN_TRI == null)
            {
                return HttpNotFound();
            }
            return View(qUAN_TRI);
        }

        // POST: QUAN_TRI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            QUAN_TRI qUAN_TRI = db.QUAN_TRI.Find(id);
            db.QUAN_TRI.Remove(qUAN_TRI);
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
