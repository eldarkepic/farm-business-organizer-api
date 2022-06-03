using farma_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Services
{
    public interface IFarmRepo
    {
        IEnumerable<Farm> GetAllFarms(int companyId);
        Farm GetFarmById(int companyId, int farmId);
        void CreateFarm(int companyId, Farm farm);
        void UpdateFarm(int companyId, Farm farm);
        void DeleteFarm(Farm farm);
        bool CompanyExists(int companyId);
        bool SaveChanges();
    }
}
