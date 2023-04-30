using IPLab1BMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IPLab1BMVC.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult Fairies()
		{
			ViewBag.Fairies = FairiesGetter.FairyList;
			return View();
		}

		public IActionResult Fairy(string id)
		{
			ViewBag.Name = id;
			var fairy = FairiesGetter.FairyList.Find(x => x.Name == id);
			ViewBag.Description = fairy?.Description ?? string.Empty;
			ViewBag.Image = fairy?.ImageSrc ?? string.Empty;
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}