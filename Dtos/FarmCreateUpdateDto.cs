using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Dtos
{
    public class FarmCreateUpdateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
    }
}
