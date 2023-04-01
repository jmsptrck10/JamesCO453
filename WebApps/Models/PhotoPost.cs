using System.ComponentModel.DataAnnotations;

namespace WebApps.Models
{
    public class PhotoPost : Post
    {
        [Required]
        public string PhotoUrl { get; set; }

        public PhotoPost(string author, string photoUrl) : base()
        {
            Author = author;
            PhotoUrl = photoUrl;
        }
    }
}