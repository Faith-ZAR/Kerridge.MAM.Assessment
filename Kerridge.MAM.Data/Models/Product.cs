using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerridge.MAM.Data.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
