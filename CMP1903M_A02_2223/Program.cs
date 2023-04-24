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
            tutor.GenerateEquation(11);
            tutor.GenerateEquation(13);
            tutor.GenerateEquation(15);
            tutor.GenerateEquation(17);
            tutor.GenerateEquation(19);
            tutor.GenerateEquation(21);
            tutor.GenerateEquation(23);
            tutor.GenerateEquation(25);
            tutor.GenerateEquation(27);
            tutor.GenerateEquation(29);
            tutor.GenerateEquation(31);
            tutor.GenerateEquation(33);
            tutor.GenerateEquation(35);
            tutor.GenerateEquation(37);
            tutor.GenerateEquation(39);
            tutor.GenerateEquation(41);
            tutor.GenerateEquation(43);
            tutor.GenerateEquation(45);
            tutor.GenerateEquation(47);



            tutor.ReadEquations();
            
            Console.WriteLine("Success");
        }
    }
}
