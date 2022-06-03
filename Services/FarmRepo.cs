using farma_api.Data;
using farma_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Services
{
    public class FarmRepo : IFarmRepo
    {
        private readonly MyContext _context;
        private readonly ICompanyRepo _companyRepo;

        public FarmRepo(MyContext context, ICompanyRepo companyRepo)
        {
            _context = context;
            _companyRepo = companyRepo;
        }

        public void CreateFarm(int companyId, Farm farm)
        {
            var company = _companyRepo.GetCompanyById(companyId, false);
            company.Farms.Add(farm);

        }

        public void DeleteFarm(Farm farm)
        {
            _context.Farms.Remove(farm);
        }

        public bool CompanyExists(int companyId)
        {
            return _context.Company.Any(c => c.CompanyID == companyId);
        }

        public IEnumerable<Farm> GetAllFarms(int companyId)
        {
            return _context.Farms
                          .Where(p => p.CompanyId == companyId).ToList();
        }

        public Farm GetFarmById(int companyID, int farmId)
        {
            return _context.Farms
               .Where(p => p.CompanyId == companyID && p.FarmId == farmId).FirstOrDefault();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateFarm(int companyId, Farm farm)
        {
            
        }
    }
}
