using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Dtos
{
    public class WarehouseReadDto
    {
        public int WarehouseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Capacity { get; set; }
        public int Products
        {
            get
            {
                return ProductVariations.Count;
            }
        }
        public ICollection<ProductVariationReadDto> ProductVariations { get; set; } = new List<ProductVariationReadDto>();
    }
}
