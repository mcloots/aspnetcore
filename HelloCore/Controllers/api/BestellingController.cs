using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloCore.Data;
using HelloCore.Data.UnitOfWork;
using HelloCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloCore.Controllers.api
{
    [Route("api/[controller]")]
    public class BestellingController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly HelloCoreContext _context;
        public BestellingController(HelloCoreContext context, IUnitOfWork uow)
        {
            _context = context;
            _uow = uow;
        }

        // GET: api/<controller>
        //[Authorize]
        [HttpGet]
        public IEnumerable<Bestelling> Get()
        {
            //var claims = User.Claims;
            //return _context.Bestellingen.ToList();
            var vBestellingen = _uow.BestellingRepository.All();
            return vBestellingen;
        }

        // GET: api/<controller>
        [HttpGet("bestellingen")]
        public IEnumerable<Bestelling> GetBestellingen()
        {
            return _context.Bestellingen.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Bestelling Get(int id)
        {
            return _context.Bestellingen.Find(id);
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult<Bestelling> PostBestelling([FromBody]Bestelling value)
        {
            try
            {
                _uow.BestellingRepository.Add(value);
                _uow.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return CreatedAtAction(nameof(Get), new { id = value.BestellingID }, value);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult PutBestelling(int id, [FromBody]Bestelling value)
        {
            if (id != value.BestellingID)
            {
                return BadRequest();
            }

            var vOldBestelling = _context.Bestellingen.Find(id);

            vOldBestelling.Artikel = value.Artikel;
            vOldBestelling.KlantID = value.KlantID;
            vOldBestelling.Prijs = value.Prijs;

            _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteBestelling(int id)
        {
            var vBestelling = _context.Bestellingen.Find(id);

            if (vBestelling == null)
            {
                return NotFound();
            }

            _context.Bestellingen.Remove(vBestelling);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
