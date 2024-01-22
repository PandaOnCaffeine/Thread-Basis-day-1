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
        static char _ch = '*';
        static void Main(string[] args)
        {
            RunOpgFour();
            Console.ReadLine();
        }

        static void RunOpgOne()
        {
            Thread threadOne = new Thread(new ThreadStart(PrintTextOne));
            threadOne.Start();

        }
        static void RunOpgTwo()
        {
            Thread threadOne = new Thread(new ThreadStart(PrintTextOne));
            Thread threadTwo = new Thread(new ThreadStart(PrintTextTwo));
            threadTwo.Start();
            threadOne.Start();
        }

        static void RunOpgThree()
        {
            Thread Temperature = new Thread(new ThreadStart(TempGen));
            Temperature.Start();
            bool terminated = false;
            while (!terminated)
            {
                if (!Temperature.IsAlive)
                {
                    Console.WriteLine("Alarm-tråd termineret!");
                    terminated = true;
                }
                Thread.Sleep(10000);
            }
        }

        static void RunOpgFour()
        {
            Thread printer = new Thread(() => Printer());
            Thread reader = new Thread(() => Reader());
            printer.Start();
            reader.Start();
        }

        static void PrintTextOne()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("C#-trådning er nemt!");
                Thread.Sleep(1000);
            }
        }

        static void PrintTextTwo()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Også med flere tråde …");
                Thread.Sleep(1000);
            }
        }

        static void TempGen()
        {
            Random rng = new Random();
            int temperature = 0;
            int alarmCount = 0;
            bool alarmMax = false;
            while (alarmMax == false)
            {
                temperature = rng.Next(-20, 120);
                Console.WriteLine(temperature);
                if (temperature >= 0 && temperature <= 100)
                {
                }
                else
                {
                    Console.WriteLine("Alarm: Uden for lovligt interval");
                    alarmCount++;
                }
                if (alarmCount == 3)
                {
                    alarmMax = true;
                }
                Thread.Sleep(2000);
            }
        }
        static void Printer()
        {
            while (true)
            {
                Console.Write(_ch);
                Thread.Sleep(10);
            }
        }
        static void Reader()
        {
            char tempCh = '*';
            _ch = tempCh;
            while (true)
            {
                //_ch = Console.ReadKey().KeyChar;
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    _ch = tempCh;
                }
                else
                {
                    tempCh = (char)key;
                }
            }
        }
    }
}
