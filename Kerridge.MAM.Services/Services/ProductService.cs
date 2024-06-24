using Kerridge.MAM.Data.Interfaces;
using Kerridge.MAM.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerridge.MAM.Services.Services
{
    public class ProductService : IProduct
    {
        private readonly IRepository<Product> _repository;
        private readonly ITax _tax;

        public ProductService(IRepository<Product> repository, ITax tax)
        {
            _repository = repository;
            _tax = tax;
        }

        public object ProcessProducts(List<InputView> input)
        {
            List<Product> products = new List<Product>();

            foreach (var item in input)
            {
                var parts = item.ItemInput.Split(' ');
                int quantity = int.Parse(parts[0]);
                decimal price = decimal.Parse(parts[^1]);
                string name = string.Join(' ', parts.Skip(1).Take(parts.Length - 3));
                bool imported = name.ToLower().Contains("import");

                products.Add(new Product
                {
                    Description = name,
                    Price = (price * quantity),
                    Quantity = quantity,
                    IsImported = imported,
                    BasicTaxable = item.BasicTaxable
                });
            }

            var result = CalculateTotals(products);
            return result;
        }

        private object CalculateTotals(List<Product> products)
        {
            decimal totalSalesTaxes = 0;
            decimal totalPrice = 0;

            foreach (var product in products)
            {
                decimal taxAmount = _tax.CalculateTax(product);
                decimal totalPriceForProduct = product.Price + taxAmount;

                totalSalesTaxes += taxAmount;
                totalPrice += totalPriceForProduct;
                product.TaxAmount = taxAmount;

                Console.WriteLine($"{product.Quantity} {product.Description}: {totalPriceForProduct.ToString("0.00")}");
            }

            Console.WriteLine($"Sales Taxes: {totalSalesTaxes.ToString("0.00")}");
            Console.WriteLine($"Total: {totalPrice.ToString("0.00")}");

            return new
            {
                Output = products.Select(v => $"{v.Quantity} {v.Description}: {(v.Price + v.TaxAmount).ToString("0.00")}"),
                SalesTaxes = totalSalesTaxes.ToString("0.00"),
                Total = totalPrice.ToString("0.00")
            };
        }
    }
}
