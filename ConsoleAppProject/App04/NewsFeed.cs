using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppProject.App04
{
    public class NewsFeed
    {
        private readonly List<Post> posts;

        public NewsFeed()
        {
            posts = new List<Post>();
        }

        public void AddMessagePost(MessagePost message)
        {
            posts.Add(message);
        }

        public void AddPhotoPost(PhotoPost photo)
        {
            posts.Add(photo);
        }

        public void Display()
        {
            foreach (Post post in posts)
            {
                post.Display();
                Console.WriteLine();   // empty line between posts
            }
        }

        public void DisplayPostsByAuthor(String author)
        {
            var filteredPosts = posts.Where(post => post.Username == author);

            foreach (Post post in filteredPosts)
            {
                post.Display();
                Console.WriteLine();   // empty line between posts
            }
        }

public void RemovePostByAuthor(string author)
{
    var post = posts.FirstOrDefault(p => p.Username == author);
    if (post != null)
    {
        posts.Remove(post);
        Console.WriteLine("Post removed.");
    }
    else
    {
        Console.WriteLine("Invalid author.");
    }
}

// Modify AddCommentToPost method to use author instead of post index
public void AddCommentToPost(string author, string comment)
{
    var post = posts.FirstOrDefault(p => p.Username == author);
    if (post != null)
    {
        post.AddComment(comment);
    }
    else
    {
        Console.WriteLine("Invalid author.");
    }
}

    public void AddCommentToPost(int index, string comment)
    {
        if (index >= 0 && index < posts.Count)
        {
            posts[index].AddComment(comment);
        }
        else
        {
            Console.WriteLine("Invalid post index.");
        }
    }


public void LikePost(string author)
{
    var post = posts.FirstOrDefault(p => p.Username == author);
    if (post != null)
    {
        post.Like();
    }
    else
    {
        Console.WriteLine("Invalid author.");
    }
}


public void UnlikePost(string author)
{
    var post = posts.FirstOrDefault(p => p.Username == author);
    if (post != null)
    {
        post.Unlike();
    }
    else
    {
        Console.WriteLine("Invalid author.");
    }
}


}


}