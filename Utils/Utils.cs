using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Xml.XPath;

namespace Utilities;

public class Utility
{
    /*Zemiau yra HashSet naudojimo uzduotis sugalvota, kuriame gaunam kazkokia netvarkingu duomenu kruva, 
    ir is jos mums reikia pasalinti dublikatus. Butu galima tai padaryti su nested loop, bet jis atliks labai daug 
    lyginimu ir bus neefektyvus, tam geras metodas yra HashSet*/
    private static int[] ids = [1, 2, 3, 4, 5, 6, 7, 8, 1, 2, 5, 7, 3, 9, 12];
    public static HashSet<int> DuplicateChecker()
    {
        HashSet<int> uniqueIds = new HashSet<int>();
        foreach (int id in ids)
        {
            uniqueIds.Add(id);
        }
        Console.WriteLine(string.Join(", ", uniqueIds));
        return uniqueIds;
    }

    /*List<> collection organizatorius, kuris paima kolekcija ir grazina 
    ta nauja kolekcija atvirkstine eiles tvarka, padarytas universalus, t.y. kolekcijos tipas nera 
    hardcodintas - pratimas su kolekcijomis */
    public static List<string> Colors()
    {
        return new List<string> { "raudona", "mėlyna", "žalia" };
    }

    public static List<T> reversalMethod<T>(List<T> list)
    {
        List<T> reverseList = new List<T> { };
        foreach (T item in list)
        {
            reverseList.Insert(0, item);
        }
        Console.WriteLine(string.Join(", ", reverseList));
        return reverseList;
    }

    // Below method used for calculator function
    public decimal ReadCalcDecimal(string message, string selectedOperation = null)
    {
        decimal number;
        while (true)
        {
            Console.WriteLine(message);
            if (decimal.TryParse(Console.ReadLine(), out number))
            {
                if (selectedOperation == "/" && number == 0)
                {
                    Console.WriteLine("Division by zero is not allowed!");
                    continue;
                }
                return number;
            }
            Console.WriteLine("Invalid number entered!");
            Console.WriteLine("------");
        }
    }

    public int ReadInt(string message = "Enter number")
    {
        while (true)
        {
            Console.WriteLine(message);
            if (int.TryParse(Console.ReadLine(), out int number))
                return number;
            Console.WriteLine("Invalid number entered");
            Console.WriteLine("--------");
        }
    }

    // Below method used for calculator function
    public string ReadCalcOperation(string message)
    {
        string operationSymbol;
        while (true)
        {
            Console.WriteLine(message);
            operationSymbol = Console.ReadLine();
            if (operationSymbol == "+" || operationSymbol == "-" || operationSymbol == "*" || operationSymbol == "/")
                return operationSymbol;

            Console.WriteLine("Invalid operation symbol entered");
            Console.WriteLine("------");
        }
    }

    public int RandomNumberGenerator(int startFrom, int endAt)
    {
        Random rand = new Random();
        int randomNumber = rand.Next(startFrom, endAt);
        return randomNumber;
    }
    //Below used method in PerformArrayStatistics() to perform array statistics calculations using helper method with custom arguments
    public decimal ArrayStatisticsCalculator(decimal[] array, string arrayStatName)
    {
        if (array == null || array.Length < 1)
        {
            throw new ArgumentException("Array cannot be null or empty");
        }
        decimal result = 0;
        switch (arrayStatName.ToLower())
        {
            case "sum":
                foreach (decimal i in array)
                    result += i;
                break;
            case "average":
                foreach (decimal i in array)
                    result += i;
                result /= array.Length;
                break;
            case "min":
                result = array[0];
                foreach (decimal i in array)
                    if (i < result)
                        result = i;
                break;
            case "max":
                result = array[0];
                foreach (decimal i in array)
                    if (i > result)
                        result = i;
                break;
            default:
                throw new ArgumentException($"Invalid operation: {arrayStatName}");
        }
        return result;
    }

    public int[] ReversionOfArray(int[] array)
    {
        int[] reversedArray = (int[])array.Clone();
        Array.Reverse(reversedArray);
        return reversedArray;
    }
}