using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloCore.Data;
using HelloCore.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloCore.Controllers.api
{
    [Route("api/[controller]")]
    public class BestellingController : Controller
    {
        private readonly HelloCoreContext _context;
        public BestellingController(HelloCoreContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Bestelling> Get()
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
        public void Post([FromBody]Bestelling value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Bestelling value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
