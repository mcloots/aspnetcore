using HelloCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Encodings.Web;

namespace HelloCore.Controllers
{
    public class KlantController : Controller
    {
        // 
        // GET: /Klant/

        public IActionResult Index()
        {
            //Get list of klanten
            List<Klant> vKlanten = new List<Klant>();

            vKlanten.Add(new Klant() {Id = 1, Naam ="De Neve", Voornaam="Jos", AangemaaktDatum = new System.DateTime(2019,1,20)});
            vKlanten.Add(new Klant() {Id = 2, Naam ="Bruynseels", Voornaam="Rita", AangemaaktDatum = new System.DateTime(2019,2,4)});
            vKlanten.Add(new Klant() {Id = 3, Naam ="Naert", Voornaam="Willy", AangemaaktDatum = new System.DateTime(2018,12,29)});

            return View(vKlanten);
        }
    }
}
