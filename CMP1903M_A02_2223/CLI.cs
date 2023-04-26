namespace CMP1903M_A02_2223;

class CLI
{
    public CLI()
    {
        //Tutor tutor = new Tutor();
        Intro();
        Menu();
    }

    private string[] IntroMessage()
    {
        string[] message =
        {
            "Welcome to the Maths Tutor",
            "In this game you will learn math by doing!",
            "------------------------------------------",
            "You will be given a set of cards that create an equation.",
            "You will then be asked to calculate the answer.",
            "If you get it right you will get points",
            "At the ned you will be able to see your score!",
            "Made by: Martins Patjanko",
            "------------------------------------------"
        };
        return message;
    }
    private void Intro()
    {
        foreach (var line in IntroMessage())
        {
            Console.WriteLine(line);
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }
    
    private string[] Options()
    {
        string[] options =
        {
            "[0] Exit",
            "[1] Normal Difficulty (3)",    
            "[2] Hard Difficulty (5)", 
            "[3] Experimental Difficulty (Increasing)",
            "[4] Read Equation History",
            "[5] See Statistics",
        };
        return options;
    }
    private void Menu()
    {
        foreach (var opt in Options())
        {
            Console.WriteLine(opt);
        }
    }
    
}