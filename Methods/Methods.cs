namespace variousMethods;

public class LearningMethods
{
    public double TemperatureConverter()
    {
        double convertedTemp;

        while (true)
        {
            Console.WriteLine("Choose the temperature format (type: F for Fahrenheit, C for Celsius)");
            string selectedFormat = Console.ReadLine()?.Trim().ToUpper();

            if (selectedFormat != "F" && selectedFormat != "C")
            {
                Console.WriteLine("Invalid format selected, try again...");
                continue;
            }

            Console.WriteLine($"Selected to convert temperature from {(selectedFormat == "F" ? "Celsius to Fahrenheit" : "Fahrenheit to Celsius")}");
            Console.WriteLine("Enter the temperature");

            if (!(double.TryParse(Console.ReadLine(), out double enteredTemperature)))
            {
                Console.WriteLine("Invalid number, try again...");
                continue;
            }

            convertedTemp = selectedFormat == "F" ? enteredTemperature * 1.8 + 32 : (enteredTemperature - 32) / 1.8;

            Console.WriteLine(
                $"Entered temperature {enteredTemperature} in {(selectedFormat == "F" ? "Celsius" : "Fahrenheit")}" +
                $"is {convertedTemp} in {(selectedFormat == "F" ? "Fahrenheit" : "Celsius")}");
            break;
        }
        return Math.Round(convertedTemp, 1);

    }
}