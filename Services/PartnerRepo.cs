using farma_api.Data;
using farma_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Services
{
    public class PartnerRepo : IPartnerRepo
    {
        private readonly MyContext _context;
        private readonly ICompanyRepo _companyRepo;

        public PartnerRepo(MyContext context, ICompanyRepo companyRepo)
        {
            _context = context;
            _companyRepo = companyRepo;
        }
        public void CreatePartner(int companyId, Partner partner)
        {
            var company = _companyRepo.GetCompanyById(companyId, false);
            company.Partners.Add(partner);
        }

        public void DeletePartner(Partner partner)
        {
            if (partner == null)
            {
                throw new ArgumentNullException(nameof(partner));
            }
            _context.Partners.Remove(partner);
        }

        public IEnumerable<Partner> GetAllPartners(int companyId)
        {
            return _context.Partners.Where(p => p.CompanyId == companyId).ToList();
        }

        public Partner GetPartnerById(int companyId, int partnerId)
        {
            return _context.Partners.Where(p => p.CompanyId == companyId && p.PartnerId == partnerId).FirstOrDefault();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public bool CompanyExists(int companyId)
        {
            return _context.Company.Any(c => c.CompanyID == companyId);
        }

        public void UpdatePartner(int companyId, Partner partner)
        {
            
        }
    }
}
