using System.Collections.Generic;
using WebApps.Models;

namespace WebApps.Views.ViewModels
{
    public class NewsFeedViewModel
    {
        public List<MessagePost> MessagePosts { get; set; }
        public List<PhotoPost> PhotoPosts { get; set; }
    }
}
