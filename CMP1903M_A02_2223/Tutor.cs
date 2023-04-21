namespace CMP1903M_A02_2223;

public class Tutor
{
    private Pack _pack;
    
    public Tutor()
    {
        _pack = new Pack();
    }

    private void GenerateEquation(int cards)
    {
        // Check if valid ammount of Cards
        if (cards < 3 || cards%2 == 0)
        {
            Console.WriteLine("Invalid ammount of cards");
            return;
        }
    }
}