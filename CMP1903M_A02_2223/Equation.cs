namespace CMP1903M_A02_2223;

class Equation: Interfaces.IEquationBuilder
{
    private Card[] _cards;
    // Used for Statistics for the user
    public bool Score { get; set; }
    public string UserAnswer { get; set; }
    public long _speed;

    public decimal Result { get; }

    public override string ToString()
    {
        return FormatEquation();
    }

    public Equation(Card[] cards)
    {
        _cards = cards;
        Score = false;
        _speed = 0;
        Result = CalculateEquation();
    }
    
    public decimal CalculateEquation()
    {
        return EquationBuilder.CalculateEquation(_cards);
    }
   
    public string FormatEquation()
    {
        return EquationBuilder.FormatEquation(_cards);
    }
    
}