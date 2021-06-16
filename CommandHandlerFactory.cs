using System;
using System.Collections.Generic;
using System.Linq;

namespace EnterprisePsychosis
{

    public class CommandHandlerFactory : ICommandHandlerFactory
    {
        public ICommandHandler Create(IPayroll payroll)
        {
            var type = typeof(ICommand);

            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => !x.IsInterface && !x.IsAbstract && type.IsAssignableFrom(x))
                .ToArray();

            var commands = new List<ICommand>();

            foreach (var t in types)
            {
                var command = (ICommand)Activator.CreateInstance(t, payroll);

                commands.Add(command);
            }

            return new CommandHandler(commands);
        }
    }

}