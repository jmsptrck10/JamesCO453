using System;
using System.Collections.Generic;

namespace ConsoleAppProject.App04
{
    ///<summary>
    /// This class stores information about a post that includes a photo.
    /// </summary>
    ///<author>
    /// Michael Kölling and David J. Barnes
    /// version 0.2
    ///</author>
    public class PhotoPost : Post
    {
        // The filename of the photo stored on disk
        public String Filename { get; }

        // A one line image caption
        public String Caption { get; }

        public PhotoPost(String author, String filename, String caption)
            : base(author)
        {
            Filename = filename;
            Caption = caption;
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
            Console.WriteLine($"    Filename: {Filename}");
            Console.WriteLine($"    Caption: {Caption}");
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
