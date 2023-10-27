using Microsoft.AspNetCore.Mvc;

namespace BJM.DVDCentral.UI.ViewComponents
{
    public class Sidebar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(GenreManager.Load().OrderBy(g => g.Id));
        }
    }
}
