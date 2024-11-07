using K22cntt3_pvv_project2.Models;
using System;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace K22cntt3_pvv_project2.Controllers
{
    public class LoginController : Controller
    {
        // Lấy chuỗi kết nối từ web.config
        private readonly string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        // Hiển thị form đăng nhập
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // Xử lý đăng nhập khi người dùng gửi form
        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // Kết nối với cơ sở dữ liệu để kiểm tra tài khoản và mật khẩu
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(1) FROM QUAN_TRI WHERE Tai_khoan = @Tai_khoan AND Mat_khau = @Mat_khau";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Tai_khoan", model.Tai_khoan);
                    cmd.Parameters.AddWithValue("@Mat_khau", model.Mat_khau); // Mật khẩu trong thực tế cần mã hóa

                    try
                    {
                        conn.Open();
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        conn.Close();

                        // Kiểm tra số lượng kết quả trả về
                        if (count == 1)
                        {
                            Session["Tai_khoan"] = model.Tai_khoan; // Lưu tài khoản vào session
                            return RedirectToAction("Index", "Home"); // Chuyển hướng đến trang chính
                        }
                        else
                        {
                            ViewBag.ErrorMessage = "Tên đăng nhập hoặc mật khẩu không đúng!";
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log lỗi nếu có và thông báo cho người dùng
                        ViewBag.ErrorMessage = "Đã xảy ra lỗi trong quá trình đăng nhập. Vui lòng thử lại.";
                    }
                }
            }
            return View(model); // Trả lại View nếu đăng nhập không thành công
        }

        // Đăng xuất
        public ActionResult Logout()
        {
            Session.Clear(); // Xóa session khi đăng xuất
            return RedirectToAction("Index", "Login"); // Chuyển hướng về trang đăng nhập
        }
    }
}
