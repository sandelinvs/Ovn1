namespace EnterprisePsychosis
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler Create(IPayroll payroll);
    }

}