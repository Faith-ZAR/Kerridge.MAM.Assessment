using Kerridge.MAM.Data.Interfaces;
using Kerridge.MAM.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerridge.MAM.Services.Services
{
    public class ReceiptProductService
    {
        private readonly IRepository<Tax> _repository;
        private readonly ITax _tax;

        public ReceiptProductService(IRepository<Tax> repository, ITax tax)
        {
            _repository = repository;
            _tax = tax;
        }

        public async Task<double> CalculateProductTax(Product product)
        {
            bool isImport = (product.IsImported);

            Tax taxObject = await _tax.GetByTaxType(isImport);

            return _tax.CalculateTax(taxObject.Percentage, product.Price);
        }
    }
}
