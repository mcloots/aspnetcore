using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace HelloCore.Controllers
{
    public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/

        public string Index()
        {
            return "Dit is de 'Index' Action Method";
        }

        // 
        // GET: /HelloWorld/Welkom/ 

        public string Welkom()
        {
            return "Dit is de 'Welkom' Action Method";
        }

        public string Bestelling(int id)
        {
            return "Dit zijn de details van bestelling met id " + id;
        }

        public string Boodschap(string voornaam, string boodschap)
        {
            return "Boodschap van " + voornaam + ": " + boodschap;
        }
    }
}
