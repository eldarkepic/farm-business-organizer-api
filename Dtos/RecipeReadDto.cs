using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Dtos
{
    public class RecipeReadDto
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public float AmountCereal { get; set; }
        public float AmountProduct { get; set; }
        public ProductReadDto Product { get; set; }
        public ICollection<ProductVariationReadDto> Cereals { get; set; }
    }
}
