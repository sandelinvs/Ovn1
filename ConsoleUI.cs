using System;

namespace EnterprisePsychosis
{
    public class ConsoleUI : IUI
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}