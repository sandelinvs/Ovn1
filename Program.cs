using EnterprisePsychosis;

namespace EnterprisePsychosis
{
    class Program
    {
        private static IUI Ui = new ConsoleUI();

        private static IPayroll Payroll = new Payroll();

        private static ICommandHandlerFactory Factory = new CommandHandlerFactory();

        public static void Main(string[] args)
        {
            ICommandHandler cmdHandler = Factory.Create(Payroll);

            cmdHandler.OnExecute += OnExecute;

            Ui.WriteLine("Commands:");
            Ui.WriteLine("add [name] [salary] // add an employee to the payroll");
            Ui.WriteLine("print // prints the payroll to console");
            Ui.WriteLine("exit // exits the application");
            Ui.WriteLine("------------------------------------------------------");

            string line;

            while ((line = Ui.ReadLine()) != "exit")
            {
                if (line == null)
                    continue;

                cmdHandler.Execute(line);
            }
        }

        public static void OnExecute(object sender, CommandExecutedEventArgs e)
        {
            Ui.WriteLine(e.Result.Result);
        }
    }
}