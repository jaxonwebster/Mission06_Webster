using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult MovieForm()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
             
            return View("MovieForm", new Movies());
        }

        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public IActionResult MovieForm(Movies response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response); //Adds record to database
                _context.SaveChanges();
                return View("Confirmation");
            }
            else //Invalid Data
            {
                ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
                return View(response);
            }
        }

        public IActionResult Waitlist()
        {
        
            //Linq
            var forms = _context.Movies
                .OrderBy(x => x.Title).ToList();

            return View(forms);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View("MovieForm", recordToEdit);
        }
        [HttpPost]
        public IActionResult Edit(Movies updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();
            return RedirectToAction("Waitlist");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);
            return View(recordToDelete);
        }
        [HttpPost]
        public IActionResult Delete(Movies form)
        {
            _context.Movies.Remove(form);
            _context.SaveChanges();
            return RedirectToAction("Waitlist");
        }
    }
}
