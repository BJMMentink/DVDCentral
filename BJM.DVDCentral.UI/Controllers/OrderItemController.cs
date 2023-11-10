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
    }
}
