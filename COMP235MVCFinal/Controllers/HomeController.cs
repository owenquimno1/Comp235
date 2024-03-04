﻿using System;
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

        public ActionResult AllMovies(Movies m, String Save)
        {
            ViewBag.Message = "All movies.";
            MovieDAO dAO = new MovieDAO();
            if (Save == "Save")
            {
                Movie movie = m.Items[m.EditIndex];
                dAO.updateMovie(movie);
                movie.IsEditable = false;
                m.EditIndex = -1;
            }
            m = dAO.getAllMovies();
            return View(m);
        }

        public ActionResult Details(Movie movie)
        {
            MovieDAO dAO = new MovieDAO();
            movie = dAO.getMovieById(movie.Id);
            return View("Movie", movie);
        }

        public ActionResult MoviesEdit(int? id, Movies movies)
        {
            int id2 = id ?? default(int);
            MovieDAO dAO = new MovieDAO();
            movies = dAO.getAllMovies();
            movies.EditIndex = dAO.setMovieToEditMode(movies.Items, id2);
            ViewBag.Message = "All movies.";
            return View("AllMovies", movies);
        }

        public ActionResult DeleteMovie(int id)
        {
            MovieDAO dAO = new MovieDAO();
            dAO.deleteMovie(id); // Implement the deleteMovie method in your DAO
            return RedirectToAction("AllMovies");
        }

        [HttpPost]
        public ActionResult Update(Movie movie)
        {
            MovieDAO dao = new MovieDAO();
            dao.updateMovie(movie);
            return RedirectToAction("Details", new { id = movie.Id });
        }

        public ActionResult EditMovie(int id)
        {
            MovieDAO dao = new MovieDAO();
            Movie movie = dao.getMovieById(id);

            ViewBag.ShowEditForm = true;
            return View("Movie", movie);
        }


    }
}