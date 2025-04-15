using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_for_Information_Managment
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string Phone { get; set; }
        public ICollection<Scanner> Scanners { get; set; }
        public ICollection<Location> Locations { get; set; }
    }
}
