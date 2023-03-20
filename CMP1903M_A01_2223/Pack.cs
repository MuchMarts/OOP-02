using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{

    class Pack
    {
        private static Card[] _pack;
        private static int _nextCard;
        
        public Pack()
        {
            //Initialise the card pack here
            _pack = new Card[52];
            // next_card used to see which card is next in the deck
            _nextCard = 0;
            // Helper function to fill initialized pack object
            FillPack();
        }
        
        private static void FillPack()
        {
            for (int suite = 1; suite <= 4; suite++)
            {
                for (int value = 1; value <= 13; value++)
                {   
                    // creates each card object
                    
                    Card card = new Card();
                    card.Value = value;
                    card.Suit = suite;
                    //  adds each card in ascending order
                    // value goes from 1 to 13 then (suite-1)*value is how many cards have allready been added to the array
                    _pack[value-1 + ((suite - 1) * 13)] = card;
                }
            }   
        }

        // EXTRA METHODS IMPLEMENTED
        // Format card Value and Suite into a single string for ease of reading
        public static string FormatCardData(Card card)
        {
            return "Card Value: " + card.Value + " Suite: " + card.TranslateSuit();
        }
        
        // EXTRA METHOD IMPLEMENTED
        // Read all card data in pack 
        public static void ReadPack()
        {
            foreach (Card card in _pack)
            {
                Console.WriteLine(FormatCardData(card));
            }
        }
        
        // EXTRA METHOD IMPLEMENTED
        // Reset pack to original order
        public static void ResetCardOrder()
        {
            FillPack();
            _nextCard = 0;
        }
        
        // EXTRA METHOD IMPLEMENTED
        // Implements Fisher Yates shuffle O(n)
        // Uses reference to _pack to shuffle the target objects directly
        private static void FisherYatesShuffle(ref Card[] cards)
        {
            Console.WriteLine("Riffle Yates Shuffle");
            
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

        // EXTRA METHOD IMPLEMENTED
        private static void RiffleShuffle(ref Card[] cards)
        {
            Console.WriteLine("Riffle shuffle!");
            
            // Determines which half has the first card in the new order
            // 1: half1 has first card 
            // 2: half2 has first card
            Random rnd = new Random();
            int flipOfACoin = rnd.Next(1);

            // n half of the array size used to do riffle shuffle
            // riffle shuffle divides pack in half
            int n = 26;

            // h1 and h2 used to increment over each halfs cards
            int h1 = 0;
            int h2 = 0;

            // Array holding each half of pack
            Card[] half1 = new Card[n];
            Card[] half2 = new Card[n];

            // Copies correct pack ranges to each half half1 0-25 half2 26-51
            Array.Copy(cards, 0, half1, 0, n);
            Array.Copy(cards, n, half2, 0, n);

            // Iterates over each card position and if its even index then put card from half 2 if odd the from half 1
            for (int i = 1; i <= 52; i++)
            {
                if ((i % 2 == 1 && flipOfACoin == 1) || (i % 2 == 0 && flipOfACoin == 0))
                {
                    cards[i-1] = half1[h1++];
                }
                else
                {
                    cards[i-1] = half2[h2++];
                }
            }

        }

        public static bool ShuffleCardPack(int typeOfShuffle)
        {
            // Shuffles the pack based on the type of shuffle
            // Uses a switch statement to determine which shuffle to use
            // Shuffle implemented as methods
            switch (typeOfShuffle)
            {
                case 1:
                    FisherYatesShuffle(ref _pack);
                    return true;
                case 2:
                    RiffleShuffle(ref _pack);
                    return true;
                case 3:
                    return true;
                default:
                    Console.WriteLine("Incorrect type of shuffle!");
                    return false;
            }
        }
        public static Card Deal()
        {
            // if nextCard is higher than total umber of card [0, 51] then there are no more cards to be dealt from the deck
            if (_nextCard > 51)
            {
                Console.WriteLine("No more cards left!");
                return null;
            }
            
            Card card = _pack[_nextCard++];
            return card;
            
        }

        public static Card[] DealCard(int amount)
        {
            // Check wheter amount doesnt exceed amount of cards in pack
            if (_pack.Length - amount - _nextCard < 0)
            {
                Console.WriteLine("Not enough cards in Pack");
            }
            else
            {
            
                //Deals the number of cards specified by 'amount'
                Card[] cards = new Card[amount];
                for (int i = 0; i < amount; i++)
                {
                    cards[i] = _pack[_nextCard++];
                }

                return cards;    
            }
            return null;
        }
    }
}
