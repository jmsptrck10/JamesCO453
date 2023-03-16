using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App03
{
    public class StudentGrades
    {
        // Constant values for minimum and maximum marks
        private const int MinMark = 0;
        private const int MaxMark = 100;
        // List of tuples to store student name, mark, and grade
        private readonly List<(string, int, Grades)> students = new();

       
        // Main method to run the StudentGrades program
        public void Run()
    {
        // Output the application heading
        OutputHeading();

        // Loop through the application options until the user chooses to exit
        while (true)
        {
            Console.WriteLine("\nPlease select an option:");
            Console.WriteLine("1. Input Marks");
            Console.WriteLine("2. Output Marks");
            Console.WriteLine("3. Output Stats");
            Console.WriteLine("4. Output Grade Profile");
            Console.WriteLine("5. Exit");

        // Read the user's input and validate it
            int option = ReadOption();

        // Switch statement to handle the user's input
                switch (option)
        {
            case 1:
                InputMarks();
                break;
            case 2:
                OutputMarks();
                break;
            case 3:
                OutputStats();
                break;
            case 4:
                OutputGradeProfile();
                break;
            case 5:
                Console.WriteLine("\nThank you for using the Student Grades App.");
                return;
            default:
                Console.WriteLine($"\nError: Invalid option '{option}', please try again.");
                break;
        }
    }
}

        // Method to read and validate the user's option
        private int ReadOption()
    {
        while (true)
        {
        // Read the user's input and trim any whitespace
        string input = Console.ReadLine().Trim();

        // Try to parse the input as an integer
        if (!int.TryParse(input, out int option))
        {
            Console.WriteLine($"Error: '{input}' is not a number, please try again.");
            continue;
        }

        // Check if the option is within the valid range of options
        if (option < 1 || option > 5)
        {
            Console.WriteLine($"Error: '{option}' is not a valid option, please try again.");
            continue;
        }

        return option;
    }
}


    
        // Method to input student marks
private void InputMarks()
{
    Console.WriteLine("\nEnter marks for at least 10 students. Type 'end' to finish.");

    // Loop through the input process until at least 10 marks have been entered or the user types 'end'
    while (students.Count < 10)
    {
        // Prompt the user to enter a mark for the current student
        Console.Write($"Enter mark for Student {students.Count + 1}: ");
        
        // Read the user's input and trim any whitespace
        string input = Console.ReadLine().Trim();

        // If the user types 'end', exit the loop
        if (input == "end")
        {
            break;
        }

        // Try to parse the input as an integer, and check if it's within the valid range of marks
        if (!int.TryParse(input, out int mark) || mark < MinMark || mark > MaxMark)
        {
            // Invalid input, continue the loop
            Console.WriteLine($"Error: invalid mark '{input}', please try again.");
            continue;
        }

        // Add the student's information to the list
        Grades grade = GetGrade(mark);
        string name = $"Student{students.Count + 1}";
        students.Add((name, mark, grade));
    }
}

        // Method to output all student marks
    private void OutputMarks()
    {
        // If there are no marks, output an error message and return
        if (students.Count == 0)
        {
            Console.WriteLine("\nError: No marks have been entered yet.");
            return;
        }

        Console.WriteLine("\nStudent Marks\n");
        
        // Loop through all the students and output their name, mark, and grade
        foreach (var student in students)
        {
        
        // Get the grade description and symbol for the student's grade
        string gradeDescription = GetGradeDescription(student.Item3);
        string gradeSymbol = GetGradeSymbol(student.Item3);

        // Output the student's name, mark, and grade
        Console.WriteLine($"Student {student.Item1} Mark = {student.Item2} Grade = {gradeSymbol} ({gradeDescription})");
        
        }
    }

        // This method calculates and outputs statistics on the entered student marks
    private void OutputStats()
    {
        // Check if any marks have been entered yet
        if (students.Count == 0)
        {
            Console.WriteLine("\nError: No marks have been entered yet.");
            return;
        }

        // Calculate the minimum, maximum, and average marks
        int minMark = students.Min(s => s.Item2);
        int maxMark = students.Max(s => s.Item2);
        double averageMark = students.Average(s => s.Item2);
        
        // Get the grades corresponding to the minimum and maximum marks
        Grades lowestGrade = GetGrade(minMark);
        Grades highestGrade = GetGrade(maxMark);

        // Output the statistics in a table format
        Console.WriteLine($"\nStatistics\n" +
            $"{"Min Mark:",-15} {minMark} ({GetGradeDescription(lowestGrade)})\n" +
            $"{"Max Mark:",-15} {maxMark} ({GetGradeDescription(highestGrade)})\n" +
            $"{"Average Mark:",-15} {averageMark:F2}\n");
    }
        // This method outputs a table showing the distribution of grades among entered marks
    private void OutputGradeProfile()
    {
        // Check if any marks have been entered yet
        if (students.Count == 0)
        {        
            Console.WriteLine("\nError: No marks have been entered yet.");
            return;
        }

        // Group the student marks by grade and sort them in descending order
            var gradeGroups = students.GroupBy(s => s.Item3)
            .OrderByDescending(g => g.Key);

        // Output a header for the grade profile table
            Console.WriteLine("\nGrade Profile\n");

        // Loop through each grade group and output the count and percentage of students in that grade
            foreach (var gradeGroup in gradeGroups)
          
        {

        int count = gradeGroup.Count();
        double percentage = (double)count / students.Count * 100;
        string gradeSymbol = GetGradeSymbol(gradeGroup.Key);
        Console.WriteLine($"{gradeSymbol,-10} count = {count,-3} percentage = {percentage:F2}%");
        }
    } 
        // This method maps a mark to a grade according to the grading scheme in the GetGrade method
    private Grades GetGrade(int mark)
    {
        return mark switch

        {
            >= 70 and <= 100 => Grades.A,
            >= 60 and < 70 => Grades.B,
            >= 50 and < 60 => Grades.C,
            >= 40 and < 50 => Grades.D,
            _=> Grades.F

         };
}
        // Returns a string description of a given grade.
    private string GetGradeDescription(Grades grade)
    {
        return grade switch
        {
        
        Grades.A => "First Class",
        Grades.B => "Upper Second Class",
        Grades.C => "Lower Second Class",
        Grades.D => "Third Class",
        _ => "Fail"
        };
    }
        // Returns a string symbol of a given grade.
    private string GetGradeSymbol(Grades grade)
    {
        return grade switch
        {
        Grades.A => "A",
        Grades.B => "B",
        Grades.C => "C",
        Grades.D => "D",
        _ => "F"
        };
    }
        // Outputs a heading message to the console.
    private void OutputHeading()
    { 
        
        Console.WriteLine("This is a console application for inputting and analyzing ");
        Console.WriteLine("student grades, including statistics and a grade profile.");
        Console.WriteLine();
    
    }

    }

}
