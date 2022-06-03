using farma_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Services
{
    public interface IProductRepo
    {
        IEnumerable<Product> GetAllProducts(int companyId);
        Product GetProductById(int companyId, int productId);
        void CreateProduct(int companyId, Product product);
        void UpdateProduct(int companyId, Product product);
        void DeleteProduct(Product product);
        bool CompanyExists(int companyId);
        bool SaveChanges();
    }
}
