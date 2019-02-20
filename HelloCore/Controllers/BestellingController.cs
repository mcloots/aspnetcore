using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelloCore.Data;
using HelloCore.Models;

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
            return View(await _context.Bestellingen.Include(b=>b.Klant).ToListAsync());
        }   

         // GET: Bestelling/Create
        public IActionResult Create()
        {
            ViewBag.KlantenLijst = new SelectList(_context.Klanten,"KlantID","Naam");
            return View();
        }

        // POST: Bestelling/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BestellingID,Artikel,KlantID,Prijs")] Bestelling bestelling)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bestelling);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.KlantenLijst = new SelectList(_context.Klanten, "KlantID", "Naam");
            return View(bestelling);
        }   
    }
}
