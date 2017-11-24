using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Reciclica.Web.Pontos;
using Microsoft.EntityFrameworkCore;
using Reciclica.Web.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Reciclica.Web.Controllers
{
    public class PontosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PontosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mateiral
        public ActionResult Index()
        {
            var pontos = _context.Ponto.Include(e=>e.Empresa).Include(m=>m.Material).ToList();
            return View(pontos);
        }

        // GET: Mateiral/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Mateiral/Create
        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }

        // POST: Mateiral/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ponto ponto)
        {
                _context.Add(ponto);
                _context.SaveChanges();
                 
                return RedirectToAction(nameof(Index));

        }

        // GET: Mateiral/Edit/5
        public  IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var ponto = _context.Ponto.SingleOrDefault(m => m.Id == id);
            if (ponto == null)
                return NotFound();
            
            PopularViewBag(ponto);
            return View(ponto);
        }

        // POST: Mateiral/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Ponto ponto)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ponto);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PontoExists(ponto.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ponto);
        }

        // GET: Mateiral/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var ponto = _context.Ponto.SingleOrDefault(m => m.Id == id);
            if (ponto == null)
                return NotFound();

            return View(ponto);
        }

        // POST: Materiais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var ponto =_context.Ponto.SingleOrDefault(m => m.Id == id);
            _context.Ponto.Remove(ponto);
            _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PontoExists(int id)
        {
            return _context.Ponto.Any(e => e.Id == id);
        }
        private void PopularViewBag(Ponto ponto = null)
        {
            if (ponto == null)
            {
                ViewBag.EmpresaId = new SelectList(_context.Empresa.OrderBy(e=>e.Nome),"Id","Nome");
                ViewBag.MaterialId = new SelectList(_context.Material.OrderBy(m=>m.Descricao),"Id","Descricao");
            }
            else
            {
                ViewBag.EmpresaId = new SelectList(_context.Empresa.OrderBy(e=>e.Nome), "Id", "Nome", ponto.EmpresaId);
                ViewBag.MaterialId = new SelectList(_context.Material.OrderBy(m=>m.Descricao),"Id","Descricao",ponto.MaterialId);
            }
        }
    }
}