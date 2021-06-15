using System.Collections;
using System.Collections.Generic;

namespace EnterprisePsychosis
{

    public class Payroll : IPayroll
    {
        private readonly List<Employee> _employees = new List<Employee>();

        public void AddEmployee(string name, decimal salary)
        {
            var employee = new Employee(name, salary);

            _employees.Add(employee);
        }

        public IEnumerator<Employee> GetEnumerator()
        {
            return _employees.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _employees.GetEnumerator();
        }
    }
}
