using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApps.Models;
using WebApps.Data;

namespace WebApps.Controllers
{
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Your other controller actions go here.
    }
}
