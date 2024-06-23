using Kerridge.MAM.Data.Interfaces;
using Kerridge.MAM.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerridge.MAM.Services.Services
{
    public class ProductService
    {
        private readonly IRepository<Product> _repository;

        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task AddProductAsync(Product product)
        {
            await _repository.Add(product);
        }

        public async Task DeleteProduct(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _repository.GetAll();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task UpdateProduct(Product product)
        {
            await _repository.Update(product);
        }
    }
}
