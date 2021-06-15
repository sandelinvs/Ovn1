using System;

namespace EnterprisePsychosis
{
    partial class Program 
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