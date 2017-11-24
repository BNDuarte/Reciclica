using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Reciclica.Web.Empresas;
using Microsoft.EntityFrameworkCore;
using Reciclica.Web.Data;

namespace Reciclica.Web.Controllers
{
    public class EmpresasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmpresasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mateiral
        public ActionResult Index()
        {
            var empresas = _context.Empresa.ToList();
            return View(empresas);
        }

        // GET: Mateiral/Details/5
        public ActionResult Details(int id)
        {

            var empresa = _context.Empresa.SingleOrDefault(m => m.Id == id);
            if (empresa == null)
                return NotFound();

            return View(empresa);
        }

        // GET: Mateiral/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mateiral/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Empresa empresa)
        {
                _context.Add(empresa);
                _context.SaveChanges();
                 
                return RedirectToAction(nameof(Index));

        }

        // GET: Mateiral/Edit/5
        public  IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var empresa = _context.Empresa.SingleOrDefault(m => m.Id == id);
            if (empresa == null)
                return NotFound();

            return View(empresa);
        }

        // POST: Mateiral/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Empresa empresa)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empresa);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpresaExists(empresa.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(empresa);
        }

        // GET: Mateiral/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var empresa = _context.Empresa.SingleOrDefault(m => m.Id == id);
            if (empresa == null)
                return NotFound();

            return View(empresa);
        }

        // POST: Materiais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var empresa =_context.Empresa.SingleOrDefault(m => m.Id == id);
            _context.Empresa.Remove(empresa);
            _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpresaExists(int id)
        {
            return _context.Empresa.Any(e => e.Id == id);
        }
    }
}