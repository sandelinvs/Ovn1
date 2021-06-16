using System;

namespace EnterprisePsychosis
{
    public class CommandExecutedEventArgs : EventArgs
    {
        public ICommand Command { get; set; }
    }
}