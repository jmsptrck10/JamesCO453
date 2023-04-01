using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApps.Data;
using WebApps.Views.ViewModels;

namespace WebApps.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var viewModel = new NewsFeedViewModel
            {
                MessagePosts = _context.MessagePosts.ToList(),
                PhotoPosts = _context.PhotoPosts.ToList()
            };

            return View(viewModel);
        }
    }
}
