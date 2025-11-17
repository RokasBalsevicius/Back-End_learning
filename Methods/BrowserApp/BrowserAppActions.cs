using BROWSERAPP.Repositories;

namespace BrowserApp.Actions;

public class BrowserHistoryActions
{
    public void VisitPage(BrowserHistoryRepository repository, string newPage)
    {
        repository.PagesBackwards.Push(repository.CurrentPage);
        repository.PagesForward.Clear();
        repository.CurrentPage = newPage;
        Console.WriteLine($"Currently in page {repository.CurrentPage}");
    }

    public void Back(BrowserHistoryRepository repository)
    {
        if (repository.PagesBackwards.Count > 0)
        {
            repository.PagesForward.Enqueue(repository.CurrentPage);
            repository.CurrentPage = repository.PagesBackwards.Pop();
            Console.WriteLine($"Currently in page {repository.CurrentPage}");
        }
        else
        {
            Console.WriteLine("Your history is empty!");
        }
    }

    public void Next(BrowserHistoryRepository repository)
    {
        if (repository.PagesForward.Count > 0)
        {
            repository.PagesBackwards.Push(repository.CurrentPage);
            repository.CurrentPage = repository.PagesForward.Dequeue();
            Console.WriteLine($"Currently in page {repository.CurrentPage}");
        }
        else
        {
            Console.WriteLine("No forward history exists");
        }
    }

    public void DeleteHistory(BrowserHistoryRepository repository)
    {
        while (true)
        {
            Console.WriteLine("History will be deleted. Are you sure Y - yes, N - no, RETURN - go back to main menu");
            string? input = Console.ReadLine()?.Trim().ToUpper();
            if (input != "Y" && input != "N" && input != "RETURN")
            {
                Console.WriteLine("Invalid input, try again...");
                continue;
            }

            switch (input)
            {
                case "Y":
                    repository.CurrentPage = "HOME";
                    repository.PagesBackwards.Clear();
                    repository.PagesForward.Clear();
                    Console.WriteLine("All history deleted. Back to HOME page.");
                    break;
                case "N":
                    Console.WriteLine("History not deleted.");
                    break;
                case "RETURN":
                    Console.WriteLine("Returning to main menu...");
                    break;
            }
            break;
        }
    }
}
