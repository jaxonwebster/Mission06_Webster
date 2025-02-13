using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission6.Models;

namespace Mission6.Controllers
{


    public class HomeController : Controller
    {

        public IActionResult GetToKnowJoel()
        {
            return View();
        }


        private MovieFormContext _context;
        public HomeController(MovieFormContext temp) //constructor
        {
            _context = temp;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MovieForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(Form response)
        {
            _context.Forms.Add(response); //Adds record to database
            _context.SaveChanges();
            return View("Confirmation");
        }
    }
}
