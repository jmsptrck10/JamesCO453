using System;

namespace WebApps.Models
{
    public abstract class Post
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class MessagePost : Post
    {
        public string Content { get; set; }
    }

    public class PhotoPost : Post
    {
        public string ImageUrl { get; set; }
        public string Caption { get; set; }
    }
}
