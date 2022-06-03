using farma_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Services
{
    public interface IWarehouseRepo
    {
        IEnumerable<Warehouse> GetAllWarehouses(int companyId);
        Warehouse GetWarehouseById(int companyId, int warehouseId);
        void CreateWarehouse(int companyId, Warehouse warehouse);
        void UpdateWarehouse(int companyId, Warehouse warehouse);
        void DeleteWarehouse(Warehouse warehouse);
        bool CompanyExists(int companyId);
        bool SaveChanges();
    }
}
