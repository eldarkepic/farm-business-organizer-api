using farma_api.Data;
using farma_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Services
{
    public class ProductRepo : IProductRepo
    {
        public readonly MyContext _context;
        private readonly ICompanyRepo _companyRepo;

        public ProductRepo(MyContext context, ICompanyRepo companyRepo)
        {
            _context = context;
            _companyRepo = companyRepo;
        }
        public void CreateProduct(int companyId, Product product)
        {
            var warehouse = _companyRepo.GetCompanyById(companyId, false);
            warehouse.Products.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            if(product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            _context.Products.Remove(product);
        }

        public IEnumerable<Product> GetAllProducts(int companyId)
        {
            return _context.Products
                          .Where(p => p.CompanyId == companyId).ToList();
        }

        public Product GetProductById(int companyId, int productId)
        {
            return _context.Products
               .Where(p => p.CompanyId == companyId && p.ProductId == productId).FirstOrDefault();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public bool CompanyExists(int companyId)
        {
            return _context.Company.Any(c => c.CompanyID == companyId);
        }

        public void UpdateProduct(int companyId, Product product)
        {
            
        }
    }
}
