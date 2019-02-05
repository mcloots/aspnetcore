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
    }
}
