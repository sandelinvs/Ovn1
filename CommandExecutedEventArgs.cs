using System;

namespace EnterprisePsychosis
{
    partial class Program
    {
        public class CommandExecutedEventArgs : EventArgs
        {
            public ICommand Command { get; set; }
        }
    }
}