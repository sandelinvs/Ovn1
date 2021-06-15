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
        event EventHandler<EmployeeAddedEventArgs> OnAdd;

        void AddEmployee(string name, decimal salary);
    }

    public class EmployeeAddedEventArgs : EventArgs 
    {
        public Employee Employee { get; set; }
    }

    public class Payroll : IPayroll
    {
        private readonly List<Employee> _employees = new List<Employee>();

        public event EventHandler<EmployeeAddedEventArgs> OnAdd;

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

    public class ConsolePrinter : IPayrollPrinter
    {
        public ConsolePrinter(IPayroll payroll)
        {
            foreach (var employee in payroll)
            {
                Console.WriteLine(employee);
            }
        }

        public void Print()
        {
            throw new System.NotImplementedException();
        }
    }
}
