namespace CMP1903M_A02_2223;

class EquationBuilder
{
    private static int[] pemdas = {3, 4, 2, 1};
    private static string[] suitToType = {"+", "-", "*", "/"};
    private static string[] pemdasToType = {"/", "*", "+", "-"};

    public static string FormatEquation(Card[] cards)
    {
        string equation = "";
        for (int i = 0; i < cards.Length; i++)
        {
            if (i%2 == 0)
            {
                equation += $"{cards[i].Value} ";
            }
            else
            {
                equation += $"{suitToType[cards[i].Suit-1]} ";
            }
        }

        return equation;
    }
    
    public static decimal CalculateEquation(Card[] cards)
    {
        List<decimal> values = CreateEquation(cards);
        return CalculateEquation(values);
    }
    
    private static List<decimal> CreateEquation(Card[] cards)
    {
        // Array to store results of calculations
        List<decimal> values = new List<decimal>();
        
        for (int i = 0; i < cards.Length; i++)
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
    private static decimal CalculateEquation(List<decimal> values)
    {
        // If only one value return it (this is the result)        
        if (values.Count < 2) return values[0];

        // Amount of calculations to be done
        int steps = (values.Count - 1) / 2;
                // Translate - to a negative number and have just + everywhere
        for (int i = 0; i < values.Count; i++)
        {
            if (i%2 == 1 && pemdasToType[Convert.ToInt32(values[i])-1] == "-")
            {
                values[i+1] *= -1;
                values[i] = pemdas[0]; // Substraction is now addition
            }
        }
        
        // Calculate order of operations lower number higher proirity
        List<decimal> order = new List<decimal>();
        for(int i = 0; i < steps; i++)
        {
            order.Add(values[i*2 + 1]);
        }
        

        
        // Find next operation
        int smallest = -1;
        int index = -1;
        //int last = -1;
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
            if(smallest == 1) break; //if smallest is division then no need to check for multiplication
            //if (last == (int)order[j]) { smallest = (int)order[j]; break;} //if last is the same as current then can execute last
            //last = (int)order[j];
            
        }
            
        // Calculate step of the equation
        decimal result = 0;
        switch (smallest)
        {
            case 1:
                result = values[index*2] / values[index*2 + 2];
                break; 
            case 2: 
                result = values[index*2] * values[index*2 + 2]; 
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

        bool Debug = false;
        // for debuging
        if (Debug)
        {
            
            for (int i = 0; i < values.Count; i++)
            {
                if (i % 2 == 1)
                {
                    Console.Write(pemdasToType[(int)values[i]-1] + " ");
                    continue;
                }

                Console.Write(values[i].ToString("f2") + " ");
            }
            
            Console.WriteLine();
            for (int i = index * 2; i < index * 2 + 3; i++)
            {
                if (i % 2 == 1)
                {
                    Console.Write(pemdasToType[(int)values[i]-1] + " ");
                    continue;
                }

                Console.Write(values[i].ToString("f2") + " ");
            }

            Console.WriteLine("= " + result.ToString("f2"));
        }
        
        values.RemoveRange(index*2, 2);
        values[index*2] = result;
        
        // Recursion
        return CalculateEquation(values);
    }
}