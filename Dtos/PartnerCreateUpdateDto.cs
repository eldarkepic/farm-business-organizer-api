using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Dtos
{
    public class PartnerCreateUpdateDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int IdNumber { get; set; }
        public int PdvNumber { get; set; }
        public string Description { get; set; }
    }
}
