using Utilities;
using GENERAL.OtherMethods;
using BANKING.Services;
using INVENTORYMANAGER.Services;
using GradebookApp.Services;
using BROWSERAPP.Services;
using ToDoApp.Services;

namespace MyProject;

class Program
{
    static void Main(string[] args)
    {
        OtherMethods otherMethods = new OtherMethods();

        // otherMethods.reversalMethod(Utility.Colors()); //Practice to work with Lists
        // Console.WriteLine(string.Join(", ", reversed)); //Practice to work with Lists
        // otherMethods.DuplicateChecker(); //Practice to work with HashSet and clear duplicates
        // otherMethods.TemperatureConverter(); //Practice to work with variables, input/output, if/switch
        // otherMethods.BasicCalculator(); //Practice to work with variables, switch, arithmetic operators, input/output
        // otherMethods.NumberGuessGame(); //Practice to work with random numbers, loops (`while`), if statements
        // otherMethods.PerformArrayStatistics(); //Practice to work with arrays, loops (`for`, `foreach`), basic math
        // otherMethods.PerformArrayStatisticsV2(); //Practice to work with arrays, loops (`for`, `foreach`), basic math
        // otherMethods.ReverseTheArray(); //Practice to work with arrays, loops, methods

        // var app = new ToDoService();
        // app.TriggerToDoListManager(); //Practice to work with `List<T>`, loops, methods, switch


        // otherMethods.UniqueWordCounter(); //Practice to work with `HashSet`, string manipulation, loops

        // otherMethods.WordFrequencyCounter(); //Practice to work with `Dictionary`, loops, string processing

        // var appBrowser = new BrowserHistoryService();
        // appBrowser.BrowserHistorySimulation(); //Practice to work with `Stack`, `Queue`, loops


        // var appGradebook = new GradebookService();
        // appGradebook.StudentGradebook(); //Combined everything what was learned above into one `Dictionary`, `List`, loops, methods, conditions

        // var appInventory = new InventoryService();
        // appInventory.ManageInventory(); //Combined everything again to apply `Dictionary`, `List`, loops, methods, switch (nested List is not used in real life, but wanted to practice more about manipulating nested variables and objects)


        // var appBanking = new BankingService();
        // appBanking.BankingApplication(); //Combined everything and made more complex object to store information, more complex validations

    }
}