using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string  Password { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}
