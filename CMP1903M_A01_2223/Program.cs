using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Program
    {
        static void Main(string[] args)
        {
            TestingAuto testA = new TestingAuto();
            testA.TestRun();
            
            TestingCli testC = new TestingCli();
            testC.TestRun();
        }
    }
}
