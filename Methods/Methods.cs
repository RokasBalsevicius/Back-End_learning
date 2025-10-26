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



    //### 2. Simple Calculator - in progress...

    //**Topics:** variables, switch, arithmetic operators, input/output
    // * Ask for two numbers and an operation symbol (`+`, `-`, `*`, `/`).
    // * Use a `switch` statement to perform the operation.
    // * Handle division by zero.

    public void Calculator()
    {
        while (true)
        {
            Console.WriteLine("Enter first number");
            if (!(decimal.TryParse(Console.ReadLine(), out decimal firstNumber)))
            {
                Console.WriteLine("Invalid first number entered");
                continue;
            }

            Console.WriteLine("Enter operation symbol ('+' - addition, '-' - subtraction, '*' - multiplication, '/' - division)");
            string operationSymbol = Console.ReadLine();
            if (operationSymbol != "+" && operationSymbol != "-" && operationSymbol != "*" && operationSymbol != "/")
            {
                Console.WriteLine("Invalid operation symbol entered");
                continue;
            }

            Console.WriteLine("Enter second number");
            if (!(decimal.TryParse(Console.ReadLine(), out decimal secondNumber)))
            {
                Console.WriteLine("Invalid second number entered");
                continue;
            }

            decimal result;
            switch (operationSymbol)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    if (secondNumber == 0)
                    {
                        Console.WriteLine("Division by zero is not allowed!");
                        continue;
                    }
                    else
                    {
                        result = firstNumber / secondNumber;
                        break;
                    }
                default:
                    Console.WriteLine("Invalid operation!");
                    return;
            }
            Console.WriteLine($"Arithmetic result of {firstNumber} {operationSymbol} {secondNumber} is {result}");
            break;
        }
    }
}