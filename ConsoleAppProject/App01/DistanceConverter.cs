using System;

namespace ConsoleAppProject.App01
{
/// <summary>
/// This class converts a distance between miles, feet and metres
/// </summary>
/// <author>
/// Derek
/// </author>
public class DistanceConverter
{
private const double MILES_TO_FEET = 5280.0;
private const double MILES_TO_METRES = 1609.34;

    private string fromUnit;
    private string toUnit;
    private double fromDistance;
    private double toDistance;

    public DistanceConverter()
    {
        Console.WriteLine("Distance Converter");
        Console.WriteLine("By James Patrick Arellano");
    }

    public void Run()
    {
        Console.WriteLine("Select the unit to convert from:");
        fromUnit = SelectUnit();

        Console.WriteLine("Select the unit to convert to:");
        toUnit = SelectUnit();

        Console.WriteLine($"Enter the distance in {fromUnit}:");
        if (!double.TryParse(Console.ReadLine(), out fromDistance))
        {
            Console.WriteLine("Error: Invalid distance entered");
            return;
        }

        ConvertDistance();
        Print();
    }

    private string SelectUnit()
    {
        Console.WriteLine("1. Miles");
        Console.WriteLine("2. Feet");
        Console.WriteLine("3. Metres");
        Console.Write("Enter your choice: ");

        switch (Console.ReadLine())
        {
            case "1":
                return "miles";
            case "2":
                return "feet";
            case "3":
                return "metres";
            default:
                Console.WriteLine("Error: Invalid unit choice");
                return null;
        }
    }

    private void ConvertDistance()
    {
        switch (fromUnit)
        {
            case "miles":
                toDistance = fromDistance * GetConversionFactor(toUnit, "feet") * GetConversionFactor("miles", "feet");
                break;
            case "feet":
                toDistance = fromDistance * GetConversionFactor(toUnit, "feet");
                break;
            case "metres":
                toDistance = fromDistance * GetConversionFactor(toUnit, "metres");
                break;
        }
    }

    private double GetConversionFactor(string fromUnit, string toUnit)
    {
        switch (fromUnit)
        {
            case "miles":
                switch (toUnit)
                {
                    case "feet":
                        return MILES_TO_FEET;
                    case "metres":
                        return MILES_TO_METRES;
                }
                break;
            case "feet":
                switch (toUnit)
                {
                    case "miles":
                        return 1.0 / MILES_TO_FEET;
                    case "metres":
                        return 0.3048;
                }
                break;
            case "metres":
                switch (toUnit)
                {
                    case "miles":
                        return 1.0 / MILES_TO_METRES;
                    case "feet":
                        return 3.28084;
                }
                break;
        }

        Console.WriteLine("Error: Invalid unit choice");
        return 0.0;
    }

    private void Print()
    {
        Console.WriteLine($"{fromDistance} {fromUnit} is {toDistance} {toUnit}");
    }
}

}
