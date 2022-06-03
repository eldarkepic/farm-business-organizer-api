using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public float AmountCereal { get; set; }
        public float AmountProduct { get; set; }
        public Product Product { get; set; }
        public ICollection<ProductVariation> Cereals { get; set; }
    }
}
