using farma_api.Data;
using farma_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Services
{
    public class WarehouseRepo : IWarehouseRepo
    {
        private readonly MyContext _context;
        private readonly ICompanyRepo _companyRepo;

        public WarehouseRepo(MyContext context, ICompanyRepo companyRepo)
        {
            _context = context;
            _companyRepo = companyRepo;
        }
        public void CreateWarehouse(int companyId, Warehouse warehouse)
        {
            var company = _companyRepo.GetCompanyById(companyId, false);
            company.Warehouses.Add(warehouse);
        }

        public void DeleteWarehouse(Warehouse warehouse)
        {
            if (warehouse == null)
            {
                throw new ArgumentNullException(nameof(warehouse));
            }
            _context.Warehouses.Remove(warehouse);
        }

        public bool CompanyExists(int companyId)
        {
            return _context.Company.Any(c => c.CompanyID == companyId);
        }

        public IEnumerable<Warehouse> GetAllWarehouses(int companyId)
        {
            return _context.Warehouses
                          .Where(p => p.CompanyId == companyId).ToList();
        }

        public Warehouse GetWarehouseById(int companyId, int warehouseId)
        {
            return _context.Warehouses.Include(c => c.ProductVariations).Where(p => p.CompanyId == companyId && p.WarehouseId == warehouseId).FirstOrDefault();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateWarehouse(int companyId, Warehouse warehouse)
        {
            
        }
    }
}
