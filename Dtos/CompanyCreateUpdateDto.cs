using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Dtos
{
    public class CompanyCreateUpdateDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int IdNumber { get; set; }
        public int PdvNumber { get; set; }
        public int BankNumber { get; set; }
    }
}
