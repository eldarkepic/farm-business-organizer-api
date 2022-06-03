using AutoMapper;
using farma_api.Dtos;
using farma_api.Models;
using farma_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Controllers
{
    [Route("api/companies/{companyID}/farms")]
    [ApiController]
    public class FarmsController : ControllerBase
    {
        private readonly IFarmRepo _farmRepo;
        private readonly IMapper _mapper;

        public FarmsController(IFarmRepo farmRepo, IMapper mapper)
        {
            _farmRepo = farmRepo;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetFarms(int companyID)
        {
            try
            {
                if (!_farmRepo.CompanyExists(companyID))
                {
                    return NotFound();
                }

                var farms = _farmRepo.GetAllFarms(companyID);
                return Ok(_mapper.Map<IEnumerable<FarmReadDto>>(farms));
            }
            catch
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            
        }


        [HttpGet("{farmId}", Name = "GetFarm")]
        public IActionResult GetFarm(int companyID, int farmId)
        {
            if (!_farmRepo.CompanyExists(companyID))
            {
                return NotFound();
            }

            var farm = _farmRepo.GetFarmById(companyID, farmId);

            if (farm == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<FarmReadDto>(farm));
        }

        [HttpPost]
        public IActionResult PostFarm(int companyID, [FromBody]FarmCreateUpdateDto farmCreateDto)
        {
            if (!_farmRepo.CompanyExists(companyID))
            {
                return NotFound();
            }

            var farm = _mapper.Map<Farm>(farmCreateDto);
            _farmRepo.CreateFarm(companyID, farm);
            _farmRepo.SaveChanges();

            var farmReadDto = _mapper.Map<FarmReadDto>(farm);
            return CreatedAtRoute("GetFarm", new {companyID = companyID , farmId = farmReadDto.FarmId }, farmReadDto);
        }

        [HttpPut("{farmId}")]
        public IActionResult PutFarm(int companyID, int farmId, FarmCreateUpdateDto farmUpdateDto)
        {
            if (!_farmRepo.CompanyExists(companyID))
            {
                return NotFound();
            }

            var farm = _farmRepo.GetFarmById(companyID, farmId);
            if (farm == null)
            {
                return NotFound();
            }

            _mapper.Map(farmUpdateDto, farm);
            _farmRepo.UpdateFarm(companyID, farm);
            _farmRepo.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{farmId}")]
        public IActionResult PatchFarm(int companyId, int farmId, [FromBody] JsonPatchDocument<FarmCreateUpdateDto> patchDoc)
        {
            if (!_farmRepo.CompanyExists(companyId))
            {
                return NotFound();
            }

            var farm = _farmRepo.GetFarmById(companyId, farmId);
            if (farm == null)
            {
                return NotFound();
            }

            var farmPatch = _mapper.Map<FarmCreateUpdateDto>(farm);
            patchDoc.ApplyTo(farmPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(farmPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(farmPatch, farm);

            _farmRepo.UpdateFarm(companyId, farm);

            _farmRepo.SaveChanges();

            return NoContent();

        }

        [HttpDelete("{farmId}")]
        public IActionResult DeleteFarm (int companyID, int farmId)
        {
            if (!_farmRepo.CompanyExists(companyID))
            {
                return NotFound();
            }

            var farm = _farmRepo.GetFarmById(companyID, farmId);
            if (farm == null)
            {
                return NotFound();
            }

            _farmRepo.DeleteFarm(farm);
            _farmRepo.SaveChanges();

            return NoContent();
        }
        

    }
}
