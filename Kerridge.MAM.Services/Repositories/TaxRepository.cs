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
        private readonly JsonDBRepository<Tax> _repository;

        public TaxRepository(JsonDBRepository<Tax> repository)
        {
            _repository = repository;
        }

        public double CalculateTax(double taxPercentage, double price)
        {
            return (taxPercentage / 100) * price;
        }

        public Task<Tax> GetByTaxType(bool isImport)
        {
            var jsonObject = _repository.LoadData();
            var allObjects = _repository.GetObjects(jsonObject);
            var currentObject = allObjects.FirstOrDefault(x => (bool)x.GetType().GetProperty("IsImportDuty").GetValue(x) == isImport && (bool)x.GetType().GetProperty("IsActive").GetValue(x) == true);
            return Task.FromResult(currentObject);
        }
    }
}
