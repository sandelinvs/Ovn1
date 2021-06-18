using System;

namespace EnterprisePsychosis
{
    public class AddCommand : ICommand
    {
        public string CommandName { get; } = "add";

        public string Description { get; } = @"add [name] [salary] // adds an employee to the payroll";

        public IPayroll Payroll { get; }

        public AddCommand(IPayroll payroll)
        {
            Payroll = payroll;
        }

        public CommandResult Execute(params string[] args)
        {
            decimal salary;

            if (Decimal.TryParse(args[2], out salary))
            {
                Payroll.AddEmployee(args[1], salary);

                return new CommandResult
                {
                    Success = true,
                    Result = $"New employee ({args[1]}) with salary {salary} added succesfully"
                };
            }

            return new CommandResult
            {
                Success = false,
                Result = $"Failed to add new employee ({args[1]}) with salary {args[2]}"
            };
        }
    }
    
}