namespace GRADEBOOK.Repositories;

public class GradebookRepository
{
    public Dictionary<string, List<decimal>> Gradebook { get; set; } = new()
    {
        {"ROKAS", new List<decimal>{10, 4, 2, 4, 6}},
        {"Ema", new List<decimal>{10, 9, 10, 7, 8}}
    };
}