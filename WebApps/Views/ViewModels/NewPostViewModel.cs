using System.ComponentModel.DataAnnotations;
using WebApps.Models;

namespace WebApps.ViewModels
{
    public class NewPostViewModel
    {
        [Required]
        public string Username { get; set; }

        public string Message { get; set; }
        public string PhotoUrl { get; set; }
        public string Caption { get; set; }

        [Required]
        public string ContentType { get; set; }
    }
}
