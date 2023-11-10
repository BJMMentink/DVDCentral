using BJM.DVDCentral.UI.Extentions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BJM.DVDCentral.UI.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Seed()
        {
            UserManager.Seed();
            return View();
        }
        private void SetUser(User user)
        {
            HttpContext.Session.SetObject("user", user);
            if (user != null)
            {
                HttpContext.Session.SetObject("fullname", "Welcome " + user.FullName);
            }
            else
            {
                HttpContext.Session.SetObject("fullname", string.Empty);
            }
        }

        public IActionResult Logout()
        {
            ViewBag.Title = "Logout";
            SetUser(null);
            return View();
        }
        public IActionResult Login(string returnUrl)
        {
            TempData["returnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            try
            {
                bool result = UserManager.Login(user);
                SetUser(user);
                if (TempData["returnUrl"] != null)
                return Redirect(TempData["returnUrl"]?.ToString());
                else
                return RedirectToAction(nameof(Index), "");
            }
            catch (Exception ex)
            {
                return View(user);
            }
        }
        public IActionResult Edit(int userId)
        {
            User user = UserManager.LoadById(userId);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user, bool rollback = false)
        {
            try
            {
                int result = UserManager.Update(user, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(user);
            }
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            UserManager.Insert(user);
            return RedirectToAction(nameof(Index));
        }
    }
}
