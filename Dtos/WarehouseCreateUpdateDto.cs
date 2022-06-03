using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Dtos
{
    public class WarehouseCreateUpdateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Capacity { get; set; }
    }
}
