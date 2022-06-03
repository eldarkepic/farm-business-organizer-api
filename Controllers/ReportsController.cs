using AutoMapper;
using farma_api.Dtos;
using farma_api.Models;
using farma_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Controllers
{
    [Route("api/companies/{companyID}/farms/{farmId}/reports")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportRepo _reportRepo;
        private readonly IMapper _mapper;

        public ReportsController(IReportRepo reportRepo, IMapper mapper)
        {
            _reportRepo = reportRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetReports(int farmId)
        {
            try
            {
                if (!_reportRepo.FarmExists(farmId))
                {
                    return NotFound();
                }
                var reports = _reportRepo.GetAllReports(farmId);
                return Ok(_mapper.Map<IEnumerable<ReportReadDto>>(reports));
            }
            catch
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }      
        }

        [HttpGet("{reportId}", Name = "GetReport")]
        public IActionResult GetReport(int companyID, int farmId, int reportId)
        {
            if (!_reportRepo.FarmExists(farmId))
            {
                return NotFound();
            }
            var report = _reportRepo.GetReportById(farmId, reportId);

            if (report == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ReportReadDto>(report));
        }

        [HttpPut("{reportId}")]
        public IActionResult PutReport(int farmId, int reportId, ReportCreateUpdateDto reportUpdateDto)
        {
            if (!_reportRepo.FarmExists(farmId))
            {
                return NotFound();
            }

            var report = _reportRepo.GetReportById(farmId, reportId);

            if (report == null)
            {
                return NotFound();
            }

            _mapper.Map(reportUpdateDto, report);
            _reportRepo.UpdateReport(farmId, report);
            _reportRepo.SaveChanges();

            return NoContent();
        }

        [HttpPost]
        public IActionResult PostReport(int companyID, int farmId, ReportCreateUpdateDto reportCreateDto)
        {
            if (!_reportRepo.FarmExists(farmId))
            {
                return NotFound();
            }

            var report = _mapper.Map<Report>(reportCreateDto);
            _reportRepo.CreateReport(companyID, farmId, report);
            _reportRepo.SaveChanges();

            var reportReadDto = _mapper.Map<ReportReadDto>(report);

            return CreatedAtRoute("GetReport", new {companyID = companyID, farmId = farmId, reportId = reportReadDto.ReportId }, reportReadDto);
        }

        [HttpDelete("{reportId}")]
        public IActionResult DeleteReport(int farmId, int reportId)
        {
            if (!_reportRepo.FarmExists(farmId))
            {
                return NotFound();
            }

            var report = _reportRepo.GetReportById(farmId, reportId);
            if (report == null)
            {
                return NotFound();
            }
            _reportRepo.DeleteReport(report);
            _reportRepo.SaveChanges();

            return NoContent();
        }
    }
}
