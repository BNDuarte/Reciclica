using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Reciclica.Web.Models;
using Reciclica.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Reciclica.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Pesquisa(string searchString = null)
        {
            // var pontos = _context.Ponto.Include(e => e.Empresa).Include(m => m.Material)
            //             .Where(s=>s.Material.Descricao.Contains(searchString)).ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                var pontos = _context.Ponto.Include(e => e.Empresa).Include(m => m.Material)
                    .Where(s=>s.Material.Descricao.Contains(searchString)).ToList();
                
                ViewBag.Material=searchString;
                return View(pontos);
            }
            
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
