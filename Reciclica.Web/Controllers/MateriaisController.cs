using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reciclica.Web.Materiais;
using Microsoft.EntityFrameworkCore;
using Reciclica.Web.Data;

namespace Reciclica.Web.Controllers
{
    public class MateriaisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MateriaisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mateiral
        public ActionResult Index()
        {
            var materiais = _context.Material.ToList();
            return View(materiais);
        }

        // GET: Mateiral/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Mateiral/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mateiral/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Material material)
        {
                _context.Add(material);
                _context.SaveChanges();
                 
                return RedirectToAction(nameof(Index));

        }

        // GET: Mateiral/Edit/5
        public  IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var material = _context.Material.SingleOrDefault(m => m.Id == id);
            if (material == null)
                return NotFound();

            return View(material);
        }

        // POST: Mateiral/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Material material)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(material);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialExists(material.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(material);
        }

        // GET: Mateiral/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var material = _context.Material.SingleOrDefault(m => m.Id == id);
            if (material == null)
                return NotFound();

            return View(material);
        }

        // POST: Materiais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var material =_context.Material.SingleOrDefault(m => m.Id == id);
            _context.Material.Remove(material);
            _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaterialExists(int id)
        {
            return _context.Material.Any(e => e.Id == id);
        }
    }
}