using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Models
{
    public class ProductVariation
    {
        public int ProductVariationId { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public float Price { get; set; }
        public float Amount { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public Warehouse Warehouse { get; set; }
        public int WarehouseId { get; set; }
        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
        public ICollection<Recipe> Recipes { get; set; }
    }
}
