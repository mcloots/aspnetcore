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

namespace HelloCore.Controllers
{
    public class BestellingController : Controller
    {
        private readonly HelloCoreContext _context;

        public BestellingController(HelloCoreContext context)
        {
            _context = context;
        }

        // GET: Bestelling
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
                viewModel.Bestellingen = await _context.Bestellingen.Include(b => b.Klant).Where(b => b.Artikel.StartsWith(viewModel.ArtikelSearch)).ToListAsync();
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
    }
}
