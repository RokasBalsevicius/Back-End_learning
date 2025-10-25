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

            if (selectedFormat == "F")
            {
                Console.WriteLine("Selected to convert temperature from Celsius to Fahrenheit");
                Console.WriteLine("Enter the temperature");
                double enteredTemperature = double.Parse(Console.ReadLine());
                convertedTemp = enteredTemperature * 1.8 + 32;
                Console.WriteLine($"Entered tempareture {enteredTemperature} in Celsius is {convertedTemp} in Fahrenheit");
                break;
            }
            else if (selectedFormat == "C")
            {
                Console.WriteLine("Selected to convert temperature from Fahrenheit to Celsius");
                Console.WriteLine("Enter the temperature");
                double enteredTemperature = double.Parse(Console.ReadLine());
                convertedTemp = (enteredTemperature - 32) / 1.8;
                Console.WriteLine($"Entered tempareture {enteredTemperature} in Fahrenheit is {convertedTemp} in Celsius");
                break;
            }
            else
            {
                Console.WriteLine("Invalid format selected, try again...");
            }
        }
        return convertedTemp;

    }
}