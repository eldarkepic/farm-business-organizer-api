using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Dtos
{
    public class InvoiceCreateUpdateDto
    {
        public int Number { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
        public float TotalPrice { get; set; }
        public List<ProductVariationForInvoiceDto> Items { get; set; }
    }
}
