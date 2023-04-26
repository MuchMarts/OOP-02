namespace CMP1903M_A02_2223;

class Equation: Interfaces.IEquationBuilder
{
    private Card[] _cards;
    // Used for Statistics for the user
    private bool _score;
    private int _speed;

    public decimal Result
    {
        get; 
        private set;
    }
    public override string ToString()
    {
        return FormatEquation(_cards);
    }

    public Equation(Card[] cards)
    {
        _cards = cards;
        _score = false;
        _speed = 0;
        CalculateEquation(_cards);
    }
    
    public void CalculateEquation(Card[] cards)
    {
        Result = EquationBuilder.CalculateEquation(_cards);
    }
   
    public string FormatEquation(Card[] cards)
    {
        return EquationBuilder.FormatEquation(_cards);
    }
    
}