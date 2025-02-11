using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission6.Models;

namespace Mission6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) //Constructor
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult FillOutForm()
        {
            return View("MovieForm");
        }

        [HttpPost]
        public IActionResult MovieForm(Form response)
        {
            return View("Confirmation");
        }
    }
}
