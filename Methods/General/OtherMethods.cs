using Utilities;

namespace GENERAL.OtherMethods;

public class OtherMethods
{
    public readonly Utility utils = new();
    public HashSet<int> DuplicateChecker()
    {
        int[] ids = utils.ids;
        HashSet<int> uniqueIds = new HashSet<int>();
        foreach (int id in ids)
        {
            uniqueIds.Add(id);
        }
        Console.WriteLine(string.Join(", ", uniqueIds));
        return uniqueIds;
    }
    public List<T> reversalMethod<T>(List<T> list)
    {
        List<T> reverseList = new List<T> { };
        foreach (T item in list)
        {
            reverseList.Insert(0, item);
        }
        Console.WriteLine(string.Join(", ", reverseList));
        return reverseList;
    }
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

    public void BasicCalculator()
    {
        Utility utils = new Utility();
        decimal firstNumber = utils.ReadCalcDecimal("Enter first number");
        string operationSymbol = utils.ReadCalcOperation("Enter operation symbol ('+' - addition, '-' - subtraction, '*' - multiplication, '/' - division)");
        decimal secondNumber = utils.ReadCalcDecimal("Enter second number", "/");

        decimal result = operationSymbol switch
        {
            "+" => firstNumber + secondNumber,
            "-" => firstNumber - secondNumber,
            "*" => firstNumber * secondNumber,
            "/" => firstNumber / secondNumber,
            _ => 0
        };
        Console.WriteLine($"Arithmetic result of {firstNumber} {operationSymbol} {secondNumber} is {result}");
    }

    public void NumberGuessGame()
    {
        Utility utils = new Utility();
        int randomNumber = utils.RandomNumberGenerator(0, 101);
        int guessCount = 0;

        while (true)
        {
            int guessedNumber = utils.ReadNumber<int>("Place your guess. Enter the number between 1 and 100!");
            guessCount++;

            if (guessedNumber < randomNumber)
            {
                Console.WriteLine($"Incorrect guess. Hint: entered number {guessedNumber} is too low. Incorrect guess count: {guessCount}");
                Console.WriteLine("--------");
            }
            else if (guessedNumber > randomNumber)
            {
                Console.WriteLine($"Incorrect guess. Hint: entered number {guessedNumber} is too high. Incorrect guess count: {guessCount}");
                Console.WriteLine("--------");
            }
            else
            {
                Console.WriteLine($"Correct!! Took {guessCount} attempts");
                break;
            }
        }
    }

    public void PerformArrayStatistics() //Kept this method to practice calling another method with custom arguments
    {
        Utility utils = new Utility();

        Console.WriteLine("Declare array length:");
        if (!int.TryParse(Console.ReadLine(), out int arrayLength) || arrayLength < 0)
            throw new ArgumentException("Array lenght must be number and cannot be less than 1");

        decimal[] inputArray = new decimal[arrayLength];

        for (int i = 0; i < inputArray.Length; i++)
            inputArray[i] = utils.ReadCalcDecimal($"Enter any number {i + 1}");

        Console.WriteLine(string.Join(", ", inputArray));

        Console.WriteLine($"Array elements sum is: {utils.ArrayStatisticsCalculator(inputArray, "sum")}");
        Console.WriteLine($"Array average value is: {utils.ArrayStatisticsCalculator(inputArray, "average")}");
        Console.WriteLine($"Smallest element in the array is: {utils.ArrayStatisticsCalculator(inputArray, "min")}");
        Console.WriteLine($"Largest element in the array is: {utils.ArrayStatisticsCalculator(inputArray, "max")}");
    }

    public void PerformArrayStatisticsV2() //Cleaner version for the same method PerformArrayStatistics
    {
        Utility utils = new Utility();

        Console.WriteLine("Declare array length:");
        if (!int.TryParse(Console.ReadLine(), out int arrayLength) || arrayLength < 0)
            throw new ArgumentException("Array lenght must be number and cannot be less than 1");

        decimal[] inputArray = new decimal[arrayLength];

        for (int i = 0; i < inputArray.Length; i++)
            inputArray[i] = utils.ReadCalcDecimal($"Enter any number {i + 1}");

        Console.WriteLine(string.Join(", ", inputArray));

        decimal sum = 0;
        decimal average = 0;
        decimal min = inputArray[0];
        decimal max = inputArray[0];

        for (int i = 0; i < inputArray.Length; i++)
        {
            sum += inputArray[i];
            if (min > inputArray[i]) min = inputArray[i];
            if (max < inputArray[i]) max = inputArray[i];
        }
        average = sum / inputArray.Length;

        Console.WriteLine($"Array elements sum is: {sum}");
        Console.WriteLine($"Array average value is: {average}");
        Console.WriteLine($"Smallest element in the array is: {min}");
        Console.WriteLine($"Largest element in the array is: {max}");
    }

    public void ReverseTheArray()
    {
        Utility utils = new Utility();

        while (true)
        {
            Console.WriteLine("Enter array length:");
            if (!int.TryParse(Console.ReadLine(), out int arrayLength) || arrayLength < 1)
            {
                Console.WriteLine("Array lenght must be number and cannot be less than 1");
                continue;
            }

            int[] array = new int[arrayLength];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = utils.ReadNumber<int>($"Entering number: {i + 1}");
            }

            Console.WriteLine($"Current array length is {arrayLength} and array contains {string.Join(", ", array)}");

            while (true)
            {
                Console.WriteLine("Do you want to make the array reversed? Y - yes, N - no");
                string selectedAnswer = Console.ReadLine()?.Trim().ToUpper();

                if (selectedAnswer == "Y")
                {
                    Console.WriteLine("Creating reversed array...");
                    int[] reversedArray = utils.ReversionOfArray(array);
                    Console.WriteLine($"Reversed array is {string.Join(", ", reversedArray)}");
                    return;
                }
                ;
                if (selectedAnswer == "N")
                {
                    Console.WriteLine("Closing program...");
                    return;
                }
                ;
                Console.WriteLine("Invalid selection...");
            }
        }
    }

    public void UniqueWordCounter()
    {
        Console.WriteLine("Enter any sentence you wish:");
        string userInput = Console.ReadLine();
        string[] userInputArray = userInput.Split(new char[] { ' ', ',', '.', ';' }, StringSplitOptions.RemoveEmptyEntries);
        Console.WriteLine("Your sentence contains the following words: " + string.Join(", ", userInputArray));

        HashSet<string> uniqueWords = new HashSet<string>();
        foreach (string word in userInputArray)
        {
            uniqueWords.Add(word);
        }
        Console.WriteLine($"Your enterred sentence contains the following unique words: {string.Join(", ", uniqueWords)}");
    }

    public void WordFrequencyCounter()
    {
        Dictionary<string, int> individualWords = new Dictionary<string, int>();
        Console.WriteLine("Enter sentence or paragraph:");
        string userInput = Console.ReadLine();
        string[] splitWords = userInput.Split(new char[] { ' ', ',', '.', ';' }, StringSplitOptions.RemoveEmptyEntries);
        string[] processedWords = new string[splitWords.Length];

        for (int i = 0; i < splitWords.Length; i++)
            processedWords[i] = splitWords[i].Trim(new char[] { ' ', ',', '.', ';', '!', '?' }).ToLower();

        Console.WriteLine("Processed words are: " + string.Join(", ", processedWords));

        foreach (string word in processedWords)
            if (!individualWords.ContainsKey(word))
                individualWords[word] = 1;
            else
                individualWords[word]++;

        foreach (var item in individualWords)
            Console.WriteLine($"Word '{item.Key}' repeats {item.Value} times");
    }
}