using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Dtos
{
    public class ProductVariationReadDto
    {
        public int ProductVariationId { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public float Price { get; set; }
        public float Amount { get; set; }
    }
}
