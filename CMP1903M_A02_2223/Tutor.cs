namespace CMP1903M_A02_2223;

public class Tutor
{
    private Pack _pack;
    private List<Equation> _equations;
    public Tutor()
    {
        _pack = new Pack();
        _equations = new List<Equation>();
    }
    
    public void ReadEquations()
    {
        foreach (Equation equation in _equations)
        {
            Console.WriteLine(equation + "= " + equation.Result);
        }
    }
    
    public void GenerateEquation(int cards)
    {
        // Check if valid ammount of Cards
        if (cards < 3 || cards%2 == 0)
        {
            Console.WriteLine("Invalid ammount of cards");
            return;
        }
        
        // Create array of Cards
        Card[] eCards = new Card[cards];
        
        // Deal Cards
        _pack.Shuffle();
        eCards = _pack.DealCards(cards);
        
        // Create Equation
        Equation equation = new Equation(eCards);
        _equations.Add(equation);
    }
}