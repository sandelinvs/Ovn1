using System;
using System.Linq;

namespace EnterprisePsychosis
{
    public class PrintCommand : ICommand
    {
        public string CommandName { get; } = "print";

        public IPayroll Payroll { get; }

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