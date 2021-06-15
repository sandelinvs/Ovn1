using System;
using System.Collections.Generic;

namespace EnterprisePsychosis
{
        public class CommandHandler
        {
            private Dictionary<string, ICommand> _commands = new Dictionary<string, ICommand>();

            public event EventHandler<CommandExecutedEventArgs> OnExecute;

            public CommandHandler(IEnumerable<ICommand> commands)
            {
                foreach (var cmd in commands)
                {
                    _commands.Add(cmd.CommandName, cmd);
                }
            }

            public void Execute(string commandLine)
            {
                var commandLineArguments = commandLine.Split(" ");

                var commandName = commandLineArguments[0];

                if (_commands.TryGetValue(commandName, out ICommand cmd))
                {
                    cmd.Execute(commandLineArguments);

                    OnExecute?.Invoke(this, new CommandExecutedEventArgs { Command = cmd });
                }
            }
        
    }
}