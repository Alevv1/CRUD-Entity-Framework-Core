using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TestProyecto.Data;
using TestProyecto.Models;

namespace TestProyecto.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _context;


            public HomeController(ApplicationDbContext context)
            {
                _context = context;
            }







        [HttpGet]
        public async Task <IActionResult> Index()
        {
            return View(await _context.Contacto.ToListAsync());
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Contacto contacto)
        {
            if (ModelState.IsValid)
            {

                //agregar fecha
                contacto.FechaCreacion = DateTime.Now;


                _context.Contacto.Add(contacto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");

            }

            return View();
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
