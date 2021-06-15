using System.Collections.Generic;

namespace EnterprisePsychosis
{
    public interface IPayroll : IEnumerable<Employee>
    {
        void AddEmployee(string name, decimal salary);
    }
}
