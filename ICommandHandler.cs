using System;

namespace EnterprisePsychosis
{
    public interface ICommandHandler
    {
        event EventHandler<CommandExecutedEventArgs> OnExecute;

        void Execute(string commandLine);
    }
}