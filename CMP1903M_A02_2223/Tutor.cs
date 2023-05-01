namespace CMP1903M_A02_2223;

class Tutor
{
    private Pack _pack;
    private List<Equation> _equations;
    public Tutor()
    {
        _pack = new Pack();
        _equations = new List<Equation>();
    }
    
    public List<Equation> GetEquations()
    {
        return _equations;
    }

    public string ReadEquation()
    {
        return _equations.Last().ToString();
    }

    public void GenerateEquation(int cards, bool shuffle = true, bool reset = true)
    {
        // Check if valid ammount of Cards
        if (cards < 3 || cards%2 == 0)
        {
            Console.WriteLine("Invalid amount of cards. Try Again");
            return;
        }
        

        // Check if pack needs to be reset or shuffled
        if (reset)
        {
            _pack.ResetCardOrder();
        }
        if (shuffle)
        {
            _pack.Shuffle();
        }
        
        // Deal and Create array of Cards
        Card[] eCards = _pack.DealCards(cards);
        
        // Create Equation
        Equation equation = new Equation(eCards);
        _equations.Add(equation);
    }
    
    public bool CheckUserAnswer(string answer)
    {
        decimal result = _equations.Last().Result;
        string strResult = result.ToString("F2");
        
        _equations.Last().UserAnswer = answer;
        
        // Check if answer is correct
        if (answer == strResult)
        {
            _equations.Last().Score = true;
            return true;
        }
        
        return false;
    }
}