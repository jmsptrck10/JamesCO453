using System.ComponentModel.DataAnnotations;

namespace WebApps.Models
{
    public class MessagePost : Post
    {
        [Required]
        public string Message { get; set; }

        public MessagePost(string author, string message) : base()
        {
            Author = author;
            Message = message;
        }
    }
}
