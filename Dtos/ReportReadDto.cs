using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Dtos
{
    public class ReportReadDto
    {
        public int ReportId { get; set; }
        public string Name { get; set; }
        public DateTime MadeOn { get; set; }
        public int EggProduction { get; set; }
        public int Deaths { get; set; }
        public string Vitamins { get; set; }
        public float FoodAmount { get; set; }
        public float Coefficient { get; set; }
    }
}
