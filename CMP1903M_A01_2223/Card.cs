using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Card
    {
        //Base for the Card class.
        //Value: numbers 1 - 13
        //Suit: numbers 1 - 4
        //The 'set' methods for these properties could have some validation
        
        // During object creation if set isnt called correctly object is left with a null value and/or suite
        private int _suit;
        private int _value;

        // Aditional Method
        // Used to display card suit as a name instead of number for ease of use
        public string TranslateSuit()
        {
            switch (_suit)
            {
                case 1:
                    return "Heart";
                case 2:
                    return "Diamond";
                case 3:
                    return "Clubs";
                case 4:
                    return "Spades";
                default:
                    Console.WriteLine("Error when translating Suit");
                    return null;
            }
        }

        public int Value
        {
            // Get Card value
            get => _value;
            // Check if card value is [1; 13] if not write to console that err occured
            set
            {
                if (value is >= 1 and <= 13) _value = value;
                else Console.WriteLine("Error with Card Value");
            }
        }

        public int Suit
        {
            // Get Suit value
            get => _suit;
            // Check if Suit value is [1; 4] if not write to console that err occured
            set            
            {
                if (value is >= 1 and <= 4) _suit = value;
                else Console.WriteLine("Error with Card Suit");
            }

        }
    }
}
