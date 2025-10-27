using System;
using System.Collections.Generic;
using System.Security.Cryptography;

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

    public int ReadInt(string message)
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
}