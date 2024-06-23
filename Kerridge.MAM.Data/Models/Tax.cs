using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerridge.MAM.Data.Models
{
    public class Tax
    {
        public int TaxId { get; set; }
        public string Description { get; set; }
        public double Percentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
        public bool IsImportDuty { get; set; }
    }
}
