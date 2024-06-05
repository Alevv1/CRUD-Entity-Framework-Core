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





        //Funcion Crear Usuario

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

        //Funcion Editar Usuario

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = _context.Contacto.Find(id);
            if (contacto == null)
            {
                return NotFound();
            }



            return View(contacto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Contacto contacto)
        {
            if (ModelState.IsValid)
            {

                contacto.FechaCreacion = DateTime.Now;

                _context.Update(contacto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");

            }

            return View();
        }


        [HttpGet]
        public IActionResult Detalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = _context.Contacto.Find(id);
            if (contacto == null)
            {
                return NotFound();
            }



            return View(contacto);
        }


        public IActionResult Borrar(int id)
        {
            var contacto = _context.Contacto.Find(id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }

        // Acción para manejar la eliminación del registro
        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var contacto = _context.Contacto.Find(id);
            if (contacto == null)
            {
                return NotFound();
            }

            _context.Contacto.Remove(contacto);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
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
