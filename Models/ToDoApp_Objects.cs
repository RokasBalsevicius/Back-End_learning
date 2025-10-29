namespace ToDoApp.Objects;

/*ToDoList item objektas*/
public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool isCompleted { get; set; }

}

public class ToDoTaskItem
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Status { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime DueDate { get; set; }
}