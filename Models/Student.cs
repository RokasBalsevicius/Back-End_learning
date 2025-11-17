namespace GRADEBOOK.Models;

public class Student
{
    public string Name { get; set; }
    public List<decimal> Grades { get; set; } = new();
}