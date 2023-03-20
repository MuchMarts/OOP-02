using System.IO.Pipes;

namespace CMP1903M_A01_2223;

// Abstract class implemented to ensure that Testing class contains function TestRun()
public abstract class Testing
{
    public abstract void TestRun();
}

// TestingCli and TestingAuto classes implemented inheriting from abstract Testing class to ensure it has TestRun() method implemented 
public class TestingAuto : Testing
{
    public TestingAuto()
    {
        Console.WriteLine("\nTestingAuto initialized!\n");
    }
    
    public override void TestRun()
    {
        Pack pack = new Pack();
        
        // Check all Shuffling types and if wrong input
        Pack.ShuffleCardPack(1);
        Pack.ShuffleCardPack(2);
        Pack.ShuffleCardPack(3);
        Pack.ShuffleCardPack(4);

        Card card = Pack.Deal();
        Console.WriteLine("Dealt Card:");
        Console.WriteLine(Pack.FormatCardData(card));

        Card[] cards = Pack.DealCard(10);
        Console.WriteLine("Multiple cards Dealt:");
        foreach (var c in cards)
        {
            Console.WriteLine(Pack.FormatCardData(c));
        }
    }
}

public class TestingCli: Testing
{
    public TestingCli()
    {
        Console.WriteLine("\nTestingCLI initialized!");
    }

    
    // Helper methods to write to console card values
    private void DisplayCardData(Card[] cards, int type)
    {
        // type 1 means that Dealt() method is called
        // type Any mean that DealCard() method is called
        Console.WriteLine(type == 1 ? "Single card dealt:" : "Multiple cards dealt:");

        foreach (Card c in cards) 
        {
            // Disable error for IDE
            // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
            if (c == null) break;
            
            Console.WriteLine(Pack.FormatCardData(c));
        }
    }
    
    private void MultipleCards()
    {
        while (true)
        {
            Console.WriteLine("Input a integer 1 to 52 (Amount of card dealt)");
            try
            {
                var amount = Convert.ToInt32(Console.ReadLine());
                var c = Pack.DealCard(amount);
                
                // Handle error
                if (c == null)
                {
                    Console.WriteLine("ErrEncounter");
                    continue;
                }
                
                DisplayCardData(c, 2);
                return;



            }
            catch
            {
                Console.WriteLine("Incorrect value! Try again!");
            }
        }    
    }

    private void SingleCard()
    {
        var c = new Card[1];
        c[0] = Pack.Deal();
        DisplayCardData(c, 1);
    }

    private static void Shuffling()
    {
        while (true)
        {
            Console.WriteLine("Types of Shuffling");
            Console.WriteLine("[1] Fisher Yates shuffle\n" + 
                              "[2] Riffle shuffle\n" +
                              "[3] No shuffle");

            try
            {
                var choice = Convert.ToInt32(Console.ReadLine());
                
                // If chosen type is valid break out of method
                if (Pack.ShuffleCardPack(choice)) return;   
                
                // If chosen type is not valid repeat choice block
                Console.WriteLine("Try Again!");
            }
            catch
            {
                Console.WriteLine("Incorrect input value!");
            }
            
        }
    }
    
    // Test Run used to create/run a simple CLI to interact with Pack class for ease of testing
    public override void TestRun()
    {
        Pack pack = new Pack();
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine(Menu());
            try
            {
                var choice = Convert.ToInt32(Console.ReadLine());
                if (choice is >= 1 and <= 6)
                {
                    switch (choice)
                    {
                        case 1:
                            Pack.ReadPack();
                            break;
                        case 2:
                            Pack.ResetCardOrder();
                            break;
                        case 3:
                            SingleCard();
                            break;
                        case 4:
                            MultipleCards();
                            break;
                        case 5:
                            Shuffling();
                            break;
                        case 6:
                            return;
                    }
                }
                else
                {
                    Console.WriteLine("Entered value is not a valid Choice!");
                }
            }
            catch
            {
                Console.WriteLine("Entered value is not an valid Input! Please enter an integer!");
            }
        } 
    }

    // Returns string with all options
    private static string Menu()
    {
        return ("Testing menu!\n" +
                "[1] Read all cards\n" +
                "[2] Reset card order\n" +
                "[3] Deal one card\n" +
                "[4] Deal multiple cards\n" +
                "[5] Try shuffling\n" +
                "[6] Exit\n");
    }
    
}