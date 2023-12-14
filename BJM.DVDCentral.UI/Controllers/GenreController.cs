using BJM.DVDCentral.UI.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace BJM.DVDCentral.UI.Controllers
{
    #region "Pre-Web-API"
    public class GenreController : Controller
    {
        public IActionResult Index()
        {
            return View(GenreManager.Load());
        }
        public IActionResult Details(int id)
        {
            return View(GenreManager.LoadById(id));
        }
        public IActionResult Create()
        {
            if (Authenticate.IsAuthenticated(HttpContext))
                return View();
            else
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
        }
        [HttpPost]
        public IActionResult Create(Genre genre, bool rollback = false)
        {
            try
            {
                int result = GenreManager.Insert(genre, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IActionResult Edit(int id)
        {
            if (Authenticate.IsAuthenticated(HttpContext))
                return View(GenreManager.LoadById(id));
            else
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });   
        }
        [HttpPost]
        public IActionResult Edit(int id, Genre genre, bool rollback = false)
        {
            try
            {
                int result = GenreManager.Update(genre, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(genre);
            }
        }
        public IActionResult Delete(int id)
        {
            return View(GenreManager.LoadById(id));
        }
        [HttpPost]
        public IActionResult Delete(int id, Genre genre, bool rollback = false)
        {
            try
            {
                int result = GenreManager.Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(genre);
            }
        }
        #endregion
        #region "Web-API"


        private static HttpClient InitializeClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7264/api/");
            return client;
        }

        public IActionResult Get()
        {
            ViewBag.Title = "List of all genres";
            HttpClient client = InitializeClient();

            HttpResponseMessage response = client.GetAsync("Genres").Result;

            string result = response.Content.ReadAsStringAsync().Result;

            dynamic items = (JArray)JsonConvert.DeserializeObject(result);
            List<Genre> genres = items.ToObject<List<Genre>>();
            return View(nameof(Index), genres);
        }

        public IActionResult GetOne(int id)
        {
            ViewBag.Title = "Genre Details";
            HttpClient client = InitializeClient();

            HttpResponseMessage response = client.GetAsync($"Genres/{id}").Result;

            string result = response.Content.ReadAsStringAsync().Result;
            dynamic item = JsonConvert.DeserializeObject(result);
            Genre genre = item.ToObject<Genre>();

            return View(nameof(Details), genre);
        }

        public IActionResult Insert()
        {
            ViewBag.Title = "Create a Genre";
            return View(nameof(Create));
        }

        [HttpPost]
        public IActionResult Insert(Genre genre)
        {
            try
            {
                HttpClient client = InitializeClient();
                string serializedObject = JsonConvert.SerializeObject(genre);
                var content = new StringContent(serializedObject);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = client.PostAsync("Genres", content).Result;
                return RedirectToAction(nameof(Get));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(nameof(Create), genre);
            }
        }

        public IActionResult Update(int id)
        {
            ViewBag.Title = "Update Genre";
            HttpClient client = InitializeClient();

            HttpResponseMessage response = client.GetAsync($"Genres/{id}").Result;

            string result = response.Content.ReadAsStringAsync().Result;
            dynamic item = JsonConvert.DeserializeObject(result);
            Genre genre = item.ToObject<Genre>();

            return View(nameof(Edit), genre);
        }

        [HttpPost]
        public IActionResult Update(int id, Genre genre)
        {
            try
            {
                HttpClient client = InitializeClient();
                string serializedObject = JsonConvert.SerializeObject(genre);
                var content = new StringContent(serializedObject);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = client.PutAsync($"Genres/{id}", content).Result;
                return RedirectToAction(nameof(Get));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(nameof(Edit), genre);
            }
        }

        public IActionResult Remove(int id)
        {
            HttpClient client = InitializeClient();

            HttpResponseMessage response = client.GetAsync($"Genres/{id}").Result;

            string result = response.Content.ReadAsStringAsync().Result;
            dynamic item = JsonConvert.DeserializeObject(result);
            Genre genre = item.ToObject<Genre>();

            return View(nameof(Delete), genre);
        }

        [HttpPost]
        public IActionResult Remove(int id, Genre genre)
        {
            try
            {
                HttpClient client = InitializeClient();
                HttpResponseMessage response = client.DeleteAsync($"Genres/{id}").Result;
                return RedirectToAction(nameof(Get));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(nameof(Delete), genre);
            }
        }


        #endregion
    }
}
