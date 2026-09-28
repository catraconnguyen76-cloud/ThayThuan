using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANLYBANHANG_MVC.Controllers
{
    public class KhachHangController : Controller
    {
        private dbQUANLYBANHANGEntities db = new dbQUANLYBANHANGEntities();

        // GET: KhachHang/DangNhap - Hiển thị form đăng nhập
        public ActionResult DangNhap()
        {
            ViewBag.lstDanhMuc = db.tbDANHMUCs.ToList();
            return View();
        }

        // POST: KhachHang/DangNhap - Xử lý đăng nhập
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(string txtUserName, string txtPassWord)
        {
            ViewBag.lstDanhMuc = db.tbDANHMUCs.ToList();

            if (string.IsNullOrEmpty(txtUserName) || string.IsNullOrEmpty(txtPassWord))
            {
                ViewBag.ThongBao = "Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!";
                return View();
            }

            // Kiểm tra tài khoản admin
            if (txtUserName == "admin" && txtPassWord == "admin")
            {
                Session["ADMIN"] = "admin";
                Session["TEN_NGUOI_DUNG"] = "Quản trị viên";
                return RedirectToAction("Index", "Trangchu");
            }

            // Kiểm tra tài khoản khách hàng trong database
            var khachHang = db.tbKHANHHANGs.FirstOrDefault(kh =>
                kh.TAIKHOAN == txtUserName && kh.MATKHAU == txtPassWord);

            if (khachHang != null)
            {
                Session["LOGIN"] = khachHang.MAKHACHHANG;
                Session["TEN_NGUOI_DUNG"] = khachHang.HOTENKH;
                ViewBag.ThongBao = "Đăng nhập thành công! Xin chào " + khachHang.HOTENKH;
                return RedirectToAction("Index", "Trangchu");
            }
            else
            {
                ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng. Vui lòng thử lại!";
                return View();
            }
        }

        // GET: KhachHang/DangXuat
        public ActionResult DangXuat()
        {
            Session.Clear();
            return RedirectToAction("Index", "Trangchu");
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
