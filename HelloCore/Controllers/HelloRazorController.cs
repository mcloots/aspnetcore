using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace HelloCore.Controllers
{
    public class HelloRazorController : Controller
    {
        // 
        // GET: /HelloRazor/

        public IActionResult Index()
        {
            ViewData["Title"] = "Hoi Razor";
            return View();
        }

        public IActionResult Hallo(string naam, int aantal = 1)
        {
            ViewData["Message"] = "Hallo " + naam;
            ViewData["Aantal"] = aantal;

            return View();
        }
    }
}
