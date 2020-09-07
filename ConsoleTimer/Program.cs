using System;
using WorkTimer;

namespace ConsoleTimer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var displayer = new ConsoleNotifier();
            var worker = new Worker(displayer);
            worker.Start();
            Console.ReadKey();
        }
    }
}
