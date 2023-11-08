using Microsoft.AspNetCore.Mvc;

namespace GroupAssignment2.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
