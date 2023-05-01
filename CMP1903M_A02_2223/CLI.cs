namespace CMP1903M_A02_2223;

class CLI
{
    private Tutor tutor;
    private int experiment = 3;
    public CLI()
    { 
        tutor = new Tutor();   
    }
    public void Run()
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

    private int GetInput()
    {
        Console.WriteLine("Enter a number: ");
        int input;
        while (!int.TryParse(Console.ReadLine(), out input))
        {
            Console.WriteLine("Invalid Input. Try Again");
        }
        return input;
    }
    
    private bool[] EquationSettings()
    {
        Console.WriteLine("Default Settings? (Y/N)");
        bool def = Console.ReadLine().ToLower() == "y";
        if (def) { return new []{true, true}; }
        
        Console.WriteLine("Would you like to shuffle the cards? (Y/N)");
        bool shuffle = Console.ReadLine().ToLower() == "y";
        Console.WriteLine("Would you like to reset the cards? (Y/N)");
        bool reset = Console.ReadLine().ToLower() == "y";
        
        return new []{shuffle, reset};
    }

    private bool GameMenu()
    {
        Console.WriteLine("Do you want to play again?");
        Console.WriteLine("[0] Exit to Main Menu");
        Console.WriteLine("[1] Play Again");
        while (true)
        {
            int input = GetInput();
            switch (input)
            {
                case 0:
                    return false;
                case 1:
                    return true;
                default:
                    Console.WriteLine("Input not recognised. Try Again!");
                    break;
            }
        }
    }
    
    private void StartGame(int cards, bool isExperiment = false)
    {
        bool[] settings = EquationSettings();
        // Flag used to determine if loop should continue
        bool continueLoop = true;
        // Flag used to determine second iteration of loop
        bool flag = false;
        
        // Loop to play game
        while (continueLoop)
        {
            // Check if experimental difficulty and if second iteration
            if (isExperiment && flag)
            {
                experiment += 2;
                cards = experiment;
            }
            flag = true;
            tutor.GenerateEquation(cards, settings[0], settings[1]);
        
            Console.Clear();
        
            Console.WriteLine("Equation: " + tutor.ReadEquation());
            Console.WriteLine("Enter your answer (separate decimal using , ): ");
            decimal answer;
            
            // Check if input is valid
            while (!decimal.TryParse(Console.ReadLine(), out answer))
            {
                Console.WriteLine("Invalid Input. Try Again");
            }
            
            // Check if answer is correct
            bool correct = tutor.CheckUserAnswer(answer.ToString("f2"));
            Console.WriteLine("Your answer was " + (correct ? "correct" : "incorrect"));

            Console.WriteLine();
            
            // Check if user wants to play again
            continueLoop = GameMenu();
        }

    }
    
    private string[] Options()
    {
        string[] options =
        {
            "[0] Exit",
            "[1] Normal Difficulty (3)",    
            "[2] Hard Difficulty (5)", 
            "[3] Experimental Difficulty (Increasing Difficulty = " + experiment + ")",
            "[4] Read Equation History",
            "[5] See Statistics",
            "[6] Reset Experiment Difficulty"
        };
        return options;
    }

    private void CurrentHistory()
    {
        List<Equation> history = tutor.GetEquations();
        foreach (var equation in history)
        {
            Console.WriteLine("---------");
            Console.WriteLine(equation + " = " + equation.CalculateEquation().ToString("F2"));
            Console.WriteLine("User Answer: "+ equation.UserAnswer + " Score: " + (equation.Score ? "Correct" : "Incorrect"));
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
    
    private void Menu()
    {
        Console.Clear();
        foreach (var opt in Options())
        {
            Console.WriteLine(opt);
        }

        switch (GetInput())
        {
            case 0:
                Exit();
                return;
            case 1:
                Console.Clear();
                Console.WriteLine("Normal Difficulty");
                StartGame(3);
                break;
            case 2:
                Console.Clear();
                Console.WriteLine("Hard Difficulty");
                StartGame(5);
                break;
            case 3:
                Console.Clear();
                Console.WriteLine("Experimental Difficulty");
                StartGame(experiment, true);
                break;
            case 4:
                Console.WriteLine("Read Equation History");
                CurrentHistory();
                break;
            case 5:
                Console.WriteLine("See Statistics");
                throw new NotImplementedException();
                break;
            case 6:
                Console.Clear();
                Console.WriteLine("Resetting Experiment Difficulty");
                experiment = 3;
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                break;
        }
        
        Menu();
    }
    
    private string[] ExitMessage()
    {
        string[] message =
        {
            "Thank you for playing Math Tutor!",
            "You can find me on Github with the name MuchMarts",
            "------------------------------------------",
            "Press any key to exit..."
        };
        return message;
    }
    
    private void Exit()
    {
        foreach (var line in ExitMessage())
        {
            Console.WriteLine(line);
        }
        Console.ReadKey();
    }
    
}