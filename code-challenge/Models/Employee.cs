using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Models
{
    public class Employee
    {
        public String EmployeeId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Position { get; set; }
        public String Department { get; set; }
        //private List<Employee> directReports = new List<Employee>();
        public List<Employee> DirectReports { get; set; }

        //public Employee() {
        //}

        //public Employee(String employeeId) {
        //    this.EmployeeId = employeeId;
        //}

        //public Employee(String employeeId, string FirstName, string LastName, string Position, string Department, List<Employee> DirectReports )
        //{
        //    this.EmployeeId = employeeId;
        //    this.FirstName = FirstName;
        //    this.LastName = LastName;
        //    this.Position = Position;
        //    this.Department = Department;
        //    this.DirectReports = DirectReports;
        //}
    }
}
