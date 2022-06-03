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
    [Route("api/companies/{companyID}/partners")]
    [ApiController]
    public class PartnersController : ControllerBase
    {
        private readonly IPartnerRepo _partnerRepo;
        private readonly IMapper _mapper;

        public PartnersController(IPartnerRepo partnerRepo, IMapper mapper)
        {
            _partnerRepo = partnerRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetPartners(int companyID)
        {
            try
            {
                if (!_partnerRepo.CompanyExists(companyID))
                {
                    return NotFound();
                }

                var partners = _partnerRepo.GetAllPartners(companyID);
                return Ok(_mapper.Map<IEnumerable<PartnerReadDto>>(partners));
            }
            catch
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpGet("{partnerId}", Name = "GetPartner")]
        public IActionResult GetPartner(int companyID, int partnerId)
        {
            if (!_partnerRepo.CompanyExists(companyID))
            {
                return NotFound();
            }
            var partner = _partnerRepo.GetPartnerById(companyID, partnerId);

            if (partner == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PartnerReadDto>(partner));
        }

        [HttpPut("{partnerId}")]
        public IActionResult PutPartner(int companyID, int partnerId, PartnerCreateUpdateDto partnerUpdateDto)
        {
            if (!_partnerRepo.CompanyExists(companyID))
            {
                return NotFound();
            }
            var partner = _partnerRepo.GetPartnerById(companyID, partnerId);

            if (partner == null)
            {
                return NotFound();
            }

            _mapper.Map(partnerUpdateDto, partner);
            _partnerRepo.UpdatePartner(companyID, partner);
            _partnerRepo.SaveChanges();

            return NoContent();
        }

        [HttpPost]
        public IActionResult PostPartner(int companyID, PartnerCreateUpdateDto partnerCreateDto)
        {
            if (!_partnerRepo.CompanyExists(companyID))
            {
                return NotFound();
            }
            var partner = _mapper.Map<Partner>(partnerCreateDto);
            _partnerRepo.CreatePartner(companyID, partner);
            _partnerRepo.SaveChanges();

            var partnerReadDto = _mapper.Map<PartnerReadDto>(partner);

            return CreatedAtRoute("GetPartner", new { companyID = companyID,  partnerId = partnerReadDto.PartnerId }, partnerReadDto);
        }

        [HttpDelete("{partnerId}")]
        public IActionResult DeletePartner(int companyID, int partnerId)
        {
            if (!_partnerRepo.CompanyExists(companyID))
            {
                return NotFound();
            }
            var partner = _partnerRepo.GetPartnerById(companyID, partnerId);
            if (partner == null)
            {
                return NotFound();
            }
            _partnerRepo.DeletePartner(partner);
            _partnerRepo.SaveChanges();

            return NoContent();
        }
    }
}
