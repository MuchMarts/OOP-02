﻿namespace CMP1903M_A02_2223;

class Equation: EquationBuilder
{
    private Card[] _cards;
    // Used for Statistics for the user
    public bool Score { get; set; }
    public string UserAnswer { get; set; }
    public long Speed { get; set; }

    public decimal Result { get; }

    public override string ToString()
    {
        return FormatEquation();
    }

    public Equation(Card[] cards)
    {
        _cards = cards;
        Score = false;
        Speed = 0;
        Result = CalculateEquation();
    }
    
    public decimal CalculateEquation()
    {
        return CalculateEquation(_cards);
    }
   
    public string FormatEquation()
    {
        return FormatEquation(_cards);
    }
    
}