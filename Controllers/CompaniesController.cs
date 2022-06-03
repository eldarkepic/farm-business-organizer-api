using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using farma_api.Data;
using farma_api.Models;
using farma_api.Services;
using AutoMapper;
using farma_api.Dtos;
using Microsoft.AspNetCore.JsonPatch;

namespace farma_api.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepo _companyRepo;
        private readonly IMapper _mapper;

        public CompaniesController(ICompanyRepo companyRepo, IMapper mapper)
        {
            _companyRepo = companyRepo;
            _mapper = mapper;   
        }

        // GET: api/Companies
        [HttpGet]
        public IActionResult GetCompanies()
        {
            var companies = _companyRepo.GetAllCompanies();
            return Ok(_mapper.Map<IEnumerable<CompanyReadDto>>(companies));
        }

        // GET: api/Companies/5
        [HttpGet("{id}", Name = "GetCompany")]
        public IActionResult GetCompany(int id, bool includeFarms = true)
        {
            var company =  _companyRepo.GetCompanyById(id, includeFarms);

            if (company == null)
            {
                return NotFound();
            }

            if (includeFarms)
            {
                return Ok(_mapper.Map<CompanyReadDto>(company));
            }

            return Ok(_mapper.Map<CompanyWithoutListsDto>(company));
        }

        // PUT: api/Companies/5
        [HttpPut("{id}")]
        public IActionResult PutCompany(int id, CompanyCreateUpdateDto companyUpdateDto)
        {
            var companyModel = _companyRepo.GetCompanyById(id, false);

            if (companyModel == null)
            {
                return NotFound();
            }

            _mapper.Map(companyUpdateDto, companyModel);
            _companyRepo.UpdateCompany(companyModel);
            _companyRepo.SaveChanges();

            return NoContent();

        }

        // PATCH: api/Companies
        [HttpPatch("{id}")]
        public IActionResult PatchCompany(int id, [FromBody] JsonPatchDocument<CompanyCreateUpdateDto> patchDoc)
        {
            var companyModel = _companyRepo.GetCompanyById(id, false);

            if (companyModel == null)
            {
                return NotFound();
            }

            var companyPatch = _mapper.Map<CompanyCreateUpdateDto>(companyModel);
            patchDoc.ApplyTo(companyPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(companyPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(companyPatch, companyModel);

            _companyRepo.UpdateCompany(companyModel);

            _companyRepo.SaveChanges();

            return NoContent();

        }

        // POST: api/Companies
        [HttpPost]
        public IActionResult PostCompany(CompanyCreateUpdateDto companyCreateDto)
        {
            var companyModel = _mapper.Map<Company>(companyCreateDto);
            _companyRepo.CreateCompany(companyModel);
            _companyRepo.SaveChanges();

            var companyReadDto = _mapper.Map<CompanyReadDto>(companyModel);

            return CreatedAtRoute("GetCompany", new { Id = companyReadDto.CompanyID }, companyReadDto);
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCompany(int id)
        {
            var companyModel = _companyRepo.GetCompanyById(id, false);
            if (companyModel == null)
            {
                return NotFound();
            }
            _companyRepo.DeleteCompany(companyModel);
            _companyRepo.SaveChanges();

            return NoContent();
        }


    }
}
