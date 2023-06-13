using demo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace demo.Controllers
{
    public class SinhVienController : Controller
    {
        public static List<SinhVien> sinhviens = new List<SinhVien>()
            {
                new SinhVien(){ID="sv1",Name="Đức văn",Age="19"},
                new SinhVien(){ID="sv2",Name="Anh Sáng",Age="05"},
                new SinhVien(){ID="sv3",Name="Thiên thần",Age="37"},
                new SinhVien(){ID="sv4",Name="Việt nam",Age="41"},
            };
        public IActionResult Index()
        {
            return View(sinhviens);
        }
        public IActionResult ThemMoi() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult ThemMoi(SinhVien sinhVien) 
        {
            sinhviens.Add(sinhVien );
            return RedirectToAction("Index");
        }
        public IActionResult Xoa(string id)
        {
            var xoa = sinhviens.SingleOrDefault(m => m.ID == id);
            sinhviens.Remove(xoa);
            return RedirectToAction("Index");
        }
        public IActionResult ChiTiet(string id)
        {
            var chitiet = sinhviens.SingleOrDefault(m=>m.ID == id);
            ViewBag.Id = id;
            return View(chitiet);
        }
        public IActionResult Sua(string id)
        {
            var sua = sinhviens.SingleOrDefault(m=>m.ID == id);
            return View(sua);
        }
        [HttpPost]
        public IActionResult Sua(SinhVien sinhVien)
        {
            var sua = sinhviens.SingleOrDefault(m=>m.ID == sinhVien.ID);
            sua.Name= sinhVien.Name;
            sua.Age= sinhVien.Age;
            sinhviens.Remove(sua);
            sinhviens.Add(sinhVien);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult TimKiem()
        {
            string data = Request.Form["datatimkiem"];
            var datatimkiem = sinhviens.SingleOrDefault(m=>m.ID== data);
            if(datatimkiem != null)
            {
                ViewBag.id = datatimkiem.ID;
                ViewBag.name = datatimkiem.Name;
                ViewBag.age = datatimkiem.Age;
                return View(datatimkiem);
            }
            else
            {
                ViewBag.id = "Không có kết quả";
                ViewBag.name = "Không có kết quả";
                ViewBag.age = "Không có kết quả";
                return View(datatimkiem);
            }
        }

    }
}
