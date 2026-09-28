using System;
using System.Linq;
using System.Web.Mvc;

namespace QUANLYBANHANG_MVC.Controllers
{
    public class AdminDanhMucController : Controller
    {
        private dbQUANLYBANHANGEntities db = new dbQUANLYBANHANGEntities();

        // Kiểm tra quyền admin
        private bool IsAdmin()
        {
            return Session["ADMIN"] != null;
        }

        // GET: AdminDanhMuc - Danh sách danh mục
        public ActionResult Index()
        {
            if (!IsAdmin())
                return RedirectToAction("DangNhap", "KhachHang");

            var lstDanhMuc = db.tbDANHMUCs.ToList();
            return View(lstDanhMuc);
        }

        // GET: AdminDanhMuc/ThemMoi - Form thêm danh mục mới
        public ActionResult ThemMoi()
        {
            if (!IsAdmin())
                return RedirectToAction("DangNhap", "KhachHang");

            return View();
        }

        // POST: AdminDanhMuc/ThemMoi - Xử lý thêm mới
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemMoi(string TENDANHMUC, int? DANHMUCCHA, string MOTA)
        {
            if (!IsAdmin())
                return RedirectToAction("DangNhap", "KhachHang");

            if (string.IsNullOrEmpty(TENDANHMUC))
            {
                ViewBag.ThongBao = "Vui lòng nhập tên danh mục!";
                return View();
            }

            var danhMuc = new tbDANHMUC
            {
                TENDANHMUC = TENDANHMUC,
                DANHMUCCHA = DANHMUCCHA,
                MOTA = MOTA
            };

            db.tbDANHMUCs.Add(danhMuc);
            db.SaveChanges();

            TempData["ThanhCong"] = "Thêm danh mục '" + TENDANHMUC + "' thành công!";
            return RedirectToAction("Index");
        }

        // GET: AdminDanhMuc/SuaDoi/5 - Form sửa danh mục
        public ActionResult SuaDoi(int? id)
        {
            if (!IsAdmin())
                return RedirectToAction("DangNhap", "KhachHang");

            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var danhMuc = db.tbDANHMUCs.Find(id);
            if (danhMuc == null)
                return HttpNotFound();

            return View(danhMuc);
        }

        // POST: AdminDanhMuc/SuaDoi - Xử lý cập nhật
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaDoi(int MADANHMUC, string TENDANHMUC, int? DANHMUCCHA, string MOTA)
        {
            if (!IsAdmin())
                return RedirectToAction("DangNhap", "KhachHang");

            if (string.IsNullOrEmpty(TENDANHMUC))
            {
                var danhMucView = db.tbDANHMUCs.Find(MADANHMUC);
                ViewBag.ThongBao = "Vui lòng nhập tên danh mục!";
                return View(danhMucView);
            }

            var danhMuc = db.tbDANHMUCs.Find(MADANHMUC);
            if (danhMuc != null)
            {
                danhMuc.TENDANHMUC = TENDANHMUC;
                danhMuc.DANHMUCCHA = DANHMUCCHA;
                danhMuc.MOTA = MOTA;
                db.SaveChanges();
            }

            TempData["ThanhCong"] = "Cập nhật danh mục '" + TENDANHMUC + "' thành công!";
            return RedirectToAction("Index");
        }

        // POST: AdminDanhMuc/Xoa/5 - Xóa danh mục
        [HttpPost]
        public ActionResult Xoa(int id)
        {
            if (!IsAdmin())
                return Json(new { success = false, message = "Không có quyền!" });

            try
            {
                var danhMuc = db.tbDANHMUCs.Find(id);
                if (danhMuc != null)
                {
                    db.tbDANHMUCs.Remove(danhMuc);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Đã xóa danh mục thành công!" });
                }
                return Json(new { success = false, message = "Không tìm thấy danh mục!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Không thể xóa! Danh mục này đang có sản phẩm liên quan." });
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}
