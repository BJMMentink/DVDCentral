using BJM.DVDCentral.BL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace BJM.DVDCentral.UI.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View(MovieManager.Load());
        }
        public IActionResult Browse(int id)
        {
            return View(nameof(Index), MovieManager.Load(id));
        }
    }
}
