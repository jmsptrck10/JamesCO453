﻿using ConsoleAppProject.App01;
using ConsoleAppProject.App02;
using ConsoleAppProject.App03;
using ConsoleAppProject.App04;
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
        private static readonly StudentGrades grades = new StudentGrades();
        private static readonly NetworkApp app04 = new NetworkApp();

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

            bool exit = false;

            while (!exit)
            {
                string[] choices = { "Distance Converter", "BMI Calculator", "Student Grade Calculator", "Social Network App", "Exit" };
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
                        ConsoleHelper.OutputHeading("Social Network App");
                        app04.DisplayMenu();
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
    }
}
