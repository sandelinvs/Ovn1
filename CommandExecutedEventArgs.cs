using System;

namespace EnterprisePsychosis
{
    public class CommandExecutedEventArgs : EventArgs
    {
        public ICommand Command { get; set; }

        public CommandResult Result { get; set; }
    }

    public class CommandResult
    {
        public bool Success { get; set; }

        public string Result { get; set; }
    }
}