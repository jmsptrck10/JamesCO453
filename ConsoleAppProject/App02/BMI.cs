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
        /// Constants representing BMI categories.
        private const double UNDERWEIGHT_BMI = 18.5;
        private const double NORMAL_BMI = 24.9;
        private const double OVERWEIGHT_BMI = 29.9;
        private const double OBESE_CLASS_1_BMI = 34.9;
        private const double OBESE_CLASS_2_BMI = 39.9;
        private const double OBESE_CLASS_3_BMI = 40.0;

        /// Fields for storing user's weight, height, and unit choice.

        private double weight;
        private double height;
        private string unitChoice;

       
        /// Run method to start the BMI calculator.
       
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
                 Console.WriteLine("If you are black, Asian, or from another minority ethnic group, " +  "you have a higher risk of developing some long-term (chronic) " +"conditions, such as type 2 diabetes.");

                 Console.WriteLine();
                 Console.WriteLine("Adults 23.0 or more are at increased risk");
                 Console.WriteLine("Adults 27.5 or more are at high risk");
                }
                 
        }

        /// Outputs the application heading.

        private void OutputHeading()
        {
            Console.WriteLine("This application calculates your BMI value");
            Console.WriteLine("and determines your weight status based on your BMI.");
            Console.WriteLine();
        }

        /// Prompt user to choose metric or imperial units.

        private string ChooseUnits()
        {
            Console.WriteLine("Please choose your units:");
            Console.WriteLine("1. Metric Units (kg, m)");
            Console.WriteLine("2. Imperial Units (stones, lbs, ft, in)");
            Console.WriteLine();
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
                Console.WriteLine();
                Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                return ChooseUnits();
            }
        }

        /// Prompt user to input weight in kg or stones and pounds.

// This method takes in a string parameter to determine whether the weight input should be in metric or imperial units.
private void InputWeight(string unitChoice)
{
    bool validInput = false;
    // This loop continues until valid input is received from the user.
    while (!validInput)
    {
        // If the unit choice is metric, prompt the user for their weight in kilograms.
        if (unitChoice == "metric")
        {
            Console.WriteLine();
            Console.Write("Enter your weight in kg: ");
            string input = Console.ReadLine();
            // If the user enters a valid weight in kilograms, set the weight variable to that value.
            if (double.TryParse(input, out double result))
            {
                weight = result;
                validInput = true;
            }
            // If the user enters an invalid weight, prompt them to enter a valid weight in kilograms.
            else
            {
                Console.WriteLine();
                Console.WriteLine("Invalid input. Please enter a valid weight in kg.");
            }
        }
        // If the unit choice is imperial, prompt the user for their weight in stones and pounds.
        else if (unitChoice == "imperial")
        {
            Console.WriteLine();
            Console.Write("Enter your weight in stones: ");
            string stones = Console.ReadLine();
            Console.Write("Enter your weight in pounds: ");
            string pounds = Console.ReadLine();
            // If the user enters valid weights in stones and pounds, convert the weight to kilograms and set the weight variable to that value.
            if (double.TryParse(stones, out double stoneResult) && double.TryParse(pounds, out double poundResult))
            {
                double weightInPounds = stoneResult * 14 + poundResult;
                double weightInKilograms = weightInPounds / 2.20462; // convert pounds to kilograms
                weight = weightInKilograms;
                validInput = true;
            }
            // If the user enters invalid weights, prompt them to enter valid weights in stones and pounds.
            else
            {
                Console.WriteLine();
                Console.WriteLine("Invalid input. Please enter valid weights in stones and pounds.");
            }
        }
        // If the unit choice is not "metric" or "imperial", prompt the user to enter a valid unit choice.
        else
        {
            Console.WriteLine();
            Console.WriteLine("Invalid unit choice. Please choose either 'imperial' or 'metric'.");
            break;
        }
    }
}


///method takes a unitChoice string as an argument and prompts 
///the user to input their height in either metric or imperial units. 
///It then converts the input to metres and sets the height variable to the converted value
private void InputHeight(string unitChoice)
{
    bool validInput = false;
    while (!validInput)
    {
        if (unitChoice == "metric")
        {
            Console.Write("Enter your height in metres: ");
            string input = Console.ReadLine();
            if (double.TryParse(input, out double result))
            {
                height = result;
                validInput = true;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Invalid input. Please enter a valid height in metres.");
            }
        }
        else if (unitChoice == "imperial")
        {
            Console.WriteLine();
            Console.Write("Enter your height in feet: ");
            string feet = Console.ReadLine();
            Console.Write("Enter your height in inches: ");
            string inches = Console.ReadLine();
            if (double.TryParse(feet, out double feetResult) && double.TryParse(inches, out double inchResult))
            {
                double heightInInches = feetResult * 12 + inchResult;
                double heightInMetres = heightInInches * 0.0254; // convert inches to metres
                height = heightInMetres;
                validInput = true;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Invalid input. Please enter valid heights in feet and inches.");
            }
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Invalid unit choice. Please choose either 'imperial' or 'metric'.");
            break;
        }
    }
}


        /// Method that calculates the user's BMI based on
        /// their weight and height, using the units chosen
        /// by the user.

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
                Console.WriteLine();
                Console.WriteLine("Invalid unit choice. Please choose either 'imperial' or 'metric'.");
            }
                return bmi;
        }
        
    /// Method that determines the user's weight status based on their BMI.
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

    /// Outputs the user's BMI.

            private void OutputBMI(double bmi)
        {
            Console.WriteLine();
            Console.WriteLine($"Your BMI is {bmi:f2}");
        }
    /// Outputs a message about weight status.
            private void OutputWeightStatus(string weightStatus)
        {
            Console.WriteLine();
            Console.WriteLine($"Your weight status is {weightStatus}");
        }

    }

}