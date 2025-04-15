using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_for_Information_Managment
{
    public class Scanner
    {
        public int ScannerId { get; set; }
        public string InventoryNumber { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public int? ResolutionDpi { get; set; }
        public string ScanType { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime? WarrantyEndDate { get; set; }
        public string Status { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string Notes { get; set; }
    }
}
