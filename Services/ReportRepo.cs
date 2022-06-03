using farma_api.Data;
using farma_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Services
{
    public class ReportRepo : IReportRepo
    {
        private readonly MyContext _context;
        private readonly IFarmRepo _farmRepo;

        public ReportRepo(MyContext context, IFarmRepo farmRepo)
        {
            _context = context;
            _farmRepo = farmRepo;
        }
        public void CreateReport(int companyId, int farmId, Report report)
        {
            var farm = _farmRepo.GetFarmById(companyId, farmId);
            farm.Reports.Add(report);
        }

        public void DeleteReport(Report report)
        {
            _context.Reports.Remove(report);
        }

        public bool FarmExists(int farmId)
        {
            return _context.Farms.Any(c => c.FarmId == farmId);
        }

        public IEnumerable<Report> GetAllReports(int farmId)
        {
            return _context.Reports
                          .Where(p => p.FarmId == farmId).ToList();
        }

        public Report GetReportById(int farmId, int reportId)
        {
        return _context.Reports
           .Where(p => p.FarmId == farmId && p.ReportId == reportId).FirstOrDefault();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateReport(int farmId, Report report)
        {
            
        }
    }
}
