using BJM.DVDCentral.UI.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BJM.DVDCentral.UI.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View(CustomerManager.Load());
        }
        public IActionResult Details(int id)
        {
            return View(CustomerManager.LoadById(id));
        }
        public IActionResult Create()
        {
            ViewBag.Title = "Create A customer";
            if (Authenticate.IsAuthenticated(HttpContext))
                return View();
            else
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
        }
        [HttpPost]
        public IActionResult Create(Customer director, bool rollback = false)
        {
            try
            {
                int result = CustomerManager.Insert(director, rollback);
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
                return View(CustomerManager.LoadById(id));
            else
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            
        }
        [HttpPost]
        public IActionResult Edit(int id, Customer director, bool rollback = false)
        {
            try
            {
                int result = CustomerManager.Update(director, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(director);
            }
        }
        public IActionResult Delete(int id)
        {
            return View(CustomerManager.LoadById(id));
        }
        [HttpPost]
        public IActionResult Delete(int id, Customer director, bool rollback = false)
        {
            try
            {
                int result = CustomerManager.Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(director);
            }
        }
    }
}
