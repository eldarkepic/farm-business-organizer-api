using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Dtos
{
    public class PartnerReadDto
    {
        public int PartnerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int IdNumber { get; set; }
        public int PdvNumber { get; set; }
        public string Description { get; set; }
        public ICollection<InvoiceReadDto> Invoices { get; set; } = new List<InvoiceReadDto>();
    }
}
