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

            foreach (var cmd in cmdHandler.Commands)
            {
                Ui.WriteLine($"{cmd.CommandName} : {cmd.Description}");
            }

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