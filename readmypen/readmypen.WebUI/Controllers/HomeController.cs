using Microsoft.AspNetCore.Mvc;
using readmypen.WebUI.Models;
using System.Diagnostics;

namespace readmypen.WebUI.Controllers
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

    }
}