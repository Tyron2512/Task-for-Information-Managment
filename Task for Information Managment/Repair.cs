using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_for_Information_Managment
{
    public class Repair
    {
        public int Id { get; set; }
        public int ScannerId { get; set; }
        public DateTime RepairDate { get; set; }
        public string IssueDescription { get; set; }
        public string RepairStatus { get; set; }
    }
}
