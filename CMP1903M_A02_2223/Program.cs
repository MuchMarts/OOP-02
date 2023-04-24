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
            // Create Tutor object
            Tutor tutor = new Tutor();
            
            tutor.GenerateEquation(3);
            tutor.GenerateEquation(5);
            tutor.GenerateEquation(7);
            tutor.GenerateEquation(9);
            
            tutor.ReadEquations();
            
            Console.WriteLine("Success");
        }
    }
}
