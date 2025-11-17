using ToDoAPP.Actions;
using ToDoAPP.Repositories;

namespace ToDoApp.Services;

public class ToDoService
{
    private readonly ToDoRepository repository = new();
    private readonly ToDoActions actions = new();

    public void TriggerToDoListManager()
    {
        while (true)
        {
            Console.WriteLine("Enter navigation option from Menu:");
            Console.WriteLine("1 - Add task");
            Console.WriteLine("2 - Remove task");
            Console.WriteLine("3 - Show all tasks");
            Console.WriteLine("4 - Exit");

            if (!int.TryParse(Console.ReadLine(), out int userChoice))
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4!");
                continue;
            }

            switch (userChoice)
            {
                case 1:
                    actions.AddTask(repository);
                    break;
                case 2:
                    actions.ShowTasks(repository);
                    actions.RemoveTask(repository);
                    break;
                case 3:
                    actions.ShowTasks(repository);
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
}
