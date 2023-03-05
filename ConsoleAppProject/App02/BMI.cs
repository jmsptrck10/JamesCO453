using System;

namespace ConsoleAppProject.App02
{
    /// <summary>
    /// This class calculates the Body Mass Index (BMI)
    /// and determines the weight status of a person based on their BMI.
    /// </summary>
    /// <author>
    /// James Patrick Arellano version 0.2
    /// </author>
    public class BMI
    {
        private const double UNDERWEIGHT_BMI = 18.5;
        private const double NORMAL_BMI = 24.9;
        private const double OVERWEIGHT_BMI = 29.9;
        private const double OBESE_CLASS_1_BMI = 34.9;
        private const double OBESE_CLASS_2_BMI = 39.9;
        private const double OBESE_CLASS_3_BMI = 40.0;

        private double weight;
        private double height;
        private string unitChoice;

        /// <summary>
        /// Run method to start the BMI calculator.
        /// </summary>
        public void Run()
        {
            OutputHeading();
            unitChoice = ChooseUnits(); 
            
            InputWeight(unitChoice);
            InputHeight(unitChoice);
            
            double bmi = CalculateBMI(unitChoice);
            string weightStatus = CalculateWeightStatus(bmi);
            
             OutputBMI(bmi);
             OutputWeightStatus(weightStatus);
             
             if ((weightStatus == "Overweight" || weightStatus.StartsWith("Obese")) && (unitChoice == "metric" && bmi >= 23 || unitChoice == "imperial" && bmi >= 27.5))
            
             {
                 Console.WriteLine();
                 Console.WriteLine("If you are black, Asian, or from another minority ethnic group, " +  "you have a higher risk of developing some long-term (chronic) " +"conditions, such as type 2 diabetes.");}
                 
        }


        private void OutputHeading()
        {
            Console.WriteLine("This application calculates your BMI value");
            Console.WriteLine("and determines your weight status based on your BMI.");
            Console.WriteLine();
        }

        private string ChooseUnits()
        {
            Console.WriteLine("Please choose your units:");
            Console.WriteLine("1. Metric Units (kg, m)");
            Console.WriteLine("2. Imperial Units (stones, lbs, ft, in)");
            Console.Write("Enter your choice (1 or 2): ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                return "metric";
            }
            else if (choice == "2")
            {
                return "imperial";
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                return ChooseUnits();
            }
        }

        private void InputWeight(string unitChoice)
        {
            if (unitChoice == "metric")
            {
                Console.Write("Enter your weight in kg: ");
                string input = Console.ReadLine();
                weight = Convert.ToDouble(input);
            }
            else if (unitChoice == "imperial")
            {
                Console.Write("Enter your weight in stones: ");
                string stones = Console.ReadLine();
                Console.Write("Enter your weight in pounds: ");
                string pounds = Console.ReadLine();
                weight = Convert.ToDouble(stones) * 14 + Convert.ToDouble(pounds);
            }
        }

        private void InputHeight(string unitChoice)
        {
            if (unitChoice == "metric")
            {
                Console.Write("Enter your height in metres: ");
                string input = Console.ReadLine();
                height = Convert.ToDouble(input);
            }
            else if (unitChoice == "imperial")
            {
                Console.Write("Enter your height in feet: ");
                string feet = Console.ReadLine();
                Console.Write("Enter your height in inches: ");
                string inches = Console.ReadLine();
                height = Convert.ToDouble(feet) * 12 + Convert.ToDouble(inches);
            }
        }

        public double CalculateBMI(string unitChoice)
{
    double bmi = 0;

    if (unitChoice == "metric")
    {
        bmi = weight / (height * height);
    }
    else if (unitChoice == "imperial")
    {
        double weightInPounds = weight * 2.20462;
        double heightInInches = height * 39.3701;

        bmi = (weightInPounds * 703) / (heightInInches * heightInInches);
    }
    else
    {
        Console.WriteLine("Invalid unit choice. Please choose either 'imperial' or 'metric'.");
    }

    return bmi;
}

private string CalculateWeightStatus(double bmi)
{
    if (bmi < UNDERWEIGHT_BMI)
    {
        return "Underweight";
    }
    else if (bmi < NORMAL_BMI)
    {
        return "Normal weight";
    }
    else if (bmi < OVERWEIGHT_BMI)
    {
        return "Overweight";
    }
    else if (bmi < OBESE_CLASS_1_BMI)
    {
        return "Obese Class I (Moderately obese)";
    }
    else if (bmi < OBESE_CLASS_2_BMI)
    {
        return "Obese Class II (Severely obese)";
    }
    else if (bmi < OBESE_CLASS_3_BMI)
    {
        return "Obese Class III (Very severely obese)";
    }
    else
    {
        return "Invalid BMI value";
    }
}

private void OutputBMI(double bmi)
{
    Console.WriteLine($"Your BMI is {bmi:f2}");
}

private void OutputWeightStatus(string weightStatus)
{
    Console.WriteLine($"Your weight status is {weightStatus}");
}

}

}