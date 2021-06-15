using System;

namespace EnterprisePsychosis
{
    partial class Program
    {
        public class AddCommand : ICommand
        {
            public string CommandName { get; } = "add";

            public IPayroll Payroll { get; }
            public IUI Ui { get; }

            public AddCommand(IPayroll payroll, IUI ui)
            {
                Payroll = payroll;
                Ui = ui;
            }

            public void Execute(params string[] args)
            {
                decimal salary;

                if (Decimal.TryParse(args[2], out salary))
                {
                    Payroll.AddEmployee(args[1], salary);
                }
            }
        }
    }
}