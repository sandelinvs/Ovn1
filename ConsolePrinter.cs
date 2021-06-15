using System;

namespace EnterprisePsychosis
{
    public class ConsolePrinter : IPayrollPrinter
    {
        public ConsolePrinter(IPayroll payroll)
        {
            foreach (var employee in payroll)
            {
                Console.WriteLine(employee);
            }
        }

        public void Print()
        {
            throw new System.NotImplementedException();
        }
    }
}
