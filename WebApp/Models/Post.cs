using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public abstract class Post
    {
        public int Likes { get; protected set; }
        public List<String> Comments { get; }
        public String Username { get; }
        public DateTime Timestamp { get; }

        protected Post(String author)
        {
            Username = author;
            Timestamp = DateTime.Now;
            Likes = 0;
            Comments = new List<String>();
        }

        public void Like()
        {
            Likes++;
        }

        public void Unlike()
        {
            if (Likes > 0)
            {
                Likes--;
            }
        }

        public void AddComment(String text)
        {
            Comments.Add(text);
        }

        protected String FormatElapsedTime(DateTime time)
        {
            DateTime current = DateTime.Now;
            TimeSpan timePast = current - time;

            long seconds = (long)timePast.TotalSeconds;
            long minutes = seconds / 60;

            if (minutes > 0)
            {
                return minutes + " minutes ago";
            }
            else
            {
                return seconds + " seconds ago";
            }
        }

        public string GetElapsedTime()
        {
            return FormatElapsedTime(Timestamp);
        }

        public abstract void Display();

        public void DisplayCommentsWithNames()
        {
            if (Comments.Count == 0)
            {
                Console.WriteLine("    No comments.");
            }
            else
            {
                Console.WriteLine($"    {Comments.Count}  comment(s):");
                foreach (string comment in Comments)
                {
                    Console.WriteLine($"    - {comment}");
                }
            }
        }
    }
}

