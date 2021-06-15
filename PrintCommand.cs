namespace EnterprisePsychosis
{

    public class PrintCommand : ICommand
    {
        public string CommandName { get; } = "print";

        public IPayroll Payroll { get; }
        public IUI Ui { get; }

        public PrintCommand(IPayroll payroll, IUI ui)
        {
            Payroll = payroll;
            Ui = ui;
        }

        public void Execute(params string[] args)
        {
            foreach (var employee in Payroll)
            {
                Ui.WriteLine(employee.ToString());
            }
        }
        
    }
}