using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Models
{
    public class Warehouse
    {
        public int WarehouseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Capacity { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        public ICollection<ProductVariation> ProductVariations { get; set; } = new List<ProductVariation>();
    }
}
