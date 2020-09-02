using System;
using System.Collections.Generic;
using System.Text;
using WorkTimer;

namespace ConsoleTimer
{
    public class ConsoleNotifier : INotifier
    {
        public void Notify(string s)
        {
            Console.WriteLine(s);
        }
    }
}
