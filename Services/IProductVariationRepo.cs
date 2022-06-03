using farma_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Services
{
    public interface IProductVariationRepo
    {
        IEnumerable<ProductVariation> GetAllProductVariations(int productId);
        ProductVariation GetProductVariationById(int productId, int variationId);
        void CreateProductVariation(int companyId, int productId, int warehouseId, ProductVariation productVariation);
        void CreateVariationForInvoice(int companyId, ICollection<ProductVariation> productVariation);
        void UpdateProductVariation(int productId, ProductVariation productVariation);
        void DeleteProductVariation(ProductVariation productVariation);
        bool ProductExists(int productId);
        bool SaveChanges();
    }
}
