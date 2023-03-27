using System;

namespace ConsoleAppProject.App04
{
    /// <summary>
    /// The NetworkApp class provides the functionality for a social
    /// networking application that allows users to post messages and
    /// images and comment on them.
    /// </summary>
    public class NetworkApp
    {
        private readonly NewsFeed newsFeed;

        public NetworkApp()
        {
            newsFeed = new NewsFeed();
        }

        /// <summary>
        /// Displays the menu of options for the social networking
        /// application.
        /// </summary>
        public void DisplayMenu()
        {
            bool exit = false;

            while (!exit)
            {
                string[] choices = { "Post Message", "Post Image", "Display All Posts", "Add Comment", "Like Post", "Quit" };
                int choiceNo = ConsoleHelper.SelectChoice(choices);

                switch (choiceNo)
                {
                    case 1:
                        PostMessage();
                        break;

                    case 2:
                        PostImage();
                        break;

                    case 3:
                        DisplayAllPosts();
                        break;

                    case 4:
                        AddComment();
                        break;

                    case 5:
                        LikePost();
                        break;

                    case 6:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private void PostMessage()
        {
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();

            Console.Write("Enter your message: ");
            string message = Console.ReadLine();

            MessagePost post = new MessagePost(username, message);
            newsFeed.AddPost(post);

            Console.WriteLine("Message posted successfully.");
        }

        private void PostImage()
        {
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();

            Console.Write("Enter the filename of your image: ");
            string filename = Console.ReadLine();

            Console.Write("Enter a caption for your image: ");
            string caption = Console.ReadLine();

            ImagePost post = new ImagePost(username, filename, caption);
            newsFeed.AddPost(post);

            Console.WriteLine("Image posted successfully.");
        }

        private void DisplayAllPosts()
        {
            newsFeed.Display();
        }

        private void AddComment()
        {
            Console.Write("Enter the post ID you want to comment on: ");
            int postId = int.Parse(Console.ReadLine());

            Post post = newsFeed.GetPostById(postId);

            if (post != null)
            {
                Console.Write("Enter your username: ");
                string username = Console.ReadLine();

                Console.Write("Enter your comment: ");
                string comment = Console.ReadLine();

                post.AddComment(new Comment(username, comment));

                Console.WriteLine("Comment added successfully.");
            }
            else
            {
                Console.WriteLine("Post not found.");
            }
        }

        public void LikePost()
        {
            ConsoleHelper.OutputTitle("Like a post");

            Console.Write("Enter post ID: ");
            int id = int.Parse(Console.ReadLine());

            Post post = newsFeed.GetPostById(id);

            if (post != null)
            {
                post.Like();
                Console.WriteLine("Post liked.");
            }
            else
            {
                Console.WriteLine($"Post with ID {id} not found.");
            }
        }

        /// <summary>
        /// This method allows the user to add a comment to a post by entering the post ID and the comment text.
        /// </summary>
        public void AddComment()
        {
            ConsoleHelper.OutputTitle("Add a comment");

            Console.Write("Enter post ID: ");
            int id = int.Parse(Console.ReadLine());

            Post post = newsFeed.GetPostById(id);

            if (post != null)
            {
                Console.Write("Enter your name: ");
                string author = Console.ReadLine();

                Console.Write("Enter your comment: ");
                string text = Console.ReadLine();

                post.AddComment(new Comment(author, text));

                Console.WriteLine("Comment added.");
            }
            else
            {
                Console.WriteLine($"Post with ID {id} not found.");
            }
        }

        /// <summary>
        /// This method displays the menu of options for the user.
        /// </summary>
        public void DisplayMenu()
        {
            bool exit = false;

            while (!exit)
            {
                string[] options =
                {
                    "Create a new post",
                    "Display all posts",
                    "Display posts by author",
                    "Like a post",
                    "Add a comment",
                    "Quit"
                };

                ConsoleHelper.OutputTitle("Main Menu");

                int choice = ConsoleHelper.SelectChoice(options);

                switch (choice)
                {
                    case 1:
                        CreatePost();
                        break;
                    case 2:
                        DisplayAll();
                        break;
                    case 3:
                        DisplayByAuthor();
                        break;
                    case 4:
                        LikePost();
                        break;
                    case 5:
                        AddComment();
                        break;
                    case 6:
                        exit = true;
                        break;
                }
            }
        }
    }
}