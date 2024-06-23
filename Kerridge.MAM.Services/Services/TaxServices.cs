using Kerridge.MAM.Data.Interfaces;
using Kerridge.MAM.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerridge.MAM.Services.Services
{
    public class TaxServices: ITax
    {
        private readonly IRepository<Tax> _repository;
        private readonly ITax _tax;

        public TaxServices(IRepository<Tax> repository, ITax tax)
        {
            _repository = repository;
            _tax = tax;
        }

        public async Task AddTax(Tax tax)
        {
            await _repository.Add(tax);
        }

        public async Task DeleteTask(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<List<Tax>> GetAllTaxes()
        {
            return await _repository.GetAll();
        } 

        public async Task<Tax> GetTaxById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task UpdateTax(Tax tax)
        {
            await _repository.Update(tax);
        }

        public double CalculateTax(double taxPercentage, double price)
        {
            return _tax.CalculateTax(taxPercentage, price);
        }

        public async Task<Tax> GetByTaxType(bool isImport)
        {
            return await _tax.GetByTaxType(isImport);
        }
    }
}
