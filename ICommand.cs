namespace EnterprisePsychosis
{
    public interface ICommand
    {
        public string CommandName { get; }

        public void Execute(params string[] args);
    }
}