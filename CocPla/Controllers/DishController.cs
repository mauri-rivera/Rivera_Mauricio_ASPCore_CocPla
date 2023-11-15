using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CocPla.DAO;
using CocPla.Models;
using NHibernate.Linq;

namespace CocPla.Controllers
{
    public class DishController : Controller
    {
        private readonly MyContext _context;

        public string NombreChef { get; private set; }

        public DishController(MyContext context)
        {
            _context = context;
        }

        [Route("dishes")]
        public IActionResult Index()
        {
            List<Dish> listaDishs = _context.Dishes.Include(c => c.Cocinero).ToList();

            return View(listaDishs);
        }

        [Route("dishes/new")]
        public IActionResult AgregarDish()
        {
            List<Chef> listaChefs = _context.Cocineros.ToList();

            ViewBag.NombreCompleto = listaChefs.Select(n => n.NombreCompleto);

            return View();
        }

        [HttpPost("dishes/new")]
        public IActionResult AgregarDish(Dish newdish, string nombreCompleto)
        {
            newdish.ChefId = _context.Cocineros.Where(n => n.NombreCompleto == nombreCompleto).Select(n => n.ChefId).Take(1).First();

            if (ModelState.IsValid)
            {
                _context.Add(newdish);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        private bool DishExists(int id)
        {
            return (_context.Dishes?.Any(e => e.DishId == id)).GetValueOrDefault();
        }
    }
}
