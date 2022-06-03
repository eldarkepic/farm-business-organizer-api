using farma_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Services
{
    public interface IReportRepo
    {
        IEnumerable<Report> GetAllReports(int farmId);
        Report GetReportById(int farmId, int reportId);
        void CreateReport(int companyId, int farmId, Report report);
        void UpdateReport(int farmId, Report report);
        void DeleteReport(Report report);
        bool FarmExists(int farmId);
        bool SaveChanges();
    }
}
