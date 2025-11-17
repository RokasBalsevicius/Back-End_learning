using Utilities;

namespace GRADEBOOK.Actions;

public class GradebookActions
{
    private readonly Utility utils = new();

    public void AddStudent(Dictionary<string, List<decimal>> gradebook)
    {
        while (true)
        {
            Console.WriteLine("Adding a new student. Please enter student's name: ");
            string? newStudentName = Console.ReadLine()?.Trim().ToUpper();
            if (string.IsNullOrWhiteSpace(newStudentName))
            {
                Console.WriteLine("Student name cannot be null. Please enter a valid student name");
                continue;
            }
            if (!gradebook.ContainsKey(newStudentName))
            {
                gradebook[newStudentName] = new List<decimal> { };
                Console.WriteLine($"Added student: {newStudentName}");
                break;
            }
            else
            {
                Console.WriteLine($"Student name '{newStudentName}' already exists!");
                continue;
            }
        }
    }

    public void AddGrade(Dictionary<string, List<decimal>> gradebook)
    {
        while (true)
        {
            Console.WriteLine("Enter student name to add a grade: ");
            string? studentName = Console.ReadLine()?.Trim().ToUpper();
            if (!gradebook.ContainsKey(studentName) || string.IsNullOrWhiteSpace(studentName))
            {
                Console.WriteLine($"No student with entered name '{studentName}' exists or entered value is null");
                continue;
            }
            decimal grade;
            while (true)
            {
                Console.WriteLine("Enter the grade you want to add or 'Exit' to return to main menu");
                string? input = Console.ReadLine()?.Trim().ToUpper();
                if (input == "EXIT")
                {
                    Console.WriteLine("Exiting to main menu....");
                    Console.WriteLine("-------------------");
                    break;
                }
                if (!decimal.TryParse(input, out grade) || grade < 1 || grade > 10)
                {
                    Console.WriteLine("Invalid number entered. Please enter grade between 1.0 and 10.0");
                    continue;
                }
                else
                {
                    List<decimal> grades = gradebook[studentName];
                    grades.Add(Math.Round(grade, 1));
                    Console.WriteLine($"Grade '{Math.Round(grade, 1)}' added succesfully. ");
                    Console.WriteLine($"Current grades of student '{studentName}' are: " + string.Join(", ", grades));
                    continue;
                }
            }
            break;
        }
    }

    public void ShowAverage(Dictionary<string, List<decimal>> gradebook)
    {
        while (true)
        {
            Console.WriteLine("Currently existing names in gradebook: " + string.Join(", ", gradebook.Keys));
            Console.WriteLine("Enter student name you want to check average grade: ");
            string? name = Console.ReadLine()?.Trim().ToUpper();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Student name cannot be null. Please enter a valid student name");
                continue;
            }
            if (!gradebook.ContainsKey(name))
            {
                Console.WriteLine($"Student with name '{name}' does not exist. Please enter another name for the below list");
                continue;
            }
            List<decimal> grades = gradebook[name];
            Console.WriteLine($"Average grade for student '{name}' is {Math.Round(grades.Average(), 1)}");
            break;
        }
    }

    public void ShowTopPerformer(Dictionary<string, List<decimal>> gradebook)
    {
        string? topPerformer = null;
        decimal averageGrade = 0;

        foreach (var student in gradebook)
        {
            decimal oneStudentGrade = student.Value.Average();
            if (averageGrade < oneStudentGrade)
            {
                averageGrade = Math.Round(oneStudentGrade, 1);
                topPerformer = student.Key;
            }
        }
        Console.WriteLine($"Top performer is student '{topPerformer}' with the average grade '{averageGrade}'.");
    }
}
