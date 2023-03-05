using System;

namespace ConsoleAppProject.App02
{
    /// <summary>
    /// This class calculates the Body Mass Index (BMI)
    /// and determines the weight status of a person based on their BMI.
    /// </summary>
    /// <author>
    /// James Patrick Arellano version 0.1
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

        /// <summary>
        /// Run method to start the BMI calculator.
        /// </summary>
        public void Run()
        {
            OutputHeading();

            InputWeight();
            InputHeight();

            double bmi = CalculateBMI();
            string weightStatus = CalculateWeightStatus(bmi);

            OutputBMI(bmi);
            OutputWeightStatus(weightStatus);
        }

        private void OutputHeading()
        {
            Console.WriteLine("This application calculates your BMI value");
            Console.WriteLine("and determines your weight status based on your BMI.");
            Console.WriteLine();
        }

        private void InputWeight()
        {
            Console.Write("Enter your weight in kg: ");
            string input = Console.ReadLine();
            weight = Convert.ToDouble(input);
        }

        private void InputHeight()
        {
            Console.Write("Enter your height in metres: ");
            string input = Console.ReadLine();
            height = Convert.ToDouble(input);
        }

        public double CalculateBMI()
        {
            return weight / (height * height);
        }

        private string CalculateWeightStatus(double bmi)
        {
            if (bmi < UNDERWEIGHT_BMI)
            {
                return "Underweight";
            }
            else if (bmi < NORMAL_BMI)
            {
                return "Normal";
            }
            else if (bmi < OVERWEIGHT_BMI)
            {
                return "Overweight";
            }
            else if (bmi < OBESE_CLASS_1_BMI)
            {
                return "Obese Class I";
            }
            else if (bmi < OBESE_CLASS_2_BMI)
            {
                return "Obese Class II";
            }
            else
            {
                return "Obese Class III";
            }
        }

        private void OutputBMI(double bmi)
        {
            Console.WriteLine($"Your BMI value is {bmi:F2}");
        }

        private void OutputWeightStatus(string weightStatus)
        {
            Console.WriteLine($"Your weight status is {weightStatus}");
        }
    }
}

