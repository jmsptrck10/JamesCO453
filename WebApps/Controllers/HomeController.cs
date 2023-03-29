using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApps.Models;
using Microsoft.Extensions.Logging;
using System;

namespace WebApps.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NewsFeed _newsFeed;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _newsFeed = new NewsFeed();
        }

        public IActionResult Index()
        {
            return View(_newsFeed.GetPosts());
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
    }
}
