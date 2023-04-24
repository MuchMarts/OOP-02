using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A02_2223
{
    class Program
    {
        static void Main(string[] args)
        {
            Card[] cards = new Card[] { };
            Card c = new Card();
            c.Value = 2;
            c.Suit = 1;
            Card c1 = new Card();
            c1.Value = 1;
            c1.Suit = 4;
            Card c2 = new Card();
            c2.Value = 2;
            c2.Suit = 1;
            Card c3 = new Card();
            c3.Value = 2;
            c3.Suit = 4;
            Card c4 = new Card();
            c4.Value = 2;
            c4.Suit = 1;
            Equation test = new Equation(new Card[] { c, c1, c2, c3, c4 });
            test.DisplayEquation();
            Console.WriteLine("Success");
            return;
        }
    }
}
