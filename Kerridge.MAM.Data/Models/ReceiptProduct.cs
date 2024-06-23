using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerridge.MAM.Data.Models
{
    public class ReceiptProduct
    {
        public int ReceiptProductId { get; set; }
        public int ProductId { get; set; }
        public int ReceiptId { get; set; }
        public double TaxAmount { get; set; }
        public double LineTotal { get; set; }
    }
}
