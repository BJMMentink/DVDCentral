using BJM.DVDCentral.BL.Models;
using BJM.DVDCentral.UI.Extentions;
using BJM.DVDCentral.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace BJM.DVDCentral.UI.Controllers
{
    public class MovieController : Controller
    {
        private readonly IWebHostEnvironment _host;

        public MovieController(IWebHostEnvironment host)
        {
            _host = host;
        }
        public IActionResult Index()
        {
            return View("IndexCard", MovieManager.Load());
        }
        public IActionResult Browse(int id)
        {
            return View(nameof(Index), MovieManager.Load(id));
        }
        public IActionResult Details(int id)
        {
            return View(MovieManager.LoadById(id));
        }
        public IActionResult Create()
        {
            MovieViewModel movieViewModel = new MovieViewModel();
            return View(movieViewModel);
        }
        [HttpPost]
        public IActionResult Create(MovieViewModel movieViewModel, bool rollback = false)
        {
            try
            {
                if (movieViewModel.File != null)
                {
                    movieViewModel.Movie.ImagePath = movieViewModel.File.FileName;
                    string path = _host.WebRootPath + "\\images\\";
                    using (var stream = System.IO.File.Create(path + movieViewModel.File.FileName))
                    {
                        movieViewModel.File.CopyTo(stream);
                        ViewBag.Message = "File Upliaded Successfully...";
                    }
                }
                IEnumerable<int> newGenreIds = new List<int>();
                if (movieViewModel.GenreId != null)
                {
                    newGenreIds = movieViewModel.GenreId;
                }
                IEnumerable<int> adds = newGenreIds;
                adds.ToList().ForEach(a => MovieGenreManager.Insert(movieViewModel.Movie.Id, a));
                int result = MovieManager.Insert(movieViewModel.Movie);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(movieViewModel);
            }
        }
        
        public IActionResult Delete(int id)
        {
            return View(MovieManager.LoadById(id));
        }
        [HttpPost]
        public IActionResult Delete(int id, Movie movie, bool rollback = false)
        {
            try
            {
                int result = MovieManager.Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(movie);
            }
        }
        public IActionResult Edit(int id)
        {
            MovieViewModel movieViewModel = new MovieViewModel(id);
            //ViewBag.Title = "Edit " + movieViewModel.Movie.Title;
            HttpContext.Session.SetObject("genreids", movieViewModel.GenreId);
            return View(movieViewModel);
        }
        [HttpPost]
        public IActionResult Edit(int id, MovieViewModel movieViewModel, bool rollback = false)
        {

            try
            {
                if (movieViewModel.File != null)
                {
                    movieViewModel.Movie.ImagePath = movieViewModel.File.FileName;
                    string path = _host.WebRootPath + "\\images\\";
                    using (var stream = System.IO.File.Create(path + movieViewModel.File.FileName))
                    {
                        movieViewModel.File.CopyTo(stream);
                        ViewBag.Message = "File Upliaded Successfully...";
                    }
                }
                IEnumerable<int> newGenreIds = new List<int>();
                if (movieViewModel.GenreId != null)
                {
                    newGenreIds = movieViewModel.GenreId;
                }
                IEnumerable<int> oldGenreIds = new List<int>();
                oldGenreIds = GetObject();
                IEnumerable<int> deletes = oldGenreIds.Except(newGenreIds);
                IEnumerable<int> adds = newGenreIds.Except(oldGenreIds);
                deletes.ToList().ForEach(d => MovieGenreManager.Delete(id, d));
                adds.ToList().ForEach(a => MovieGenreManager.Insert(id, a));
                int result = MovieManager.Update(movieViewModel.Movie, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ViewBag.Title = "Edit " + movieViewModel.Movie.Title;
                ViewBag.Error = ex.Message;
                return View(movieViewModel);
            }
        }

        private IEnumerable<int> GetObject()
        {
            if (HttpContext.Session.GetObject<IEnumerable<int>>("genreids") != null)
                return HttpContext.Session.GetObject<IEnumerable<int>>("genreids");
            else
                return null;
        }
    }
}
