using Microsoft.AspNetCore.Mvc;

namespace PremierLeague.WebApplication.Controllers
{
	public class ReportsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
