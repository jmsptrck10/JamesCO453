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

        private DistanceUnits fromUnit;
        private DistanceUnits toUnit;
        private double fromDistance;
        private double toDistance;


        /// Displays a description of the app.

        public DistanceConverter()
        {
            Console.WriteLine("This application allows you to convert");
            Console.WriteLine("a distance between miles, feet and metres.");
            Console.WriteLine();
        }


        /// Main method that runs the distance converter.
        /// Prompts the user for input, converts the distance,
        /// and prints the result to the console.

        public void Run()
        {
            Console.WriteLine();
            Console.WriteLine("Select the unit to convert from:");
            fromUnit = GetValidUnit();

            Console.WriteLine("Select the unit to convert to:");
            toUnit = GetValidUnit();

            while (true)
            {
                Console.WriteLine($"Enter the distance in {fromUnit}:");
                if (!double.TryParse(Console.ReadLine(), out fromDistance))
                {
                    Console.WriteLine();
                    Console.WriteLine("Error: Invalid distance entered");
                    continue;
                }
                else if (fromDistance <= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Error: Distance must be greater than 0");
                    continue;
                }

                ConvertDistance();
                PrintConversion();
                break;
            }
        }

        private DistanceUnits GetValidUnit()
        {
            Console.WriteLine();
            Console.WriteLine("1. Miles");
            Console.WriteLine("2. Feet");
            Console.WriteLine("3. Metres");

            Console.WriteLine();
            Console.Write("Enter your choice: ");

            string input = Console.ReadLine().Trim().ToLower();
            switch (input)
            {
                case "1":
                case "miles":
                    return DistanceUnits.Miles;
                case "2":
                case "feet":
                    return DistanceUnits.Feet;
                case "3":
                case "metres":
                    return DistanceUnits.Metres;
                default:

                    Console.WriteLine();
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
                case DistanceUnits.Miles:
                    if (toUnit == DistanceUnits.Feet)
                    {
                        toDistance = fromDistance * MILES_TO_FEET;
                    }
                    else if (toUnit == DistanceUnits.Metres)
                    {
                        toDistance = fromDistance * MILES_TO_METRES;
                    }
                    break;

                case DistanceUnits.Feet:
                    if (toUnit == DistanceUnits.Miles)
                    {
                        toDistance = fromDistance / MILES_TO_FEET;
                    }
                    else if (toUnit == DistanceUnits.Metres)
                    {
                        toDistance = fromDistance * FEET_TO_METRES;
                    }
                    break;

                case DistanceUnits.Metres:
                    if (toUnit == DistanceUnits.Miles)
                    {
                        toDistance = fromDistance / MILES_TO_METRES;
                    }
                    else if (toUnit == DistanceUnits.Feet)
                    {
                        toDistance = fromDistance * METRES_TO_FEET;
                    }
                    break;
            }
        }

/// Returns the conversion factor for converting from one unit
/// to another unit
private double GetConversionFactor(DistanceUnits fromUnit, DistanceUnits toUnit)
{
    switch (fromUnit)
    {
        case DistanceUnits.Miles:
            switch (toUnit)
            {
                case DistanceUnits.Feet:
                    return 1.0 * MILES_TO_FEET;
                case DistanceUnits.Metres:
                    return 1.0 * MILES_TO_METRES;
            }
            break;
        case DistanceUnits.Feet:
            switch (toUnit)
            {
                case DistanceUnits.Miles:
                    return 1.0 / MILES_TO_FEET;
                case DistanceUnits.Metres:
                    return 1.0 * FEET_TO_METRES;
            }
            break;
        case DistanceUnits.Metres:
            switch (toUnit)
            {
                case DistanceUnits.Miles:
                    return 1.0 / MILES_TO_METRES;
                case DistanceUnits.Feet:
                    return 1.0 * METRES_TO_FEET;
            }
            break;
    }

    // If an invalid unit choice was entered, print an error message and return 0.0
    
    Console.WriteLine();
    Console.WriteLine("Error: Invalid unit choice");
    return 0.0;
}

///This method prints the conversion result to the console
        private void PrintConversion()
        {            
            Console.WriteLine();
            Console.WriteLine($"{fromDistance} {fromUnit} is {toDistance} {toUnit}");
        }
    }
}
