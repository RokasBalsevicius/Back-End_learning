
using System;
using System.Collections.Generic;
using Utilities;
using ToDoApp.Methods;

namespace MyProject;

class Program
{
    static void Main(string[] args)
    {
        Utility.reversalMethod(Utility.Colors());
        // List<string> reversed = Utility.reversalMethod(Utility.Colors());
        // Console.WriteLine(string.Join(", ", reversed));

        Repository.SaveObjectToDB();
        Utility.DuplicateChecker();
    }
}