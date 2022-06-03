using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Models
{
    public class Company
    {
        public int CompanyID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int IdNumber { get; set; }
        public int PdvNumber { get; set; }
        public int BankNumber { get; set; }
        public ICollection<Farm> Farms { get; set; }
               = new List<Farm>();
        public ICollection<Warehouse> Warehouses { get; set; }
               = new List<Warehouse>();
        public ICollection<Partner> Partners { get; set; }
               = new List<Partner>();
        public ICollection<Product> Products { get; set; }
               = new List<Product>();
        public ICollection<User> Users { get; set; }
                = new List<User>();
    }
}
