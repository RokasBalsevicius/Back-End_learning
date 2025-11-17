using ToDoAPP.Models;
using ToDoAPP.Repositories;

namespace ToDoAPP.Actions;

public class ToDoActions
{
    public void ShowTasks(ToDoRepository repository)
    {
        Console.WriteLine("Below are all tasks in To-Do list:");
        Console.WriteLine("---------->");
        foreach (var item in repository.Tasks)
        {
            Console.WriteLine($"Task Id: {item.Id}, Name: {item.Name}, Status: {item.Status}, Created at: {item.CreatedAt:yyyy-MM-dd}, Due date: {item.DueDate:yyyy-MM-dd}");
        }
        Console.WriteLine("----------------------------------");
    }

    public void AddTask(ToDoRepository repository)
    {
        int newTaskId = repository.Tasks.Any() ? repository.Tasks.Max(t => t.Id) + 1 : 1;

        Console.WriteLine("Enter task name: ");
        string? newTaskName = Console.ReadLine()?.Trim();

        string newTaskStatus = "";
        while (true)
        {
            Console.WriteLine("Enter task status (New / In progress / Completed)");
            newTaskStatus = Console.ReadLine()?.Trim() ?? "";
            string statusUpper = newTaskStatus.ToUpper().Trim();

            if (statusUpper != "NEW" && statusUpper != "IN PROGRESS" && statusUpper != "COMPLETED")
            {
                Console.WriteLine($"Invalid status entered - {newTaskStatus}");
                continue;
            }
            break;
        }

        DateTime dueDate;
        while (true)
        {
            Console.WriteLine("Enter due date (yyyy-MM-dd): ");
            string? dueDateInput = Console.ReadLine()?.Trim();
            if (DateTime.TryParse(dueDateInput, out dueDate) && dueDate.Date >= DateTime.Now.Date)
            {
                break;
            }
            Console.WriteLine("Invalid date or date in the past. Try again.");
        }

        var newTask = new ToDoTaskItem
        {
            Id = newTaskId,
            Name = newTaskName ?? "Untitled",
            Status = newTaskStatus,
            CreatedAt = DateTime.Now,
            DueDate = dueDate
        };

        repository.Tasks.Add(newTask);
        Console.WriteLine($"Added new task - {newTask.Name}");
    }

    public void RemoveTask(ToDoRepository repository)
    {
        while (true)
        {
            Console.WriteLine("Select the key to delete task (id / name / exit to main menu): ");
            string? key = Console.ReadLine()?.Trim().ToUpper();
            if (key != "ID" && key != "NAME" && key != "EXIT")
            {
                Console.WriteLine($"Invalid key selected {key}");
                continue;
            }

            if (key == "EXIT") return;

            switch (key)
            {
                case "ID":
                    Console.WriteLine("Enter task ID to delete: ");
                    if (!int.TryParse(Console.ReadLine(), out int id)) continue;

                    var taskById = repository.Tasks.FirstOrDefault(t => t.Id == id);
                    if (taskById == null) { Console.WriteLine($"No task with ID {id}"); continue; }

                    repository.Tasks.Remove(taskById);
                    Console.WriteLine($"Removed task Id {taskById.Id} - {taskById.Name}");
                    ShowTasks(repository);
                    break;

                case "NAME":
                    Console.WriteLine("Enter task Name to delete: ");
                    string? name = Console.ReadLine()?.Trim();
                    var taskByName = repository.Tasks.FirstOrDefault(t => t.Name == name);
                    if (taskByName == null) { Console.WriteLine($"No task with name '{name}'"); continue; }

                    repository.Tasks.Remove(taskByName);
                    Console.WriteLine($"Removed task Id {taskByName.Id} - {taskByName.Name}");
                    ShowTasks(repository);
                    break;
            }
            break;
        }
    }
}
