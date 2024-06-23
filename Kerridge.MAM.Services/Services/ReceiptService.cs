using Kerridge.MAM.Data.Interfaces;
using Kerridge.MAM.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerridge.MAM.Services.Services
{
    public class ReceiptService
    {
        private readonly IRepository<Receipt> _repository;

        public ReceiptService(IRepository<Receipt> repository)
        {
            _repository = repository;
        }

        public async Task AddReceipt(Receipt receipt)
        {
            await _repository.Add(receipt);
        }

        public async Task DeleteReceipt(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<List<Receipt>> GetAllReceipts()
        {
            return await _repository.GetAll();
        }

        public async Task<Receipt> GetReceiptById(int id)
        {
            return await _repository.GetById(id);
        }
    }
}
