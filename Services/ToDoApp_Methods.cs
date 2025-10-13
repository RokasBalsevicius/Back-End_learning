using System;
using System.Collections.Generic;
using ToDoApp.Objects;


namespace ToDoApp.Methods;

public partial class Repository
{
    
    /*Metodas, kuris praso ivesti reiksmes, kurias veliau sudelioja i ToDoList itam objekta*/
    public static TaskItem EnterObject()
    {
        Console.Write("Enter ID: ");
        int newObjectId = int.Parse(Console.ReadLine());
        Console.Write("Enter taskt title: ");
        string newObjectTitle = Console.ReadLine();

        bool newObjectIsCompleted;
        while (true)
        {
            Console.Write("Is it completed? (true -> YES, false -> NO): ");
            string input = Console.ReadLine()?.Trim().ToLower();

            if (input == "true")
            {
                newObjectIsCompleted = true;
                break;
            }
            else if (input == "false")
            {
                newObjectIsCompleted = false;
                break;
            }
            else
            {
                Console.WriteLine("Error. Invalid value entered!");
            }
        }

        TaskItem newEntry = new TaskItem
        {
            Id = newObjectId,
            Title = newObjectTitle,
            isCompleted = newObjectIsCompleted
        };
        return newEntry;
    }

    /*Methods, kuris iraso iskviesto EnterObject() metodo metu sukurta ToDoList item objekta i DEMO duombaze*/
    public static void SaveObjectToDB()
    {
        TaskItem addedItem = EnterObject();
        DataBase.Add(addedItem);
        Console.WriteLine($"Added '{addedItem.Title}' task");
        Console.WriteLine("current task enterred: ");

        foreach (TaskItem t in DataBase)
        {
            Console.WriteLine($"Id: {t.Id}, Title: {t.Title}, IsCompleted: {t.isCompleted}");
        }
    }
}