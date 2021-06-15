using System;
using System.Collections.Generic;
using System.Linq;
using EnterprisePsychosis;


IUI Ui = new ConsoleUI();

IPayroll Payroll = new Payroll();

CommandHandlerFactory factory = new CommandHandlerFactory();

CommandHandler cmdHandler = factory.Create(Payroll);

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

    string[] args = line.Split("");

}

public class CommandHandlerFactory
{
    public CommandHandler Create(IPayroll payroll)
    {
        var type = typeof(ICommand);

        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => !type.IsAbstract && type.IsAssignableFrom(x));

        var commands = new List<ICommand>();

        foreach (var t in types)
        {
            var command = (ICommand)Activator.CreateInstance(type, payroll);

            commands.Add(command);
        }

        return new CommandHandler(commands);
    }
}

public class CommandHandler
{
    private Dictionary<string, ICommand> _commands = new Dictionary<string, ICommand>();

    public event EventHandler<CommandExecutedEventArgs> OnExecute;

    public CommandHandler(IEnumerable<ICommand> commands)
    {
        foreach (var cmd in commands)
        {
            _commands.Add(cmd.CommandName, cmd);
        }
    }

    public void Execute(string commandLine)
    {
        var commandLineArguments = commandLine.Split(" ");

        var commandName = commandLineArguments[0];

        if (_commands.TryGetValue(commandName, out ICommand cmd))
        {
            cmd.Execute(commandLineArguments);

            OnExecute?.Invoke(this, new CommandExecutedEventArgs { Command = cmd });
        }
    }
}

public class CommandExecutedEventArgs : EventArgs
{
    public ICommand Command { get; set; }
}

public interface ICommand
{
    public string CommandName { get; }

    public void Execute(params string[] args);
}

public class AddCommand : ICommand
{
    public string CommandName { get;} = "add";

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

public interface IUI
{
    void WriteLine(string line);

    string ReadLine();
}

public class ConsoleUI : IUI
{
    public void WriteLine(string line)
    {
        Console.WriteLine(line);
    }

    public string ReadLine()
    {
        return Console.ReadLine();
    }
}

