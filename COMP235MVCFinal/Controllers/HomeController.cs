using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using COMP235MVCFinal.DataAccessObjects;
using COMP235MVCFinal.Models;

namespace COMP235MVCFinal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Movie()
        {
            ViewBag.Message = "My Movie Page.";
            MovieDAO dAO = new MovieDAO();
            Movie m = dAO.getMovieById(1);
            return View(m);
        }

        public ActionResult AddMovie(Movie m, string Save) // each view need an Action
                                                           //Result Method to be viewed
        {
            ViewBag.Message = "Add A Movie Page";
            //Save is the name of the Value on the Button
            if (Save == "Save")
            {
                MovieDAO dAO = new MovieDAO();
                dAO.InsertMovie(m);
                ViewBag.Message = "Movie Added successfully";
            }
            return View("AddMovie");

        }

        public ActionResult AllMovies(Movies m)
        {
            ViewBag.Message = "All movies.";
            MovieDAO dAO = new MovieDAO();
            m = dAO.getAllMovies();
            return View(m);
        }

        public ActionResult Details(Movie movie)
        {
            MovieDAO dAO = new MovieDAO();
            movie = dAO.getMovieById(movie.Id);
            return View("Movie", movie);
        }


    }
}