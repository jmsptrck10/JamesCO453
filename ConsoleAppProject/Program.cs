using ConsoleAppProject.App01;
using ConsoleAppProject.App02;
using ConsoleAppProject.App03;
using ConsoleAppProject.App04; // Add this namespace
using ConsoleAppProject.Helpers;
using System;

namespace ConsoleAppProject
{
    public static class Program
    {
        private static readonly DistanceConverter converter = new DistanceConverter();
        private static readonly BMI calculator = new BMI();
        private static readonly StudentGrades grades = new StudentGrades();
        private static readonly NewsFeed newsFeed = new NewsFeed(); // Create an instance of the NewsFeed class

        public static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine(" =================================================");
            Console.WriteLine("    BNU CO453 Applications Programming 2022-2023! ");
            Console.WriteLine(" =================================================");
            Console.WriteLine();
            bool exit = false;

            while (!exit)
            {
                string[] choices = { "Distance Converter", "BMI Calculator", "Student Grade Calculator", "Social Network", "Exit" };
                int choiceNo = ConsoleHelper.SelectChoice(choices);

                switch (choiceNo)
                {
                    case 1:
                        ConsoleHelper.OutputHeading("Distance Converter");
                        converter.Run();
                        break;
                    case 2:
                        ConsoleHelper.OutputHeading("BMI Calculator");
                        calculator.Run();
                        break;

                    case 3:
                        ConsoleHelper.OutputHeading("Student Grade Calculator");
                        grades.Run();
                        break;

                    case 4:
                        ConsoleHelper.OutputHeading("Social Network");
                        RunSocialNetworkApplication();
                        break;

                    case 5:
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
            if (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("Press any key to return to the menu...");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine(" =================================================");
                Console.WriteLine("    BNU CO453 Applications Programming 2022-2023! ");
                Console.WriteLine(" =================================================");
                Console.WriteLine();
            }
        }
    }

    /// <summary>
    /// Run the Social Network application.
    /// </summary>
   private static void RunSocialNetworkApplication()
{

    // Display the news feed
    newsFeed.Display();

    // Interact with users and allow them to use the features
    bool exit = false;

    while (!exit)
    {
        Console.WriteLine("\nOptions:");
        Console.WriteLine("1. Display all posts");
        Console.WriteLine("2. Display posts by author");
        Console.WriteLine("3. Remove a post");
        Console.WriteLine("4. Add comment to a post");
        Console.WriteLine("5. Like a post");
        Console.WriteLine("6. Unlike a post");
        Console.WriteLine("7. Add a message post");
        Console.WriteLine("8. Add a photo post");
        Console.WriteLine("9. Exit");
        Console.Write("\nEnter your choice: ");
        int choice = int.Parse(Console.ReadLine());



 string comment;


 string author, content, fileName, caption;

 switch (choice)
 {
     case 1:
         newsFeed.Display();
         break;
     case 2:
         Console.Write("Enter the author: ");
         author = Console.ReadLine();
         newsFeed.DisplayPostsByAuthor(author);
         break;
         case 3:
            Console.Write("Enter the author of the post to remove: ");
            author = Console.ReadLine();
            newsFeed.RemovePostByAuthor(author);
            break;
        case 4:
            Console.Write("Enter the author of the post: ");
            author = Console.ReadLine();
            Console.Write("Enter your comment: ");
            comment = Console.ReadLine();
            newsFeed.AddCommentToPost(author, comment);
            break;
     case 5:
         Console.Write("Enter the author of the post ");
         author = Console.ReadLine();
         newsFeed.LikePost(author);
         break;
     case 6:
         Console.Write("Enter the author of the post: ");
         author = Console.ReadLine();
         newsFeed.UnlikePost(author);
         break;
                case 7:
                Console.Write("Enter your name: ");
                author = Console.ReadLine();
                Console.Write("Enter your message: ");
                content = Console.ReadLine();
                newsFeed.AddMessagePost(new MessagePost(author, content));
                break;
            case 8:
                Console.Write("Enter your name: ");
                author = Console.ReadLine();
                Console.Write("Enter the filename: ");
                fileName = Console.ReadLine();
                Console.Write("Enter the caption: ");
                caption = Console.ReadLine();
                newsFeed.AddPhotoPost(new PhotoPost(author, fileName, caption));
                break;
            case 9:
                exit = true;
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }
}

    }

}