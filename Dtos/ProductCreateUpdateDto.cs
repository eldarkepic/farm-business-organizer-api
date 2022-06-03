using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Dtos
{
    public class ProductCreateUpdateDto
    {
        public string Name { get; set; }

        // public ProductType Type { get; set; }
        public string Barcode { get; set; }
        public bool IsFood { get; set; }
        public string Description { get; set; }

    }
}
