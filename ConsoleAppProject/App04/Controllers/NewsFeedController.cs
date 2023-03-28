using System.Linq;
using Microsoft.AspNetCore.Mvc;
using YourWebAppName.Models;

namespace YourWebAppName.Controllers
{
    public class NewsFeedController : Controller
    {
        private readonly NewsFeed _newsFeed;

        public NewsFeedController()
        {
            _newsFeed = new NewsFeed();
        }

        public IActionResult Index()
        {
            return View(_newsFeed);
        }

        // Add other action methods for handling specific functionalities.
    }
}
