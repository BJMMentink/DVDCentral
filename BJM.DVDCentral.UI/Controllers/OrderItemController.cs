using BJM.DVDCentral.BL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace BJM.DVDCentral.UI.Controllers
{
    public class OrderItemController : Controller
    {
        public IActionResult Index()
        {
            return View(OrderItemManager.Load());
        }
        [HttpPost]
        public IActionResult Remove(int id)
        {
            try
            {
                OrderItem orderItem = OrderItemManager.LoadById(id);

                if (orderItem != null)
                {
                    OrderItemManager.Delete(id);
                    return RedirectToAction("Edit", "Order", new { id = orderItem.OrderId });
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
