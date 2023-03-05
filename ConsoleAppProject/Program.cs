using ConsoleAppProject.App01;
using ConsoleAppProject.App02;
using ConsoleAppProject.Helpers;
using System;

namespace ConsoleAppProject
{
    /// <summary>
    /// The main class for this console application. It provides a menu
    /// of options for the user to choose from.
    /// </summary>
    /// <author>
    /// James Patrick Arellano
    /// </author>
    public static class Program
    {
        private static readonly DistanceConverter converter = new DistanceConverter();
        private static readonly BMI calculator = new BMI();

        /// <summary>
        /// The main method is called first when the application is started.
        /// It displays a menu of options to the user and runs the selected option.
        /// </summary>
        public static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine();
            Console.WriteLine(" =================================================");
            Console.WriteLine("    BNU CO453 Applications Programming 2022-2023! ");
            Console.WriteLine(" =================================================");
            Console.WriteLine();

            string[] choices = { "Distance Converter", "BMI Calculator" };
            int choiceNo = ConsoleHelper.SelectChoice(choices);

            if (choiceNo == 1)
            {
                ConsoleHelper.OutputHeading("Distance Converter");
                converter.Run();
            }
            else if (choiceNo == 2)
            {
                ConsoleHelper.OutputHeading("BMI Calculator");
                calculator.Run();
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
    }
}
