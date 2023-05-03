using System.IO.Pipes;

namespace CMP1903M_A02_2223;

// Testing to make sure methods are working as intended
class Testing 
{
    
    public static void Test()
    {
        TCard();
        TShuffle();
        TPack();
        TStats();
        TEquation();
        TEquationBuilder();
    }
    
    public static void TCard()
    {
        Card testCard = new Card();
        testCard.Suit = 1;
        testCard.Value = 1;
        Console.WriteLine();
        Console.WriteLine("Testing Card.cs");
        Console.WriteLine("Card values set to 1");
        
        if (testCard.Suit == 1) Console.WriteLine("Card.cs Suit Test Passed");
        else Console.WriteLine("Card.cs Suit Test Failed");

        if (testCard.Value == 1) Console.WriteLine("Card.cs Value Test Passed");
        else Console.WriteLine("Card.cs Value Test Failed");
       
        if(testCard.TranslateSuit() == "Heart") Console.WriteLine("Card.cs TranslateSuit Test Passed");
        else Console.WriteLine("Card.cs TranslateSuit Test Failed");
    }
    
    public static void TShuffle()
    {
        Console.WriteLine();
        Console.WriteLine("Testing Shuffles.cs");
        
        Card[] testCards = new Card[2];
        
        for (int i = 0; i < testCards.Length; i++)
        {
            testCards[i] = new Card();
        }
        testCards[0].Suit = 1;
        testCards[0].Value = 1;
        
        testCards[1].Suit = 2;
        testCards[1].Value = 2;

        Shuffles.FisherYatesShuffle(ref testCards);
        
        if (testCards[0].Suit != 1 && testCards[0].Value != 1) Console.WriteLine("Shuffles.cs Test Passed");
        else Console.WriteLine("Shuffles.cs Test Failed");

    }

    public static void TPack()
    {
        Pack testPack = new Pack();
        
        Console.WriteLine();
        Console.WriteLine("Testing Pack.cs");
        
        if (testPack.DealCards(53) is not null) Console.WriteLine("Pack.cs DealCards Invalid Amm Test Passed");
        else Console.WriteLine("Pack.cs DealCards Invalid Amm Test Failed");
        
        if (testPack.DealCards(3).GetType() == typeof(Card[])) Console.WriteLine("Pack.cs DealCards Valid Amm Test Passed");
        else Console.WriteLine("Pack.cs DealCards Valid Amm Test Failed");
        
    }

    public static void TStats()
    {
        Console.WriteLine();
        Console.WriteLine("Testing Statistics.cs");
        Statistics testStats = new Statistics();
        if (testStats.ReadStats() is string) Console.WriteLine("Statistic.cs ReadStats Test Passed");
        else Console.WriteLine("Statistic.cs ReadStats Test Failed");
    }

    public static void TEquation()
    {
        
        Console.WriteLine();
        Console.WriteLine("Testing Equation.cs");
        
        Card[] testCards = new Card[3];
        
        for (int i = 0; i < testCards.Length; i++)
        {
            testCards[i] = new Card();
        }
        // 2 - 2
        testCards[0].Suit = 2;
        testCards[0].Value = 2;
        
        testCards[1].Suit = 2;
        testCards[1].Value = 2;
        
        testCards[2].Suit = 2;
        testCards[2].Value = 2;
     
        Equation testEquation = new Equation(testCards);
        
        if(testEquation.Score == false) Console.WriteLine("Equation.cs Default Score Test Passed");
        else Console.WriteLine("Equation.cs Default Score Test Failed");

        if (testEquation.Speed == 0) Console.WriteLine("Equation.cs Default Speed Test Passed");
        else Console.WriteLine("Equation.cs Default Speed Test Failed");

        if(testEquation.Result == 0) Console.WriteLine("Equation.cs Result Test Passed");
        else Console.WriteLine("Equation.cs Result Test Failed");
        
        if(testEquation.FormatEquation() == "2 - 2 ") Console.WriteLine("Equation.cs FormatEquation Test Passed");
        else Console.WriteLine("Equation.cs FormatEquation Test Failed");
    }

    public static void TEquationBuilder()
    {
        Console.WriteLine();
        Console.WriteLine("Testing EquationBuilder.cs");
        
        int[] testValues1 = {3, 1, 5};
        int[] testValues2 = {3, 1, 5, 1, 3};
        
        int[] testValues3 = {3, 3, 5};
        int[] testValues4 = {3, 3, 5, 4, 3};

        Card[] testCards3 = new Card[3];
        Card[] testCards5 = new Card[5];
        
        for(int i = 0; i < testCards3.Length; i++)
        {
            testCards3[i] = new Card();
        }
        for(int i = 0; i < testCards5.Length; i++)
        {
            testCards5[i] = new Card();
        }
        
        for(int i = 0; i < testCards3.Length; i++)
        {
            testCards3[i].Value = testValues1[i];
            testCards3[i].Suit = testValues1[i] > 4 ? 1 : testValues1[i];
        }
        
        for(int i = 0; i < testCards5.Length; i++)
        {
            testCards5[i].Value = testValues2[i];
            testCards5[i].Suit = testValues2[i] > 4 ? 1 : testValues2[i];
        }

        Console.WriteLine(EquationBuilder.CalculateEquation(testCards3) == 8
            ? "EquationBuilder.cs CalculateEquation (3 cards) Test Passed"
            : "EquationBuilder.cs CalculateEquation (3 cards)  Test Failed");

        Console.WriteLine(EquationBuilder.CalculateEquation(testCards5) == 11
            ? "EquationBuilder.cs CalculateEquation (5 cards) Test Passed"
            : "EquationBuilder.cs CalculateEquation (5 cards)  Test Failed");
        
        Console.WriteLine(EquationBuilder.FormatEquation(testCards3) == "3 + 5 "
            ? "EquationBuilder.cs FormatEquation (3 cards) Test Passed"
            : "EquationBuilder.cs FormatEquation (3 cards)  Test Failed");

        Console.WriteLine(EquationBuilder.FormatEquation(testCards5) == "3 + 5 + 3 "
            ? "EquationBuilder.cs FormatEquation (5 cards) Test Passed"
            : "EquationBuilder.cs FormatEquation (5 cards)  Test Failed");
        
        Console.WriteLine("Additional tests");
        
        for(int i = 0; i < testCards3.Length; i++)
        {
            testCards3[i].Value = testValues3[i];
            testCards3[i].Suit = testValues3[i] > 4 ? 1 : testValues3[i];
        }
        
        for(int i = 0; i < testCards5.Length; i++)
        {
            testCards5[i].Value = testValues4[i];
            testCards5[i].Suit = testValues4[i] > 4 ? 1 : testValues4[i];
        }
        
        Console.WriteLine(EquationBuilder.CalculateEquation(testCards3) == 15
            ? "EquationBuilder.cs CalculateEquation (3 cards) Test Passed"
            : "EquationBuilder.cs CalculateEquation (3 cards)  Test Failed");
        
        // String formating done to deal with floating point errors
        Console.WriteLine(EquationBuilder.CalculateEquation(testCards5).ToString("f2") == "5,00"
            ? "EquationBuilder.cs CalculateEquation (5 cards) Test Passed"
            : "EquationBuilder.cs CalculateEquation (5 cards)  Test Failed");

        Console.WriteLine(EquationBuilder.FormatEquation(testCards3) == "3 * 5 "
            ? "EquationBuilder.cs FormatEquation (3 cards) Test Passed"
            : "EquationBuilder.cs FormatEquation (3 cards)  Test Failed");

        Console.WriteLine(EquationBuilder.FormatEquation(testCards5) == "3 * 5 / 3 "
            ? "EquationBuilder.cs FormatEquation (5 cards) Test Passed"
            : "EquationBuilder.cs FormatEquation (5 cards)  Test Failed");

    }
}