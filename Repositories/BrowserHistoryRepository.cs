namespace BROWSERAPP.Repositories;

public class BrowserHistoryRepository
{
    public Stack<string> PagesBackwards { get; set; } = new Stack<string>();
    public Queue<string> PagesForward { get; set; } = new Queue<string>();
    public string CurrentPage { get; set; } = "HOME";
}