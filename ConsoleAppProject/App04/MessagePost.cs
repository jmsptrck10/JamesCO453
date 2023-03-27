using System;
using System.Collections.Generic;

namespace ConsoleAppProject.App04
{
    ///<summary>
    /// This class stores information about a post in a social network. 
    /// The main part of the post consists of a (possibly multi-line)
    /// text message. Other data, such as author and time, are also stored.
    /// </summary>
    /// <author>
    /// Michael Kölling and David J. Barnes
    /// version 0.2
    /// </author>
    public class MessagePost : Post
    {
        // an arbitrarily long, multi-line message
        public String Message { get; }

        public MessagePost(String author, String text)
            : base(author)
        {
            Message = text;
        }

        ///<summary>
        /// Display the details of this post.
        /// 
        /// (Currently: Print to the text terminal. This is simulating display 
        /// in a web browser for now.)
        ///</summary>
        public override void Display()
        {
            Console.WriteLine();
            Console.WriteLine($"    Author: {Username}");
            Console.WriteLine($"    Message: {Message}");
            Console.WriteLine($"    Time Elapsed: {FormatElapsedTime(Timestamp)}");
            Console.WriteLine();

            if (Likes > 0)
            {
                Console.WriteLine($"    Likes:  {Likes}  people like this.");
            }
            else
            {
                Console.WriteLine();
            }

            if (Comments.Count == 0)
            {
                Console.WriteLine("    No comments.");
            }
            else
            {
                Console.WriteLine($"    {Comments.Count}  comment(s). Click here to view.");
            }
        }
    }
}
