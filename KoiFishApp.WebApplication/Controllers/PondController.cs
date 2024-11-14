using KoiFishApp.Repositories.Entities;
using KoiFishApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KoiFishApp.WebApplication.Controllers
{
    public class PondController : Controller
    {
        private readonly IPondServices _pondServices;
        private readonly QlcktnContext _context;

        public PondController(IPondServices pondServices, QlcktnContext context)
        {
            _pondServices = pondServices;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var ponds = await _pondServices.GetAllPondsAsync();
            return View(ponds);
        }

        public IActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pond pond)
        {
            if (ModelState.IsValid)
            {
                _context.Ponds.Add(pond);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pond); 
        }

        public async Task<IActionResult> Edit(int id)
        {
            var pond = await _pondServices.GetAllPondsAsync();
            var selectedPond = pond.FirstOrDefault(p => p.PondId == id);

            if (selectedPond == null)
            {
                return NotFound();
            }

            return View(selectedPond); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Pond pond)
        {
            if (id != pond.PondId)
            {
                return NotFound(); 
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pond);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PondExists(pond.PondId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pond);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var pond = await _pondServices.GetAllPondsAsync();
            var selectedPond = pond.FirstOrDefault(p => p.PondId == id);

            if (selectedPond == null)
            {
                return NotFound(); 
            }

            return View(selectedPond); 
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pond = await _pondServices.GetAllPondsAsync();
            var selectedPond = pond.FirstOrDefault(p => p.PondId == id);

            if (selectedPond != null)
            {
                _context.Ponds.Remove(selectedPond);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index)); 
        }

        public async Task<IActionResult> Details(int id)
        {
            var ponds = await _pondServices.GetAllPondsAsync();
            var selectedPond = ponds.FirstOrDefault(p => p.PondId == id);

            if (selectedPond == null)
            {
                return NotFound(); 
            }

            return View(selectedPond); 
        }


        private bool PondExists(int id)
        {
            return _context.Ponds.Any(e => e.PondId == id);
        }
    }
}
