using Microsoft.Ajax.Utilities;
using MovieApp.Models;
using MovieApp.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieApp.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer> {
                new Customer {Name="customer1"},
                new Customer{Name="customer2"}
            };
            var viewmodel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            //ViewData["Movie"] = movie;
            // ViewBag.Movie = movie;
            return View(viewmodel);

            //return Content("Hello World from Content Result");
            //return HttpNotFound();
            // return RedirectToAction("Index", "Home", new { page = 1, sortby = "name" });
        }
        public ActionResult Edit(int movieid)
        {
            return Content("Id= " + movieid);
        }
        public ActionResult Index(int pageindex, string sortBy)
        {
            //if (!pageindex.HasValue)
            //    pageindex = 1;
            if (string.IsNullOrEmpty(sortBy))
                sortBy = "name";
            return Content(String.Format("Pageindex={0},Sort By={1}", pageindex, sortBy));
        }
        [Route("movies/released/{year}/{month:range(1,12)}")]
        public ActionResult ByReleasedDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        //creating login page
        public ActionResult Login()
        {
            ViewBag.Countries = new List<string>()
            {
                "India","US","Australia", "Finland","Sweden"
            };
            //ViewData["Countries"] = new List<string>()
            //{
            //    "India","US","Australia", "Finland","Sweden"
            //};
            
            return View();
           

        }
        public ActionResult HomePage()
        {
            string DisplayName = TempData["DisplayName"].ToString();
            return View();
        }
        [HttpPost]
        public ActionResult Login(RandomMovieViewModel viewmodel)
        {

            var username = viewmodel.Uname;
            var password = viewmodel.Password;
            
            if (username == "binta" && password == "selu123")
            {
                TempData["DisplayName"] = username;
                return RedirectToAction("HomePage");
            }
          
            return View();
        }

    }
}