using farma_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Services
{
    public interface IPartnerRepo
    {
        IEnumerable<Partner> GetAllPartners(int companyID);
        Partner GetPartnerById(int companyId, int partnerId);
        void CreatePartner(int companyId, Partner partner);
        void UpdatePartner(int companyId, Partner partner);
        void DeletePartner(Partner partner);
        bool CompanyExists(int companyId);
        bool SaveChanges();
    }
}
