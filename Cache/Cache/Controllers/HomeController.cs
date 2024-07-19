using Cache.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;

namespace Cache.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemoryCache _cache;
        public HomeController(ILogger<HomeController> logger, IMemoryCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        public IActionResult Index()
        {
            _cache.Set<string>("timestamp", DateTime.Now.ToString());
            return View();
        }

        public IActionResult Show()
        {
            string timestamp = _cache.Get<string>("timestamp");
            return View("Show",timestamp);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        

        [ResponseCache(Duration = 30)]
        public IActionResult Outputcache()
        {
            ViewBag.output = DateTime.Now.ToString();
            return View();
        }

    }
}
