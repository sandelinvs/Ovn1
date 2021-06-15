using EnterprisePsychosis;

namespace EnterprisePsychosis
{
    partial class Program
    {
        static IUI Ui = new ConsoleUI();

        static IPayroll Payroll = new Payroll();

        static CommandHandlerFactory factory = new CommandHandlerFactory();

        public static void Main(string[] args)
        {
            CommandHandler cmdHandler = factory.Create(Payroll);
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

            static void OnExecute(object sender, CommandExecutedEventArgs e)
            {
                Ui.WriteLine($"{e.Command.CommandName} probably executed succesfully");
            }
        }
    }
}