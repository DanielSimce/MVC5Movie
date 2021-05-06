using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Models;
using MovieApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly DatabaseContext _context;
        public MoviesController(DatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var list = _context.Movies.Include(x => x.Genre).ToList();
            return View(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult<MovieVM> Post(MovieVM movieVM)
        {
            
           

            if (movieVM.Id == 0)
            {
                var movie = new Movie
                {

                    Name = movieVM.Name,
                    GenreId = movieVM.GenreId,
                    DateRelease = movieVM.DateRelease
                };
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Find(movieVM.Id);
                movieInDb.Name = movieVM.Name;
                movieInDb.GenreId = movieVM.GenreId;
                movieInDb.DateRelease = movieVM.DateRelease;
            }

            
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult<MovieVM> New()
        {
            var genre = _context.Genres.ToList();

            var movieVM = new MovieVM
            {
                Genres = genre
            };

            return View("MovieForm", movieVM);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(x => x.Genre).FirstOrDefault(x => x.Id == id);

            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);

            var viewModel = new MovieVM
            {
                Id = movie.Id,
                Name = movie.Name,
                GenreId = movie.GenreId,
                DateRelease = movie.DateRelease,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm",viewModel);
        }

        public ActionResult Delete(int id)
        {
            var movie = _context.Movies.Find(id);

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
