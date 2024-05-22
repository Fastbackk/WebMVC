using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCproject.Models;
using System.Linq;

namespace MVCproject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var arabalar = _context.arabalar.ToList();

            if (arabalar == null)
            {
                arabalar = new List<ArabaModel>();
            }

            return View(arabalar);
        }

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(ArabaModel araba)
        {
            if (araba == null)
            {
                return BadRequest("Araba bilgisi boş olamaz.");
            }

            _context.arabalar.Add(araba);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Detay(int id)
        {
            var araba = _context.arabalar.FirstOrDefault(a => a.Id == id);
            if (araba == null)
            {
                return NotFound();
            }

            return View(araba);
        }

        public IActionResult Duzenle(int id)
        {
            var araba = _context.arabalar.FirstOrDefault(a => a.Id == id);
            if (araba == null)
            {
                return NotFound();
            }

            return View(araba);
        }

        [HttpPost]
        public IActionResult Duzenle(ArabaModel araba)
        {
            if (araba == null)
            {
                return BadRequest("Araba bilgisi boş olamaz.");
            }

            var mevcutAraba = _context.arabalar.FirstOrDefault(a => a.Id == araba.Id);
            if (mevcutAraba == null)
            {
                return NotFound();
            }

            mevcutAraba.Marka = araba.Marka;
            mevcutAraba.Model = araba.Model;
            mevcutAraba.Yil = araba.Yil;
            mevcutAraba.Yakit = araba.Yakit;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Sil(int id)
        {
            var araba = _context.arabalar.FirstOrDefault(a => a.Id == id);
            if (araba == null)
            {
                return NotFound();
            }

            _context.arabalar.Remove(araba);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
