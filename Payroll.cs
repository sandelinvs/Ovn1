using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovn1
{
    public class Employee
    {
        public string Name { get; private set; }

        public decimal Salary { get; private set; }

        public Employee(string name, decimal salary)
        {
            Name = name;
            Salary = salary;
        }
    }

    public interface IPayroll : IEnumerable<Employee>
    {
        void AddEmployee(string name, decimal salary);
    }

    public class Payroll : IPayroll
    {
        public void AddEmployee(string name, decimal salary)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Employee> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
