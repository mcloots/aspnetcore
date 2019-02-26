using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelloCore.Data;
using HelloCore.Models;
using HelloCore.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace HelloCore.Controllers
{
    [Authorize]
    public class BestellingController : Controller
    {
        private readonly HelloCoreContext _context;

        public BestellingController(HelloCoreContext context)
        {
            _context = context;
        }

        // GET: Bestelling
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var viewModel = new ListBestellingViewModel();
            viewModel.Bestellingen = await _context.Bestellingen.Include(b => b.Klant).ToListAsync();
            return View(viewModel);
        }

        // GET: Bestelling gefilterd op artikel
        public async Task<IActionResult> Search(ListBestellingViewModel viewModel)
        {
            if (!string.IsNullOrEmpty(viewModel.ArtikelSearch))
            {
                viewModel.Bestellingen = await _context.Bestellingen.Include(b => b.Klant)
                    .Where(b => b.Artikel.StartsWith(viewModel.ArtikelSearch)).ToListAsync();
            } else
            {
                viewModel.Bestellingen = await _context.Bestellingen.Include(b => b.Klant).ToListAsync();
            }

            return View("Index", viewModel);
        }

        // GET: Bestelling/Create
        public IActionResult Create()
        {
            var viewModel = new CreateBestellingViewModel();
            viewModel.Bestelling = new Bestelling();
            viewModel.Klanten = new SelectList(_context.Klanten, "KlantID", "Naam");
            return View(viewModel);
        }

        // POST: Bestelling/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBestellingViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viewmodel.Bestelling);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            viewmodel.Klanten = new SelectList(_context.Klanten, "KlantID", "Naam");
            return View(viewmodel);
        }

        // GET: Bestelling/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Bestelling = await _context.Bestellingen.FindAsync(id);
            if (Bestelling == null)
            {
                return NotFound();
            }

            ViewBag.Klanten = new SelectList(_context.Klanten, "KlantID", "Naam");
            return View(Bestelling);
        }

        // POST: Bestelling/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BestellingID,Artikel,KlantID,Prijs")] Bestelling Bestelling)
        {
            if (id != Bestelling.BestellingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Bestelling);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BestellingExists(Bestelling.BestellingID))
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
            ViewBag.Klanten = new SelectList(_context.Klanten, "KlantID", "Naam");
            return View(Bestelling);
        }

        // GET: Bestelling/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Bestelling = await _context.Bestellingen.Include(b => b.Klant)
                .FirstOrDefaultAsync(m => m.BestellingID == id);
            if (Bestelling == null)
            {
                return NotFound();
            }

            return View(Bestelling);
        }

        // POST: Bestelling/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Bestelling = await _context.Bestellingen.FindAsync(id);
            _context.Bestellingen.Remove(Bestelling);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BestellingExists(int id)
        {
            return _context.Bestellingen.Any(e => e.BestellingID == id);
        }

        // GET: Bestelling/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Bestelling = await _context.Bestellingen.Include(b=>b.Klant)
                .FirstOrDefaultAsync(m => m.BestellingID == id);
            if (Bestelling == null)
            {
                return NotFound();
            }

            return View(Bestelling);
        }
    }
}
