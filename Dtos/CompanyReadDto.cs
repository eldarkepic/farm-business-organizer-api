using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Dtos
{
    public class CompanyReadDto
    {
        public int CompanyID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int IdNumber { get; set; }
        public int PdvNumber { get; set; }
        public int BankNumber { get; set; }
        public int NumberOfFarms
        {
            get
            {
                return Farms.Count;
            }
        }

        public ICollection<FarmReadDto> Farms { get; set; }
          = new List<FarmReadDto>();

        //public int NumberOfUsers
        //{
        //    get
        //    {
        //        return Users.Count;
        //    }
        //}

        //public ICollection<> Users { get; set; }
        //  = new List<FarmReadDto>();
    }
}
