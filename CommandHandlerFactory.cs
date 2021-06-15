using System;
using System.Collections.Generic;
using System.Linq;

namespace EnterprisePsychosis
{
    partial class Program
    {
        public class CommandHandlerFactory
        {
            public CommandHandler Create(IPayroll payroll, IUI ui)
            {
                var type = typeof(ICommand);

                var types = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(x => x.GetTypes())
                    .Where(x => !x.IsInterface && !x.IsAbstract && type.IsAssignableFrom(x))
                    .ToArray();

                var commands = new List<ICommand>();

                foreach (var t in types)
                {
                    var command = (ICommand)Activator.CreateInstance(t, payroll, ui);

                    commands.Add(command);
                }

                return new CommandHandler(commands);
            }
        }
    }
}