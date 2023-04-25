﻿namespace CMP1903M_A02_2223;

class Equation
{
    private Card[] _cards;
    // Used for Statistics for the user
    private bool _score;
    private int _speed;
    private int[] pemdas = {3, 4, 2, 1};

    public decimal Result
    {
        get; 
        private set;
    }
    public override string ToString()
    {
        return FormatEquation();
    }

    public Equation(Card[] cards)
    {
        _cards = cards;
        _score = false;
        _speed = 0;

        Result = CalculateEquation(CreateEquation(_cards));

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
    private string TranslateIntToType(int c)
    {
        switch (c)
        {
            case 3:
                return "+";
            case 4:
                return "-";
            case 2:
                return "*";
            case 1:
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
            if (i%2 == 0)
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

    private List<decimal> CreateEquation(Card[] cards)
    {
        int len = cards.Length;
        
        // Array to store results of calculations
        List<decimal> values = new List<decimal>(len);
        
        for (int i = 0; i < len; i++)
        {
            if (i % 2 != 0)
            {
                values.Add(pemdas[cards[i].Suit - 1]);
                continue;
            }
            values.Add(cards[i].Value);
        }

        return values;
    }

    // Multiplication, Divison, Addition, Subtraction
    private decimal CalculateEquation(List<decimal> values)
    {
        int len = values.Count;
        
        if (values.Count < 2) return values[0];

        // Amount of calculations to be done
        int steps = (len - 1) / 2;
        
        // Calculate order of operations lower number higher proirity
        List<decimal> order = new List<decimal>();
        for(int i = 0; i < steps; i++)
        {
            order.Add(values[i*2 + 1]);
        }
        // TODO: Translate all - to + and change all relevant numbers to negative.
        // Translate - to a negative number and have just + everywhere
        for (int i = 0; i < len; i++)
        {
            if (i%2 == 1 && TranslateIntToType(Convert.ToInt32(values[i])) == "-")
            {
                values[i+1] *= -1;
                values[i] = pemdas[0]; // Substraction is now addition
            }
        }
        // Calculate the equation in correct order

        int smallest = -1;
        int index = -1;
        for (int j = 0; j < steps; j++)
        {
            if (index == -1)
            { 
                index = j; 
                smallest = (int)order[j]; 
                continue; 
            } 
            if(smallest > order[j]) 
            { 
                smallest = (int)order[j]; 
                index = j; 
            }
            // Optimization
            if(smallest == 1) break;
        }
            
        // Calculate step of the equation
        decimal result = 0;
        switch (smallest)
        {
            case 2: 
                result = values[index*2] * values[index*2 + 2]; 
                break;
            case 1:
                result = values[index*2] / values[index*2 + 2];
                break;
            case 3:
                result = values[index*2] + values[index*2 + 2];
                break;
            case 4:
                result = values[index*2] - values[index*2 + 2];
                break;
            default:
                Console.WriteLine("Equation Calculator Broke!");
                break;
        }
        
        // for debuging
        /*
        for (int i = 0; i < values.Count; i++)
        {
            if (i%2 == 1)
            {
                Console.Write(TranslateIntToType((int)values[i])+ " ");
                continue;
            }
            Console.Write(values[i].ToString("f2") + " ");
        }
        Console.WriteLine();
        for (int i = index*2; i < index*2+3; i++)
        {
            if (i%2 == 1)
            {
                Console.Write(TranslateIntToType((int)values[i])+ " ");
                continue;
            }
            Console.Write(values[i].ToString("f2") + " ");
        }
        Console.WriteLine("= " + result.ToString("f2"));
        */
        
        // Remove used values and replace with result
        values.RemoveRange(index*2, 2);
        values[index*2] = result;
        // Recursion
        return CalculateEquation(values);
    }
}