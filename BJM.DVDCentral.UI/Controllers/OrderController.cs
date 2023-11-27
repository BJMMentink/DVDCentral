using BJM.DVDCentral.UI.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BJM.DVDCentral.UI.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View(OrderManager.Load());
        }
        public IActionResult Details(int id)
        {
            var item = OrderManager.LoadById(id);
            return View(item);
        }
        public IActionResult Create()
        {
            if (Authenticate.IsAuthenticated(HttpContext))
                return View();
            else
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request)});
        }
        [HttpPost]
        public IActionResult Create(Order director, bool rollback = false)
        {
            try
            {
                int result = OrderManager.Insert(director, rollback);
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
                return View(OrderManager.LoadById(id));
            else
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });

        }
        [HttpPost]
        public IActionResult Edit(int id, Order director, bool rollback = false)
        {
            try
            {
                int result = OrderManager.Update(director, rollback);
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
            return View(OrderManager.LoadById(id));
        }
        [HttpPost]
        public IActionResult Delete(int id, Order director, bool rollback = false)
        {
            try
            {
                int result = OrderManager.Delete(id, rollback);
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
