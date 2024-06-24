using Kerridge.MAM.Data.Interfaces;
using Kerridge.MAM.Data.Models;
using Kerridge.MAM.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerridge.MAM.Services.Services
{
    public class TaxService : ITax
    {
        private readonly IRepository<Tax> _tax;

        public TaxService(IRepository<Tax> tax)
        {
            _tax = tax;
        }

        public decimal CalculateTax(Product product)
        {
            bool isTaxExempt = (product.BasicTaxable != true);

            decimal taxRate = 0m;
            decimal basicTaxRate = isTaxExempt ? 0 : 0.1m;
            decimal importDutyTaxRate = 0.05m;

            if (product.IsImported)
            {
                taxRate = importDutyTaxRate + basicTaxRate;
            } 
            else
            {
                taxRate = basicTaxRate;
            }

            decimal taxAmount = Math.Ceiling(product.Price * taxRate * 20) / 20;

            return taxAmount;
        }
    }
}
