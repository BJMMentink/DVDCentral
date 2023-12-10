using BJM.DVDCentral.UI.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BJM.DVDCentral.UI.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "List of Orders";
            return View(OrderManager.Load());
        }
        public IActionResult Details(int id)
        {
            ViewBag.Title = "Details for this Order";
            var item = OrderManager.LoadById(id);
            return View(item);
        }
        public IActionResult Create()
        {
            ViewBag.Title = "Create an Order";
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
            catch (Exception ex)
            {
                ViewBag.Title = "Create an Order";
                ViewBag.Error = ex.Message;
                throw;
            }
        }
        public IActionResult Edit(int id)
        {
            ViewBag.Title = "Edit an Order";
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
                ViewBag.Title = "Edit an Order";
                ViewBag.Error = ex.Message;
                return View(director);
            }
        }
        public IActionResult Delete(int id)
        {
            ViewBag.Title = "Delete an Order";
            return View(OrderManager.LoadById(id));
        }
        [HttpPost]
        public IActionResult Delete(int id, Order director, bool rollback = false)
        {
            try
            {
                ViewBag.Title = "Delete an Order";
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
