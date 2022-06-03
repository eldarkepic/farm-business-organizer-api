using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Dtos
{
    public class InvoiceReadDto
    {
        public int InvoiceId { get; set; }
        public int Number { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
        public float TotalPrice { get; set; }
        public int PartnerId { get; set; }
        public ICollection<ProductVariationReadDto> Items { get; set; } = new List<ProductVariationReadDto>();
    }
}
