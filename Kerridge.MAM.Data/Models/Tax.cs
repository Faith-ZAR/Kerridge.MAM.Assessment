using Kerridge.MAM.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Kerridge.MAM.Data.Interfaces.ITax;

namespace Kerridge.MAM.Data.Models
{
    public class Tax
    {
        public int TaxId { get; set; }
        public string Description { get; set; }
        public decimal Percentage { get; set; }
        public TaxType Type { get; set; }
        public bool IsActive { get; set; }
    }
}
