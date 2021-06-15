using System;
using System.Collections.Generic;
using System.Linq;

namespace EnterprisePsychosis
{
    partial class Program
    {
        public class CommandHandlerFactory
        {
            public CommandHandler Create(IPayroll payroll)
            {
                var type = typeof(ICommand);

                var types = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(x => x.GetTypes())
                    .Where(x => !type.IsAbstract && type.IsAssignableFrom(x));

                var commands = new List<ICommand>();

                foreach (var t in types)
                {
                    var command = (ICommand)Activator.CreateInstance(type, payroll);

                    commands.Add(command);
                }

                return new CommandHandler(commands);
            }
        }
    }
}