using System;

namespace WebApp.Models
{
    public class MessagePost : Post
    {
        public String Message { get; }

        public MessagePost(String author, String text)
            : base(author)
        {
            Message = text;
        }

public override void Display()
{
    Console.WriteLine();
    Console.WriteLine($"    Author: {Username}");
    Console.WriteLine($"    Message: {Message}");
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
    }
}

}

}