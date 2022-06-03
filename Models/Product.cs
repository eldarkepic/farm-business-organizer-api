using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }

        // public ProductType Type { get; set; }
        public string Barcode { get; set; }
        public bool IsFood { get; set; }
        public string Description { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        public List<ProductVariation> Variations { get; set; } = new List<ProductVariation>();

    }
}
