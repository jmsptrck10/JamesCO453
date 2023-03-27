using System;
using System.Collections.Generic;

namespace ConsoleAppProject.App04
{
    ///<summary>
    /// The NewsFeed class stores news posts for the news feed in a social network 
    /// application.
    /// 
    /// Display of the posts is currently simulated by printing the details to the
    /// terminal. (Later, this should display in a browser.)
    /// 
    /// This version does not save the data to disk, and it does not provide any
    /// search or ordering functions.
    ///</summary>
    ///<author>
    ///  Michael Kölling and David J. Barnes
    ///  version 0.2
    ///</author> 
    public class NewsFeed
    {
        private readonly List<Post> posts;

        ///<summary>
        /// Construct an empty news feed.
        ///</summary>
        public NewsFeed()
        {
            posts = new List<Post>();
        }

        ///<summary>
        /// Add a post to the news feed.
        ///</summary>
        ///<param name="post">The post to add</param>
        public void AddPost(Post post)
        {
            posts.Add(post);
        }

        ///<summary>
        /// Remove a post from the news feed.
        ///</summary>
        ///<param name="post">The post to remove</param>
        public void RemovePost(Post post)
        {
            posts.Remove(post);
        }

        ///<summary>
        /// Display all the posts in the news feed.
        ///</summary>
        public void Display()
        {
            foreach (Post post in posts)
            {
                post.Display();
            }
        }

        ///<summary>
        /// Display all the posts of a particular author.
        ///</summary>
        ///<param name="username">The username of the author</param>
        public void DisplayByAuthor(string username)
        {
            foreach (Post post in posts)
            {
                if (post.Username.Equals(username))
                {
                    post.Display();
                }
            }
        }
    }
}
