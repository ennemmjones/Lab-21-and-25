using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab21.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Lab21.Controllers
{
    public class TempMovieData
    {
        public static List<Movie> Movies = new List<Movie>();
       
    }
    public class MovieRegistrationController : Controller
    {
        private List<Movie> _allMovies;
        

        public MovieRegistrationController()
        {
            _allMovies = TempMovieData.Movies;
        }
        // GET: MovieRegistrationController
        public ActionResult Index()
        {
            return View(_allMovies);
        }
        public ActionResult Result(string movieTitle)
        {
            ViewData["Message"] = $"{movieTitle} has been registered";
            return View();
        }

        // GET: MovieRegistrationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MovieRegistrationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovieRegistrationController/Create
        [HttpPost]
        
        public ActionResult Create([Bind("Id", "Title", "Genre", "Year", "Actors", "Directors")]Movie newItem)
        {
            try
            {
                TempMovieData.Movies.Add(newItem);
                var movie = newItem.Title;
                
                return RedirectToAction(nameof(Result), new { movieTitle = movie });
                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieRegistrationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MovieRegistrationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieRegistrationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MovieRegistrationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
