using System;
using System.Collections.Generic;
using ToDoApp.Objects;
using System.Linq;

namespace ToDoManager;


public class ToDoManagerClass
{

    private List<ToDoTaskItem> DataBase = new List<ToDoTaskItem>
    {
        new ToDoTaskItem {Id = 1, Name = "Clean house", Status = "New", CreatedAt = DateTime.Now.AddDays(-10), DueDate = new DateTime(2025, 11, 01)},
        new ToDoTaskItem {Id = 2, Name = "Groceries", Status = "In progress", CreatedAt = DateTime.Now.AddDays(-4), DueDate = new DateTime(2025, 10, 29)},
        new ToDoTaskItem {Id = 3, Name = "Wash dishes", Status = "Completed", CreatedAt = DateTime.Now.AddDays(-3), DueDate = new DateTime(2025, 10, 20)}
    };

    // Below will be all logic for available menu options in TriggerToDoListManager()
    // Show all tasks logic
    public void ShowToDoList() {
        Console.WriteLine("Below are all tasks in To-Do list:");
        Console.WriteLine("---------->");
        foreach (ToDoTaskItem item in DataBase) {
            Console.WriteLine($"Task Id: {item.Id}, Name: {item.Name}, Status: {item.Status}, Created at: {item.CreatedAt:yyyy-MM-dd}, Due date: {item.DueDate:yyyy-MM-dd}");
        }
        Console.WriteLine("----------------------------------");
    }

    // Add task logic
    public void AddTask(){
        int newTaskId = DataBase.Any() ? DataBase.Max(task => task.Id) + 1 : 1;
        
        Console.WriteLine("Enter task name: ");
        string? newTaskName = Console.ReadLine()?.Trim();

        string newTaskStatus = "";
        while(true){
            Console.WriteLine("Enter task status ( New / In progress / Completed)");
            newTaskStatus = Console.ReadLine()?.Trim() ?? "";
            string statusUpper = newTaskStatus.ToUpper().Trim();

            if(statusUpper != "NEW" && statusUpper != "IN PROGRESS" && statusUpper != "COMPLETED") {
                Console.WriteLine($"Invalid status intered - {newTaskStatus}");
                Console.WriteLine("---------------");
                continue;
            }
            break;
        }

        int year = 0, month = 0, day = 0;
        DateTime dueDate;

        while(true) {
            Console.WriteLine("Enter due year (i.g., 2025): ");
            if(int.TryParse(Console.ReadLine(), out year) && year >= DateTime.Now.Year) {            
                break;
            }
            Console.WriteLine("Entered due date year must be valid and not in past");
        }

        while(true) {
            Console.WriteLine("Enter due month (1-12): ");
            if(int.TryParse(Console.ReadLine(), out month) && month >= 1 && month <= 12) {
                if(year == DateTime.Now.Year && month < DateTime.Now.Month) {
                    Console.WriteLine($"Entered year {year}, therefore, entered month {month} cannot be less than current month {DateTime.Now.Month}");
                    continue;
                }
                break;
            }
            Console.WriteLine("Entered month must be between 1 and 12");
        }

        while(true) {
            Console.WriteLine("Enter due day: ");
            if(!int.TryParse(Console.ReadLine(), out day)){
                Console.WriteLine("Entered day must be a number");
                continue;
            }

            if(!DateTime.TryParse($"{year}-{month:D2}-{day:D2}", out dueDate)){
                Console.WriteLine("Entered date is not valid. Please try again");
                continue;
            }

            if(dueDate.Date < DateTime.Now.Date) {
                Console.WriteLine($"Entered date cannot be in the past! Entered year and month is {year}-{month:D2}, therefore, entered day {day} cannot be less than current day {DateTime.Now.Day}");
                continue;
            }
            break;

        }
        ToDoTaskItem newTask = new ToDoTaskItem 
        {
            Id = newTaskId,
            Name = newTaskName ?? "Untitled",
            Status = newTaskStatus,
            CreatedAt = DateTime.Now,
            DueDate = dueDate
        };

        DataBase.Add(newTask);
        Console.WriteLine($"Added new task - {newTask.Name}");
    }

    // Remove task logic
    public void RemoveTask() {
        while(true){
            Console.WriteLine("Select the key by which task should be deleted (id / name / exit - exit to main menu)");
            string? deletionKey = Console.ReadLine()?.Trim().ToUpper();
            if(deletionKey != "ID" && deletionKey != "NAME" && deletionKey != "EXIT" || string.IsNullOrEmpty(deletionKey)){
                Console.WriteLine($"Invalid key selected {deletionKey}");
                continue;
            }
        
        switch (deletionKey) {
            case "ID":
                while(true){
                    Console.WriteLine("Enter ID of the task you wish to delete (or type 'back' to go back): ");
                    string? idInput = Console.ReadLine()?.Trim();

                    if(idInput?.ToUpper() == "BACK" || string.IsNullOrEmpty(idInput)){
                        break;
                    }

                    if(!int.TryParse(idInput, out int itemToDeleteId)){
                        Console.WriteLine("Invalid ID entered. ID must be a number");
                        continue;
                    }
                    int taskToRemoveIndex = DataBase.FindIndex(task => task.Id == itemToDeleteId);
                    if(taskToRemoveIndex == -1) {
                        Console.WriteLine($"No task with entered ID {itemToDeleteId} found");
                        continue;
                    }
                    ToDoTaskItem removedItem = DataBase[taskToRemoveIndex];

                    DataBase.RemoveAt(taskToRemoveIndex);
                    Console.WriteLine($"Removed task Id {removedItem.Id} - {removedItem.Name}");
                    ShowToDoList();
                    break;
                }
                continue;
            case "NAME":
                while(true){
                    Console.WriteLine("Enter name of the task you wish to delete (or type 'back' to go back): ");
                    string? nameInput = Console.ReadLine()?.Trim();

                    if(string.IsNullOrEmpty(nameInput) || nameInput?.ToUpper() == "BACK"){
                        break;
                    }

                    int taskToRemoveIndex = DataBase.FindIndex(task => task.Name == nameInput);
                    if(taskToRemoveIndex == -1) {
                        Console.WriteLine($"No task with entered name {nameInput} found");
                        continue;
                    }
                    ToDoTaskItem removedItem = DataBase[taskToRemoveIndex];
                    DataBase.RemoveAt(taskToRemoveIndex);
                    Console.WriteLine($"Removed task id {removedItem.Id} - {removedItem.Name}");
                    ShowToDoList();
                    break;
                }
                continue;
            case "EXIT":
                Console.WriteLine("Exiting to main menu...");
                return;
            default:
                Console.WriteLine($"Invalid key {deletionKey.Trim().ToUpper()}");
                break;
            }
        }
    }
}