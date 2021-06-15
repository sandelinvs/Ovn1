using System;

namespace EnterprisePsychosis
{
    public class EmployeeAddedEventArgs : EventArgs 
    {
        public Employee Employee { get; set; }
    }
}
