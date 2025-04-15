using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_for_Information_Managment
{
    public class Location
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
        public int? ResponsibleId { get; set; }
        public Employee Responsible { get; set; }
        public ICollection<Scanner> Scanners { get; set; }
    }
}
