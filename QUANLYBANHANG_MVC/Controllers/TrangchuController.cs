using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANLYBANHANG_MVC.Controllers
{
    public class TrangchuController : Controller
    {
        // Khởi tạo đối tượng Entity Framework (dùng chung connection string trong Web.config)
        private dbQUANLYBANHANGEntities db = new dbQUANLYBANHANGEntities();

        // GET: Trangchu/Index - Trang chủ hiển thị danh sách sản phẩm
        public ActionResult Index()
        {
            // Lấy danh sách danh mục để hiển thị menu
            ViewBag.lstDanhMuc = db.tbDANHMUCs.ToList();

            // Lấy danh sách sản phẩm (dùng LINQ)
            var lstSanPham = from sp in db.tbSANPHAMs
                             select sp;

            return View(lstSanPham.ToList());
        }

        // GET: Trangchu/Details/5 - Trang chi tiết sản phẩm
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            tbSANPHAM sanpham = db.tbSANPHAMs.Find(id);

            if (sanpham == null)
            {
                return HttpNotFound();
            }

            // Lấy danh mục để hiển thị menu
            ViewBag.lstDanhMuc = db.tbDANHMUCs.ToList();

            return View(sanpham);
        }

        // GET: Trangchu/DanhSachTheoLoai/3 - Lọc sản phẩm theo danh mục
        public ActionResult DanhSachTheoLoai(int? id)
        {
            ViewBag.lstDanhMuc = db.tbDANHMUCs.ToList();

            var lstSanPham = from sp in db.tbSANPHAMs
                             where sp.MADANHMUC == id
                             select sp;

            return View("Index", lstSanPham.ToList());
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
