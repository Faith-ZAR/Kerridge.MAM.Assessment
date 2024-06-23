using Kerridge.MAM.Data.Interfaces;
using Kerridge.MAM.Data.Models;
using Kerridge.MAM.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerridge.MAM.Services.Repositories
{
    public class TaxRepository : ITax
    {
        private readonly IRepository<Tax> _repository;

        public TaxRepository(IRepository<Tax> repository)
        {
            _repository = repository;
        }

        public double CalculateTax(double taxPercentage, double price)
        {
            return (taxPercentage / 100) * price;
        }

        public async Task<Tax> GetByTaxType(bool isImport)
        {
            var allObjects = await _repository.GetAll();
            var currentObject = allObjects.FirstOrDefault(e => e.IsImportDuty == isImport && e.IsActive);

            return currentObject;
        }
    }
}
