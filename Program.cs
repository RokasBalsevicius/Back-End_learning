
using System;
using System.Collections.Generic;
using Utilities;
using ToDoApp.Methods;
using variousMethods;

namespace MyProject;

class Program
{
    static void Main(string[] args)
    {
        LearningMethods methods = new LearningMethods();

        // Utility.reversalMethod(Utility.Colors()); //Practice to work with Lists
        // List<string> reversed = Utility.reversalMethod(Utility.Colors()); //Practice to work with Lists
        // Console.WriteLine(string.Join(", ", reversed)); //Practice to work with Lists
        // Repository.SaveObjectToDB(); //Practice to work with object classes, dictionary,  multiple methods and DEMO database showcase.
        // Utility.DuplicateChecker(); //Practice to work with HashSet and clear duplicates
        // methods.TemperatureConverter(); //Practice to work with variables, input/output, if/switch
        // methods.BasicCalculator(); //Practice to work with variables, switch, arithmetic operators, input/output
        // methods.NumberGuessGame(); //Practice to work with random numbers, loops (`while`), if statements
        // methods.PerformArrayStatistics(); //Practice to work with arrays, loops (`for`, `foreach`), basic math
        // methods.PerformArrayStatisticsV2(); //Practice to work with arrays, loops (`for`, `foreach`), basic math
        // methods.ReverseTheArray(); //Practice to work with arrays, loops, methods
        // methods.TriggerToDoListManager(); //Practice to work with `List<T>`, loops, methods, switch

        // methods.UniqueWordCounter(); //Practice to work with `HashSet`, string manipulation, loops
        // methods.BrowserHistorySimulation(); //Practice to work with `Stack`, `Queue`, loops
        // methods.WordFrequencyCounter(); //Practice to work with `Dictionary`, loops, string processing
        methods.StudentGradebook(); //Combined everything what was learned above into one `Dictionary`, `List`, loops, methods, conditions

        
    }
}