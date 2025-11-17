using Utilities;
using GRADEBOOK.Repositories;
using GRADEBOOK.Actions;

namespace GradebookApp.Services;

public class GradebookService
{
    private readonly Utility utils = new();
    private readonly GradebookRepository repository = new();
    private readonly GradebookActions actions = new();

    public void StudentGradebook()
    {
        var gradebook = repository.Gradebook;

        while (true)
        {
            Console.WriteLine("Gradebook Menu:");
            Console.WriteLine("1 - Add student");
            Console.WriteLine("2 - Add grade to a student");
            Console.WriteLine("3 - Show average grade per student");
            Console.WriteLine("4 - Show top-performing student");
            Console.WriteLine("5 - Exit");
            Console.WriteLine("<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>");

            int userMenuChoice = utils.ReadNumber<int>("Enter menu option: ");

            switch (userMenuChoice)
            {
                case 1:
                    actions.AddStudent(gradebook);
                    continue;
                case 2:
                    actions.AddGrade(gradebook);
                    continue;
                case 3:
                    actions.ShowAverage(gradebook);
                    continue;
                case 4:
                    actions.ShowTopPerformer(gradebook);
                    continue;
                case 5:
                    Console.WriteLine("Exiting program...Bye!");
                    return;
                default:
                    Console.WriteLine("Invalid menu option selected...");
                    continue;
            }
        }
    }
}
