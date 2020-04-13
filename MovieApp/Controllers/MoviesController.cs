using MovieApp.Models;
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
            // return View(movie);
            //return Content("Hello World from Content Result");
            //return HttpNotFound();
            return RedirectToAction("Index", "Home", new { page = 1, sortby = "name" });
        }
    }
}