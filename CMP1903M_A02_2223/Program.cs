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
            

            tutor.GenerateEquation(301);
            
            tutor.ReadEquations();
            
            Console.WriteLine("Success");
        }
    }
}
