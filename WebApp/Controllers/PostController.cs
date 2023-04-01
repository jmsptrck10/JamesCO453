using WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using SocialNetworkWebApp.Data;
using System.Linq;

namespace SocialNetworkWebApp.Controllers
{
    public class PostsController : Controller
    {
        private readonly PostContext _context;

        public PostsController(PostContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Posts.ToList());
        }

        // Add other action methods for the Social Network features here
    }
}
