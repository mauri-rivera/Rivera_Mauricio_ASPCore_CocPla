using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CocPla.DAO;
using CocPla.Models;

namespace CocPla.Controllers
{
    public class ChefController : Controller
    {
        private readonly MyContext _context;

        public ChefController(MyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Chef> listaChefs = _context.Cocineros.Include(t => t.TotalPlatos).ToList();

            return View(listaChefs);
        }

        [Route("chefs/new")]
        public IActionResult AgregarChef()
        {            
            return View();
        }

        [HttpPost("chefs/new")]
        public IActionResult AgregarChef(Chef newchef)
        {
            newchef.NombreCompleto = $"{newchef.FirstName} {newchef.LastName}";

            if (ModelState.IsValid)
            {
                _context.Add(newchef);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        private bool ChefExists(int id)
        {
            return (_context.Cocineros?.Any(e => e.ChefId == id)).GetValueOrDefault();
        }
    }
}
