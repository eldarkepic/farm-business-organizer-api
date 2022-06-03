using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int Number { get; set; }
        public DateTime CreationDate { get; set; }
        //public InvoiceType Type { get; set; }
        public string Description { get; set; }
        public float TotalPrice { get; set; }
        public Partner Partner { get; set; }
        public int PartnerId { get; set; }
        public ICollection<ProductVariation> Items { get; set; }
    }
}
