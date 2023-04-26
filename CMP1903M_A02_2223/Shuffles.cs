namespace CMP1903M_A02_2223;

class Shuffles
{
    public static void FisherYatesShuffle(ref Card[] cards)
    {
        int n = cards.Length;
            
        Random rnd = new Random();
        Card[] arr = new Card[n];
            
        for (int i = 0; i < n; i++)
        {
            int j = rnd.Next(i);
            if (j != i) arr[i] = arr[j];
            arr[j] = cards[i];
        }
        
        cards = arr;
    }
}