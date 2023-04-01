using System;

namespace WebApp.Models
{
    public class PhotoPost : Post
    {
        public String Filename { get; }
        public String Caption { get; }

        public PhotoPost(String author, String filename, String caption)
            : base(author)
        {
            Filename = filename;
            Caption = caption;
        }

public override void Display()
{
    Console.WriteLine();
    Console.WriteLine($"    Author: {Username}");
    Console.WriteLine($"    Filename: [{Filename}]");
    Console.WriteLine($"    Caption: {Caption}");
    Console.WriteLine($"    Time Elapsed: {FormatElapsedTime(Timestamp)}");
    Console.WriteLine();
    Console.WriteLine($"    Likes: {Likes} people like this.");

    if (Comments.Count == 0)
    {
        Console.WriteLine("    No comments.");
    }
    else
    {
        Console.WriteLine($"    {Comments.Count}  comment(s). Click here to view.");
        foreach (string comment in Comments)
        {
            Console.WriteLine($"    - {comment}");
        }
    }
}


}

}