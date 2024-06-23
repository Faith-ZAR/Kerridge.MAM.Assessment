using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerridge.MAM.Data.Models
{
    public class Receipt
    {
        public int ReceiptId { get; set; }
        public DateTime ReceiptDate { get; set; }
        public double SalesTax { get; set; }
        public double Total { get; set; }
        public List<Product> Products { get; set; }
    }
}
