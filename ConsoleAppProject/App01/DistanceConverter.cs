using System;

namespace ConsoleAppProject.App01
{
    /// <summary>
    /// This class provides a distance converter that allows the user
    /// to convert a distance between miles, feet and metres.
    /// </summary>
    /// <author>
    /// James Patrick Arellano
    /// </author>
    
    public class DistanceConverter
    {
        // Conversion factors for miles to feet and metres
        private const double MILES_TO_FEET = 5280.0;
        private const double MILES_TO_METRES = 1609.34;
        private const double FEET_TO_METRES = 0.3048;
        private const double METRES_TO_FEET = 3.28084;
        

        // Private fields to store user inputs and conversion results
        private string fromUnit;
        private string toUnit;
        private double fromDistance;
        private double toDistance;


        /// Constructor for DistanceConverter class.
        /// Displays a welcome message to the console.

        public DistanceConverter()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine("==========================");
            Console.WriteLine("Distance Converter");
            Console.WriteLine("By James Patrick Arellano");
            Console.WriteLine("==========================");
        }


        /// Main method that runs the distance converter.
        /// Prompts the user for input, converts the distance,
        /// and prints the result to the console.

        public void Run()
        {
            Console.WriteLine("Select the unit to convert from:");
            fromUnit = GetValidUnit();

            Console.WriteLine("Select the unit to convert to:");
            toUnit = GetValidUnit();

            while (true)
            {
        Console.WriteLine($"Enter the distance in {fromUnit}:");
        if (!double.TryParse(Console.ReadLine(), out fromDistance))
        {
            Console.WriteLine("Error: Invalid distance entered");
            continue;
        }
            else if (fromDistance <= 0)
        {
            Console.WriteLine("Error: Distance must be greater than 0");
            continue;
        }

            ConvertDistance();
            PrintConversion();
            break;
        }
}

   
        /// Prompts the user to select a valid unit of measurement.
        /// <returns>The selected unit as a string.</returns>
        private string GetValidUnit()
        {
            Console.WriteLine("1. Miles");
            Console.WriteLine("2. Feet");
            Console.WriteLine("3. Metres");

            Console.Write("Enter your choice: ");

            string input = Console.ReadLine().Trim().ToLower();
            switch (input)
            {
                case "1":
                case "miles":
                    return "miles";
                case "2":
                case "feet":
                    return "feet";
                case "3":
                case "metres":
                    return "metres";
                default:

                    Console.WriteLine("Error: Invalid unit choice");
                    return GetValidUnit();
            }
        }

 
        /// Converts the distance from the "fromUnit" to the "toUnit"
        /// using the appropriate conversion factor.
  
        private void ConvertDistance()
        {
             switch (fromUnit)
            {
                case "miles":
                    if (toUnit == "feet")
                    {
                        toDistance = fromDistance * MILES_TO_FEET;
                    }
                    else if (toUnit == "metres")
                    {
                        toDistance = fromDistance * MILES_TO_METRES;
                    }
                    break;

                case "feet":
                   if (toUnit == "miles")
                    {
                        toDistance = fromDistance / MILES_TO_FEET;
                    }
                    else if (toUnit == "metres")
                    {
                        toDistance = fromDistance * FEET_TO_METRES;
                    }
                    break;

                case "metres":
                   if (toUnit == "miles")
                    {
                        toDistance = fromDistance / MILES_TO_METRES;
                    }
                    else if (toUnit == "feet")
                    {
                        toDistance = fromDistance * METRES_TO_FEET;
                    }
                    break;
            }
        }

        /// Returns the conversion factor for converting from one unit
        /// to another unit
        /// <param name="fromUnit">The unit to convert from.</param>
        /// <param name="toUnit">The unit to convert to.</param>
        /// <returns>The conversion factor


private double GetConversionFactor(string fromUnit, string toUnit)
{
    switch (fromUnit)
    {
        case "miles":
            switch (toUnit)
            {
                case "feet":
                    return 1.0 * MILES_TO_FEET;
                case "metres":
                    return 1.0 * MILES_TO_METRES;
            }
            break;
        case "feet":
            switch (toUnit)
            {
                case "miles":
                    return 1.0 / MILES_TO_FEET;
                case "metres":
                    return 1.0 * FEET_TO_METRES;
            }
            break;
        case "metres":
            switch (toUnit)
            {
                case "miles":
                    return 1.0 / MILES_TO_METRES;
                case "feet":
                    return 1.0 * METRES_TO_FEET;
            }
            break;
    }

    // If an invalid unit choice was entered, print an error message and return 0.0
    
    Console.WriteLine("Error: Invalid unit choice");
    return 0.0;
}

///This method prints the conversion result to the console
        private void PrintConversion()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{fromDistance} {fromUnit} is {toDistance} {toUnit}");
        }
    }
}
