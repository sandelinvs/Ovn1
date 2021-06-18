using System;
using System.Collections.Generic;

namespace EnterprisePsychosis
{
    public interface ICommandHandler
    {
        IEnumerable<ICommand> Commands { get; }

        event EventHandler<CommandExecutedEventArgs> OnExecute;

        void Execute(string commandLine);
    }
}