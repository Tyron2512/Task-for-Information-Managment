using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_for_Information_Managment
{
    public class Scanner
    {
        public int Id { get; set; }
        public string InventoryNumber { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public DateTime DateRegistered { get; set; }
        public DateTime? DateInUse { get; set; }
        public int? AmortizationTerm { get; set; }
        public string Condition { get; set; }
        public int? LocationId { get; set; }
        public int? EmployeeId { get; set; }
    }
}
