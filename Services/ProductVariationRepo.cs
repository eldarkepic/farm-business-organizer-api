using farma_api.Data;
using farma_api.Dtos;
using farma_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Services
{
    public class ProductVariationRepo : IProductVariationRepo
    {
        private readonly MyContext _context;
        private readonly IProductRepo _productRepo;
        private readonly IWarehouseRepo _warehouseRepo;

        public ProductVariationRepo(MyContext context, IProductRepo productRepo, IWarehouseRepo warehouseRepo)
        {
            _context = context;
            _productRepo = productRepo;
            _warehouseRepo = warehouseRepo;
        }
        public void CreateProductVariation(int companyId, int productId, int warehouseId, ProductVariation productVariation)
        {
            var product = _productRepo.GetProductById(companyId, productId);
            product.Variations.Add(productVariation);
            var warehouse = _warehouseRepo.GetWarehouseById(companyId, warehouseId);
            warehouse.ProductVariations.Add(productVariation);
        }

        public void CreateVariationForInvoice(int companyID, ICollection<ProductVariation> productVariation)
        {
            foreach (ProductVariation variation in productVariation)
            {
                var product = _productRepo.GetProductById(companyID, variation.ProductId);
                product.Variations.Add(variation);
            }
        }
            

        public void DeleteProductVariation(ProductVariation productVariation)
        {
            if (productVariation == null)
            {
                throw new ArgumentNullException(nameof(productVariation));
            }
            _context.ProductVariations.Remove(productVariation);
        }

        public IEnumerable<ProductVariation> GetAllProductVariations(int productId)
        {
            return _context.ProductVariations.Where(c => c.ProductId == productId).ToList();
        }

        public ProductVariation GetProductVariationById(int productId, int productVariationId)
        {
            return _context.ProductVariations.Where(p => p.ProductId == productId && p.ProductVariationId == productVariationId).FirstOrDefault();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
        public bool ProductExists(int productId)
        {
            return _context.Products.Any(c => c.ProductId == productId);
        }


        public void UpdateProductVariation(int productId, ProductVariation productVariation)
        {
            
        }

       
    }
}
