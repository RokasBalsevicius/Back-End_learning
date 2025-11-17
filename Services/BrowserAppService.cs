using BrowserApp.Actions;
using BROWSERAPP.Repositories;

namespace BROWSERAPP.Services;

public class BrowserHistoryService
{
    private readonly BrowserHistoryRepository repository = new();
    private readonly BrowserHistoryActions actions = new();

    public void BrowserHistorySimulation()
    {
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
                Console.WriteLine("Invalid input entered, please try again...");
                Console.WriteLine("--------------");
                continue;
            }

            switch (userMove)
            {
                case "VISIT":
                    Console.WriteLine("Enter new page name: ");
                    string? newPage = Console.ReadLine()?.Trim();
                    actions.VisitPage(repository, newPage!);
                    continue;
                case "NEXT":
                    actions.Next(repository);
                    continue;
                case "BACK":
                    actions.Back(repository);
                    continue;
                case "DELETE":
                    actions.DeleteHistory(repository);
                    continue;
                case "EXIT":
                    Console.WriteLine("Exiting program... Bye!");
                    return;
            }
        }
    }
}
