using System;

namespace WebApps.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Author { get; set; }
        public string? Content { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
