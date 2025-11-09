using Utilities;
using ToDoApp.Methods;
using ToDoManager;
using System.Diagnostics;
using System.Collections;

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
            int guessedNumber = utils.ReadInt("Place your guess. Enter the number between 1 and 100!");
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
                array[i] = utils.ReadInt($"Entering number: {i + 1}");
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

    public void TriggerToDoListManager()
    {
        ToDoManagerClass dataBase = new ToDoManagerClass();

        while (true)
        {
            Console.WriteLine("Enter navigation option from Menu:");
            Console.WriteLine("1 - Add task");
            Console.WriteLine("2 - Remove task");
            Console.WriteLine("3 - Show all tasks");
            Console.WriteLine("4 - Exit");

            if (!int.TryParse(Console.ReadLine(), out int userChoice))
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 5!");
                continue;
            }
            switch (userChoice)
            {
                case 1:
                    dataBase.AddTask();
                    break;
                case 2:
                    dataBase.ShowToDoList();
                    dataBase.RemoveTask();
                    break;
                case 3:
                    dataBase.ShowToDoList();
                    break;
                case 4:
                    Console.WriteLine("Bye!");
                    return;
                default:
                    Console.WriteLine("Incorrect choice");
                    break;
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

    public void BrowserHistorySimulation()
    {
        Stack<string> pagesBackwards = new Stack<string>();
        Queue<string> pagesForward = new Queue<string>();
        string currentPage = "HOME";

        while (true)
        {
            Console.WriteLine("Enter navigation option from Menu:");
            Console.WriteLine("Visit");
            Console.WriteLine("Next");
            Console.WriteLine("Back");
            Console.WriteLine("Delete");
            Console.WriteLine("Exit");

            string? userMove = Console.ReadLine()?.Trim().ToUpper();

            if (userMove != "VISIT" && userMove != "NEXT" && userMove != "BACK" && userMove != "EXIT" && userMove != "DELETE")
            {
                Console.WriteLine("Invalid imput entered, please try again...");
                Console.WriteLine("--------------");
                continue;
            }
            switch (userMove)
            {
                case "DELETE":
                    while (true)
                    {
                        Console.WriteLine("History will be deleted. Are you sure Y - yes, N - no, RETURN - go back to main menu");
                        string? controlQuestionInput = Console.ReadLine()?.Trim().ToUpper();
                        if (controlQuestionInput != "Y" && controlQuestionInput != "N" && controlQuestionInput != "RETURN")
                        {
                            Console.WriteLine("Invalid input, try again...");
                            continue;
                        }
                        switch (controlQuestionInput)
                        {
                            case "Y":
                                Console.WriteLine("Deleting all history..");
                                currentPage = "HOME";
                                pagesForward.Clear();
                                pagesBackwards.Clear();
                                break;
                            case "N":
                                Console.WriteLine("History not deleted");
                                break;
                            case "RETURN":
                                Console.WriteLine("Returning to main menu");
                                break;
                            default:
                                Console.WriteLine("Invalid input, try again....");
                                continue;
                        }
                        break;
                    }
                    continue;
                case "VISIT":
                    Console.WriteLine("Enter new page name: ");
                    string? newPage = Console.ReadLine()?.Trim();
                    pagesBackwards.Push(currentPage);
                    pagesForward.Clear();
                    currentPage = newPage;
                    Console.WriteLine($"Currently in page {currentPage}");
                    continue;
                case "NEXT":
                    if (pagesForward.Count > 0)
                    {
                        pagesBackwards.Push(currentPage);
                        currentPage = pagesForward.Dequeue();
                        Console.WriteLine($"Currently in page {currentPage}");
                        continue;
                    }
                    Console.WriteLine("No forward history exists");
                    continue;
                case "BACK":
                    if (pagesBackwards.Count > 0)
                    {
                        pagesForward.Enqueue(currentPage);
                        currentPage = pagesBackwards.Pop();
                        Console.WriteLine($"Currently in page {currentPage}");
                        continue;
                    }
                    Console.WriteLine("Your history is empty!");
                    continue;
                case "EXIT":
                    Console.WriteLine("Exiting program... Bye!");
                    return;
                default:
                    Console.WriteLine("Invalid input, try again...");
                    continue;
            }
        }
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

    public void StudentGradebook()
    {
        Utility utils = new Utility();
        Dictionary<string, List<decimal>> gradebook = new Dictionary<string, List<decimal>>
        {
            {"ROKAS", new List<decimal> {10, 4, 2, 5, 7, 8, 9}},
            {"EMA", new List<decimal> {10, 9, 8, 10, 7, 8, 10}}
        };

        while (true)
        {
            Console.WriteLine("Gradebook Menu:");
            Console.WriteLine("1 - Add student");
            Console.WriteLine("2 - Add grade to a student");
            Console.WriteLine("3 - Show average grade per student");
            Console.WriteLine("4 - Show top-performing student");
            Console.WriteLine("5 - Exit");
            Console.WriteLine("<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>");

            int userMenuChoice = utils.ReadInt("Enter menu option: ");

            switch (userMenuChoice)
            {
                case 1:
                    while (true)
                    {
                        Console.WriteLine("Adding a new student. Please enter student's name: ");
                        string? newStudentName = Console.ReadLine()?.Trim().ToUpper();
                        if (string.IsNullOrWhiteSpace(newStudentName))
                        {
                            Console.WriteLine("Student name cannot be null. Please enter a valid student name");
                            continue;
                        }
                        if (!gradebook.ContainsKey(newStudentName))
                        {
                            gradebook[newStudentName] = new List<decimal> { };
                            Console.WriteLine($"Added student: {newStudentName}");
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Student name '{newStudentName}' already exists!");
                            continue;
                        }
                    }
                    continue;

                case 2:
                    while (true)
                    {
                        Console.WriteLine("Enter student name to add a grade: ");
                        string? studentName = Console.ReadLine()?.Trim().ToUpper();
                        if (!gradebook.ContainsKey(studentName) || string.IsNullOrWhiteSpace(studentName))
                        {
                            Console.WriteLine($"No student with entered name '{studentName}' exists or entered value is null");
                            continue;
                        }
                        decimal grade;
                        while (true)
                        {
                            Console.WriteLine("Enter the grade you want to add or 'Exit' to return to main menu");
                            string? input = Console.ReadLine()?.Trim().ToUpper();
                            if (input == "EXIT")
                            {
                                Console.WriteLine("Exiting to main menu....");
                                Console.WriteLine("-------------------");
                                break;
                            }
                            if (!decimal.TryParse(input, out grade) || grade < 1 || grade > 10)
                            {
                                Console.WriteLine("Invalid number entered. Please enter grade between 1.0 and 10.0");
                                continue;
                            }
                            else
                            {
                                List<decimal> grades = gradebook[studentName];
                                grades.Add(Math.Round(grade, 1));
                                Console.WriteLine($"Grade '{Math.Round(grade, 1)}' added succesfully. ");
                                Console.WriteLine($"Current grades of student '{studentName}' are: " + string.Join(", ", grades));
                                continue;
                            }
                        }
                        break;
                    }
                    continue;

                case 3:
                    while (true)
                    {

                        Console.WriteLine("Currently existing names in gradebook: " + string.Join(", ", gradebook.Keys));
                        Console.WriteLine("Enter student name you want to check average grade: ");
                        string? name = Console.ReadLine()?.Trim().ToUpper();
                        if (string.IsNullOrWhiteSpace(name))
                        {
                            Console.WriteLine("Student name cannot be null. Please enter a valid student name");
                            continue;
                        }
                        if (!gradebook.ContainsKey(name))
                        {
                            Console.WriteLine($"Student with name '{name}' does not exist. Please enter another name for the below list");
                            continue;
                        }
                        List<decimal> grades = gradebook[name];
                        Console.WriteLine($"Average grade for student '{name}' is {Math.Round(grades.Average(), 1)}");
                        break;
                    }
                    continue;

                case 4:
                    string topPerformer = null;
                    decimal averageGrade = 0;

                    foreach (var student in gradebook)
                    {
                        decimal oneStudentGrade = student.Value.Average();
                        if (averageGrade < oneStudentGrade)
                        {
                            averageGrade = Math.Round(oneStudentGrade, 1);
                            topPerformer = student.Key;
                        }
                    }
                    Console.WriteLine($"Top performer is student '{topPerformer}' with the average grade '{averageGrade}'.");
                    continue;
                case 5:
                    Console.WriteLine("Exiting program...Bye!");
                    return;
                default:
                    Console.WriteLine("Invalid menu option selected...");
                    continue;
            }
        }
    }

    public void ManageInventory()
    {

        Utility utils = new Utility();

        Dictionary<String, List<int>> storage = new Dictionary<string, List<int>>
        {
            {"MESA", new List<int>{}},
            {"POMIDORAI", new List<int>{}}
        };

        while (true)
        {
            Console.WriteLine("Inventory Management MENU: ");
            Console.WriteLine("1 - Add new item");
            Console.WriteLine("2 - Update quantity");
            Console.WriteLine("3 - Remove item");
            Console.WriteLine("4 - Display all items");
            Console.WriteLine("5 - Exit");

            int menuOption = utils.ReadInt("Enter menu option: ");

            switch (menuOption)
            {
                case 1:
                    while (true)
                    {
                        Console.WriteLine("Enter the name of new item or 'Exit' to go back to main menu: ");
                        string? newItem = Console.ReadLine()?.Trim().ToUpper();
                        if (newItem == "EXIT") break;

                        if (storage.ContainsKey(newItem))
                        {
                            Console.WriteLine("Item already exists");
                            Console.WriteLine("Currently storage contains");
                            foreach (var item in storage)
                            {
                                Console.WriteLine($"Item: {item.Key}, quantity: {string.Join(", ", item.Value)}");
                            }
                            continue;
                        }
                        storage[newItem] = new List<int> { };
                        Console.WriteLine($"New item '{newItem}' added to storage");
                        while (true)
                        {
                            Console.WriteLine($"Do you want to also add quantity for new item '{newItem}'? Y - yes, N - no");
                            string? quantityForNewItem = Console.ReadLine()?.Trim().ToUpper();
                            if (quantityForNewItem == "Y")
                            {
                                int quantity = utils.ReadInt("Enter quantity");
                                List<int> itemQuantity = storage[newItem];
                                itemQuantity.Add(quantity);
                                break;

                            }
                            else if (quantityForNewItem == "N")
                            {
                                Console.WriteLine("Exiting to main menu");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid action selected, try again...");
                                continue;
                            }
                        }
                        break;
                    }
                    continue;
                case 2:
                    while (true)
                    {
                        Console.WriteLine("Enter the name of item from the storage you want to update quantity or 'Exit' for main menu: ");
                        string? itemName = Console.ReadLine()?.Trim().ToUpper();
                        if (itemName == "EXIT") break;
                        if (!storage.ContainsKey(itemName))
                        {
                            Console.WriteLine("Item does not exists in the storage.");
                            Console.WriteLine("Currently storage contains: ");
                            foreach (var item in storage)
                            {
                                Console.WriteLine($"Item: '{item.Key}', quantity: '{string.Join(", ", item.Value)}'");
                            }
                            continue;
                        }
                        while (true)
                        {
                            int quantity = utils.ReadInt($"Enter quantity you want to set for item {itemName}");
                            List<int> itemQuantity = storage[itemName];
                            itemQuantity.Clear();
                            itemQuantity.Add(quantity);
                            Console.WriteLine($"Updated quantity for item '{itemName}' to '{quantity}'");
                            break;
                        }
                        break;
                    }
                    continue;
                case 3:
                    while (true)
                    {
                        Console.WriteLine("Enter the name of item from the storage you want to remove or 'Exit' for main menu: ");
                        string? itemName = Console.ReadLine()?.Trim().ToUpper();
                        if (itemName == "EXIT") break;
                        if (!storage.ContainsKey(itemName))
                        {
                            Console.WriteLine("Item does not exists in the storage.");
                            Console.WriteLine("Currently storage contains: ");
                            foreach (var item in storage)
                            {
                                Console.WriteLine($"Item: '{item.Key}', quantity: '{string.Join(", ", item.Value)}'");
                            }
                            continue;
                        }
                        storage.Remove(itemName);
                        Console.WriteLine($"Item '{itemName}' successfully removed from the storage");
                        Console.WriteLine("Updated storage contains: ");
                        foreach (var item in storage)
                        {
                            Console.Write($"{item.Key}, ");
                        }
                        Console.WriteLine();
                        break;
                    }
                    continue;
                case 4:
                    Console.WriteLine("Currently storage contains the following: ");
                    foreach (var item in storage) {
                        Console.WriteLine($"Item: {item.Key}, quantity: {string.Join(", ", item.Value)}");
                    }
                    continue;
                case 5:
                    Console.WriteLine("Exiting program...Bye!");
                    return;
                default:
                    Console.WriteLine("Invalid menu option selected!");
                    continue;
            }
        }
    }
}