namespace CMP1903M_A02_2223;

class Equation
{
    private Card[] _cards;
    // Used for Statistics for the user
    private bool _score;
    private int _speed;
    private int[] pemdas = {3, 4, 1, 2};
    public Equation(Card[] cards)
    {
        _cards = cards;
        _score = false;
        _speed = 0;
    }

    private string TranslateSuitToType(Card c)
    {
        switch (c.Suit)
        {
            case 1:
                return "+";
            case 2:
                return "-";
            case 3:
                return "*";
            case 4:
                return "/";
            default:
                return "Error";
        }
    }

    private string FormatEquation()
    {
        string equation = "";
        for (int i = 0; i < _cards.Length; i++)
        {
            if (i%2 != 0)
            {
                equation += $"{_cards[i].Value} ";
            }
            else
            {
                equation += $"{TranslateSuitToType(_cards[i])} ";
            }
        }

        return equation;
    }


    private List<int> CreateEquation(Card[] cards)
    {
        int len = _cards.Length;
        
        // Array to store results of calculations
        List<int> values = new List<int>(len);
        
        for (int i = 0; i < len; i++)
        {
            if (i % 2 == 0)
            {
                values.Add(pemdas[_cards[i].Suit - 1]);
            }
            values.Add(_cards[i].Value);
        }

        return values;
    }

    // Multiplication, Divison, Addition, Subtraction
    private int CalculateEquation(List<int> values)
    {
        int len = values.Count;
        if (len == 1) return values[0];
        
        // Amount of calculations to be done
        int steps = (len - 1) / 2;
        
        
        // Calculate order of operations lower number higher proirity
        List<int> order = new List<int>();
        for(int i = 0; i < steps; i++)
        {
            order.Add(values[i*2 + 1]);
        }
        
        // Calculate the equation in correct order
        
        int smallest = -1;
        int index = -1;
        for (int j = 0; j < steps; j++)
        {
            if (index == -1)
            { 
                index = j; 
                smallest = order[j]; 
                continue; 
            } 
            if(smallest > order[j]) 
            { 
                smallest = order[j]; 
                index = j; 
            }
        }
            
        // Calculate step of the equation
        int result = 0;
            
        switch (smallest)
        {

            case 1: 
                result = values[index*2] * values[index*2 + 2]; 
                break;
            case 2:
                result = values[index*2] / values[index*2 + 2];
                break;
            case 3:
                result = values[index*2] + values[index*2 + 2];
                break;
            case 4:
                result = values[index*2] - values[index*2 + 2];
                break;
            default:
                Console.WriteLine("Something Brok!");
                break;
        }
            
        // Remove used values and replace with result
        values.RemoveAt(index*2);
        values.RemoveAt(index*2);
        values.Insert(index*2, result);
        
        // Recursion
        return CalculateEquation(values);
    }
}