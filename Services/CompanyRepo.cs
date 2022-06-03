using farma_api.Data;
using farma_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Services
{
    public class CompanyRepo : ICompanyRepo
    {
        private readonly MyContext _context;

        public CompanyRepo(MyContext context)
        {
            _context = context;
        }

        public void CreateCompany(Company company)
        {
            if (company == null)
            {
                throw new ArgumentNullException(nameof(company));
            }

            _context.Company.Add(company);
        }

        public void DeleteCompany(Company company)
        {
            if (company == null)
            {
                throw new ArgumentNullException(nameof(company));
            }
            _context.Company.Remove(company);
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            return _context.Company.OrderBy(c => c.Name).ToList();
        }

        public Company GetCompanyById(int companyId, bool includeFarms)
        {
            if (includeFarms)
            {
                return _context.Company.Include(c => c.Farms)
                    .Where(c => c.CompanyID == companyId).FirstOrDefault();
            }

            return _context.Company.Where(p => p.CompanyID == companyId).FirstOrDefault();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCompany(Company company)
        {
           
        }
    }
}
