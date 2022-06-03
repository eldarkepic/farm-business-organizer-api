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
    [Route("api/companies/{companyID}/products/{productId}/productVariations")]
    [ApiController]
    public class ProductVariationsController : ControllerBase
    {
        private readonly IProductVariationRepo _variationRepo;
        private readonly IMapper _mapper;

        public ProductVariationsController(IProductVariationRepo variationRepo, IMapper mapper)
        {
            _variationRepo = variationRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetProductVariations(int productId)
        {
            try
            {
                if (!_variationRepo.ProductExists(productId))
                {
                    return NotFound();
                }
                var variations = _variationRepo.GetAllProductVariations(productId);
                return Ok(_mapper.Map<IEnumerable<ProductVariationReadDto>>(variations));
            }
            catch
            {
                return StatusCode(500, "A problem happened while handling request.");
            }
            
        }

        [HttpGet("{variationId}", Name = "GetProductVariation")]
        public IActionResult GetProductVariation(int companyID, int productId, int variationId)
        {
            if (!_variationRepo.ProductExists(productId))
            {
                return NotFound();
            }
            var variation = _variationRepo.GetProductVariationById(productId, variationId);

            if (variation == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ProductVariationReadDto>(variation));
        }

        [HttpPut("{variationId}")]
        public IActionResult PutProductVariation(int productId, int variationId, ProductVariationCreateUpdateDto variationUpdateDto)
        {
            if (!_variationRepo.ProductExists(productId))
            {
                return NotFound();
            }
            var variation = _variationRepo.GetProductVariationById(productId, variationId);

            if (variation == null)
            {
                return NotFound();
            }

            _mapper.Map(variationUpdateDto, variation);
            _variationRepo.UpdateProductVariation(productId, variation);
            _variationRepo.SaveChanges();

            return NoContent();
        }

        [HttpPost]
        public IActionResult PostProductVariation(int companyID, int productId, ProductVariationCreateUpdateDto variationCreateDto)
        {
            if (!_variationRepo.ProductExists(productId))
            {
                return NotFound();
            }
            var variation = _mapper.Map<ProductVariation>(variationCreateDto);
            _variationRepo.CreateProductVariation(companyID, productId, variation.WarehouseId, variation);
            _variationRepo.SaveChanges();

            var variationReadDto = _mapper.Map<ProductVariationReadDto>(variation);

            return CreatedAtRoute("GetProductVariation", new {companyID = companyID, productId = productId, variationId = variationReadDto.ProductVariationId }, variationReadDto);
        }

        [HttpDelete("{variationId}")]
        public IActionResult DeleteProductVariation(int productId, int variationId)
        {
            if (!_variationRepo.ProductExists(productId))
            {
                return NotFound();
            }
            var variation = _variationRepo.GetProductVariationById(productId, variationId);
            if (variation == null)
            {
                return NotFound();
            }
            _variationRepo.DeleteProductVariation(variation);
            _variationRepo.SaveChanges();

            return NoContent();
        }
    }
}
