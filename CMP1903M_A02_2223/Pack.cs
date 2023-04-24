using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CMP1903M_A02_2223
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
        
        private void FillPack()
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

        // Format card Value and Suite into a single string for ease of reading
        public string FormatCardData(Card card)
        {
            return "Card Value: " + card.Value + " Suite: " + card.TranslateSuit();
        }
        
        // Read all card data in pack 
        public void ReadPack()
        {
            foreach (Card card in _pack)
            {
                Console.WriteLine(FormatCardData(card));
            }
        }
        
        // Reset pack to original order
        public void ResetCardOrder()
        {
            FillPack();
            _nextCard = 0;
        }
        
        // Implements Fisher Yates shuffle O(n)
        // Uses reference to _pack to shuffle the target objects directly
        private void FisherYatesShuffle(ref Card[] cards)
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
        

        public void Shuffle()
        {
            FisherYatesShuffle(ref _pack);
        }
        
        // TODO: Might be useless in the end program
        public Card Deal()
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

        public Card[] DealCards(int amount)
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
