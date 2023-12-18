using BaiTapLonC_Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BaiTapLonC_Web.Controllers
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

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
        [HttpGet]
        [Route("about")]
        public IActionResult About()
        {
           
            return View();
        }
        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {

            return View();
        }
        [HttpGet]
        [Route("contact")]
        public IActionResult Contact()
        {

            return View();
        }
        [HttpGet]
        [Route("singleproduct")]
        public IActionResult SingleProduct()
        {

            return View();
        }
        [HttpGet]
        [Route("products")]
        public IActionResult Products()
        {

            return View();
        }


    }
}