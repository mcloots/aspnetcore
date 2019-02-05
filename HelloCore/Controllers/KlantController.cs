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
            //Get list of klanten from database!

            return View();
        }
    }
}
