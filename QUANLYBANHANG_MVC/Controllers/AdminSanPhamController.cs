using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANLYBANHANG_MVC.Controllers
{
    public class AdminSanPhamController : Controller
    {
        private dbQUANLYBANHANGEntities db = new dbQUANLYBANHANGEntities();

        private bool IsAdmin() => Session["ADMIN"] != null;

        // GET: AdminSanPham
        public ActionResult Index()
        {
            if (!IsAdmin()) return RedirectToAction("DangNhap", "KhachHang");

            var lst = db.tbSANPHAMs.OrderBy(sp => sp.MASANPHAM).ToList();
            return View(lst);
        }

        // GET: AdminSanPham/ThemMoi
        public ActionResult ThemMoi()
        {
            if (!IsAdmin()) return RedirectToAction("DangNhap", "KhachHang");

            ViewBag.lstDanhMuc = new SelectList(db.tbDANHMUCs.ToList(), "MADANHMUC", "TENDANHMUC");
            return View();
        }

        // POST: AdminSanPham/ThemMoi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemMoi(string TENSANPHAM, decimal? DONGIA, decimal? SOLUONG,
            string MOTA, int? MADANHMUC, HttpPostedFileBase fileAnh)
        {
            if (!IsAdmin()) return RedirectToAction("DangNhap", "KhachHang");

            ViewBag.lstDanhMuc = new SelectList(db.tbDANHMUCs.ToList(), "MADANHMUC", "TENDANHMUC");

            if (string.IsNullOrEmpty(TENSANPHAM))
            {
                ViewBag.ThongBao = "Vui lòng nhập tên sản phẩm!";
                return View();
            }

            // Xử lý upload ảnh
            string tenFile = null;
            if (fileAnh != null && fileAnh.ContentLength > 0)
            {
                string[] allowedExt = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
                string ext = Path.GetExtension(fileAnh.FileName).ToLower();
                if (!allowedExt.Contains(ext))
                {
                    ViewBag.ThongBao = "Chỉ chấp nhận file ảnh: .jpg, .jpeg, .png, .gif, .bmp";
                    return View();
                }
                tenFile = fileAnh.FileName;
                string duongDan = Server.MapPath("~/images/") + tenFile;
                fileAnh.SaveAs(duongDan);
            }

            var sp = new tbSANPHAM
            {
                TENSANPHAM = TENSANPHAM,
                DONGIA = DONGIA,
                SOLUONG = SOLUONG,
                MOTA = MOTA,
                MADANHMUC = MADANHMUC,
                HINHANH = tenFile
            };
            db.tbSANPHAMs.Add(sp);
            db.SaveChanges();

            TempData["ThanhCong"] = "Thêm sản phẩm '" + TENSANPHAM + "' thành công!";
            return RedirectToAction("Index");
        }

        // GET: AdminSanPham/SuaDoi/5
        public ActionResult SuaDoi(int? id)
        {
            if (!IsAdmin()) return RedirectToAction("DangNhap", "KhachHang");
            if (id == null) return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var sp = db.tbSANPHAMs.Find(id);
            if (sp == null) return HttpNotFound();

            ViewBag.lstDanhMuc = new SelectList(db.tbDANHMUCs.ToList(), "MADANHMUC", "TENDANHMUC", sp.MADANHMUC);
            return View(sp);
        }

        // POST: AdminSanPham/SuaDoi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaDoi(int MASANPHAM, string TENSANPHAM, decimal? DONGIA,
            decimal? SOLUONG, string MOTA, int? MADANHMUC, HttpPostedFileBase fileAnh)
        {
            if (!IsAdmin()) return RedirectToAction("DangNhap", "KhachHang");

            var sp = db.tbSANPHAMs.Find(MASANPHAM);
            ViewBag.lstDanhMuc = new SelectList(db.tbDANHMUCs.ToList(), "MADANHMUC", "TENDANHMUC", MADANHMUC);

            if (sp == null) return HttpNotFound();

            if (string.IsNullOrEmpty(TENSANPHAM))
            {
                ViewBag.ThongBao = "Vui lòng nhập tên sản phẩm!";
                return View(sp);
            }

            // Xử lý upload ảnh mới (nếu có)
            if (fileAnh != null && fileAnh.ContentLength > 0)
            {
                string[] allowedExt = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
                string ext = Path.GetExtension(fileAnh.FileName).ToLower();
                if (!allowedExt.Contains(ext))
                {
                    ViewBag.ThongBao = "Chỉ chấp nhận file ảnh: .jpg, .jpeg, .png, .gif, .bmp";
                    return View(sp);
                }
                string tenFile = fileAnh.FileName;
                string duongDan = Server.MapPath("~/images/") + tenFile;
                fileAnh.SaveAs(duongDan);
                sp.HINHANH = tenFile;
            }

            sp.TENSANPHAM = TENSANPHAM;
            sp.DONGIA = DONGIA;
            sp.SOLUONG = SOLUONG;
            sp.MOTA = MOTA;
            sp.MADANHMUC = MADANHMUC;
            db.SaveChanges();

            TempData["ThanhCong"] = "Cập nhật sản phẩm '" + TENSANPHAM + "' thành công!";
            return RedirectToAction("Index");
        }

        // POST: AdminSanPham/Xoa
        [HttpPost]
        public ActionResult Xoa(int id)
        {
            if (!IsAdmin()) return Json(new { success = false, message = "Không có quyền!" });

            try
            {
                var sp = db.tbSANPHAMs.Find(id);
                if (sp != null)
                {
                    db.tbSANPHAMs.Remove(sp);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Đã xóa sản phẩm thành công!" });
                }
                return Json(new { success = false, message = "Không tìm thấy sản phẩm!" });
            }
            catch
            {
                return Json(new { success = false, message = "Không thể xóa! Sản phẩm này đang có trong đơn hàng." });
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}
