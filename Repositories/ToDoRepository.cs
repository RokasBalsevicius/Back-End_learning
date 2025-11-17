using ToDoAPP.Models;

namespace ToDoAPP.Repositories;

public class ToDoRepository
{
    public List<ToDoTaskItem> Tasks { get; } = new List<ToDoTaskItem>
    {
        new ToDoTaskItem {Id = 1, Name = "Clean house", Status = "New", CreatedAt = DateTime.Now.AddDays(-10), DueDate = new DateTime(2025, 11, 01)},
        new ToDoTaskItem {Id = 2, Name = "Groceries", Status = "In progress", CreatedAt = DateTime.Now.AddDays(-4), DueDate = new DateTime(2025, 10, 29)},
        new ToDoTaskItem {Id = 3, Name = "Wash dishes", Status = "Completed", CreatedAt = DateTime.Now.AddDays(-3), DueDate = new DateTime(2025, 10, 20)}
    };
}
