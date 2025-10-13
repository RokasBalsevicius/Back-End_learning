using System;
using System.Collections.Generic;
using ToDoApp.Objects;

namespace ToDoApp.Methods;

/*ToDoList uzduoties demo duombaze*/
public partial class Repository
{
    private static List<TaskItem> DataBase = new List<TaskItem>()
    {
        new TaskItem {Id = 1, Title = "Create C# learning environment", isCompleted = true},
        new TaskItem {Id = 2, Title = "Learn C#", isCompleted = false}
    };
}