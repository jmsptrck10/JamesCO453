using System.Collections.Generic;

namespace WebApps.Models
{
    public class NewsFeed
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<MessagePost> MessagePosts { get; set; }
        public ICollection<PhotoPost> PhotoPosts { get; set; }
    }
}
