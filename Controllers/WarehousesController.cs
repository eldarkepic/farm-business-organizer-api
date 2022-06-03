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
    [Route("api/companies/{companyID}/warehouses")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        private readonly IWarehouseRepo _warehouseRepo;
        private readonly IMapper _mapper;

        public WarehousesController(IWarehouseRepo warehouseRepo, IMapper mapper)
        {
            _warehouseRepo = warehouseRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetWarehouses(int companyID)
        {
            try
            {
                if (!_warehouseRepo.CompanyExists(companyID))
                {
                    return NotFound();
                }

                var warehouses = _warehouseRepo.GetAllWarehouses(companyID);
                return Ok(_mapper.Map<IEnumerable<WarehouseReadDto>>(warehouses));
            }
            catch
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpGet("{warehouseId}", Name = "GetWarehouse")]
        public IActionResult GetWarehouse(int companyID, int warehouseId)
        {
            if (!_warehouseRepo.CompanyExists(companyID))
            {
                return NotFound();
            }
            var warehouse = _warehouseRepo.GetWarehouseById(companyID, warehouseId);

            if (warehouse == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<WarehouseReadDto>(warehouse));
        }

        [HttpPut("{warehouseId}")]
        public IActionResult PutWarehouse(int companyID, int warehouseId, WarehouseCreateUpdateDto warehouseUpdateDto)
        {
            if (!_warehouseRepo.CompanyExists(companyID))
            {
                return NotFound();
            }

            var warehouse = _warehouseRepo.GetWarehouseById(companyID, warehouseId);

            if (warehouse == null)
            {
                return NotFound();
            }

            _mapper.Map(warehouseUpdateDto, warehouse);
            _warehouseRepo.UpdateWarehouse(companyID, warehouse);
            _warehouseRepo.SaveChanges();

            return NoContent();
        }

        [HttpPost]
        public IActionResult PostWarehouse(int companyID, WarehouseCreateUpdateDto warehouseCreateDto)
        {
            if (!_warehouseRepo.CompanyExists(companyID))
            {
                return NotFound();
            }

            var warehouse = _mapper.Map<Warehouse>(warehouseCreateDto);
            _warehouseRepo.CreateWarehouse(companyID, warehouse);
            _warehouseRepo.SaveChanges();

            var warehouseReadDto = _mapper.Map<WarehouseReadDto>(warehouse);

            return CreatedAtRoute("GetWarehouse", new { companyID = companyID, warehouseId = warehouseReadDto.WarehouseId }, warehouseReadDto);
        }

        [HttpDelete("{warehouseId}")]
        public IActionResult DeleteWarehouse(int companyID, int warehouseId)
        {
            if (!_warehouseRepo.CompanyExists(companyID))
            {
                return NotFound();
            }
            var warehouse = _warehouseRepo.GetWarehouseById(companyID, warehouseId);
            if (warehouse == null)
            {
                return NotFound();
            }
            _warehouseRepo.DeleteWarehouse(warehouse);
            _warehouseRepo.SaveChanges();

            return NoContent();
        }
    }
}
