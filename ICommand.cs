namespace EnterprisePsychosis
{
    public interface ICommand
    {
        public string CommandName { get; }

        public CommandResult Execute(params string[] args);
    }
}