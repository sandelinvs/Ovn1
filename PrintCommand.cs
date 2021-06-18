using System;
using System.Linq;

namespace EnterprisePsychosis
{
    public class PrintCommand : ICommand
    {
        public string CommandName => "print";

        public IPayroll Payroll { get; }

        public string Description => @"Displays a list of the employees on the payroll";

        public PrintCommand(IPayroll payroll)
        {
            Payroll = payroll;
        }

        public CommandResult Execute(params string[] args)
        {
            var list = string.Join(Environment.NewLine, Payroll);

            return new CommandResult { Success = true, Result = list };
        }
    }
}