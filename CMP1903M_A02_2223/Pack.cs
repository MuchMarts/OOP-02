using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CMP1903M_A02_2223
{

    class Pack : Interfaces.IShuffle
    {
        private static Card[] _pack;
        private static int _nextCard;
        private static int maxValue = 13;
        private static int maxSuit = 4;
        public Pack()
        {
            //Initialise the card pack here
            _pack = new Card[maxSuit * maxValue];
            // next_card used to see which card is next in the deck
            _nextCard = 0;
            // Helper function to fill initialized pack object
            FillPack();
        }
        
        private void FillPack()
        {
            for (int suite = 1; suite <= maxSuit; suite++)
            {
                for (int value = 1; value <= maxValue; value++)
                {   
                    // creates each card object
                    
                    Card card = new Card();
                    card.Value = value;
                    card.Suit = suite;
                    //  adds each card in ascending order
                    // value goes from 1 to 13 then (suite-1)*value is how many cards have allready been added to the array
                    _pack[value-1 + ((suite - 1) * maxValue)] = card;
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
        
        public void Shuffle()
        {
            Shuffles.FisherYatesShuffle(ref _pack);
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
