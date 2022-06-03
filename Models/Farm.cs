using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Models
{
    public class Farm
    {
        public int FarmId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        public List<Report> Reports { get; set; } = new List<Report>();
    }
}
