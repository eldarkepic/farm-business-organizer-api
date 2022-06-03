using farma_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Services
{
    public interface ICompanyRepo
    {
        IEnumerable<Company> GetAllCompanies();
        Company GetCompanyById(int id, bool includeFarms);
        void CreateCompany(Company company);
        void UpdateCompany(Company company);
        void DeleteCompany(Company company);
        bool SaveChanges();
    }
}
