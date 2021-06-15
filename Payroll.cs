using System;
using System.Collections;
using System.Collections.Generic;

namespace EnterprisePsychosis
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

        public override string ToString()
        {
            return $"{Name} : {Salary}";
        }
    }

    public interface IPayroll : IEnumerable<Employee>
    {
        void AddEmployee(string name, decimal salary);
    }

    public class EmployeeAddedEventArgs : EventArgs 
    {
        public Employee Employee { get; set; }
    }

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

    public interface IPayrollPrinter
    {
        void Print();
    }
}
