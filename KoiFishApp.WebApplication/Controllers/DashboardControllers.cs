using Microsoft.AspNetCore.Mvc;

namespace PremierLeague.WebApplication.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}