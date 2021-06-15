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
}
