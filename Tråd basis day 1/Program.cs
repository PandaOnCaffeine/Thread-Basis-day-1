using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tråd_basis_day_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread threadOne = new Thread(new ThreadStart(printTextOne));
            Thread threadTwo = new Thread(new ThreadStart(printTextTwo));


            threadOne.Start();
            threadTwo.Start();

            Console.ReadLine();
        }

        static void printTextOne()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("C#-trådning er nemt!");
                Thread.Sleep(1000);
            }
        }

        static void printTextTwo()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Også med flere tråde …");
                Thread.Sleep(1000);
            }
        }
    }
}
