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
    [Route("api/companies/{companyID}/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepo _productRepo;
        private readonly IMapper _mapper;
        public ProductsController(IProductRepo productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetProducts(int companyID)
        {
            try
            {
                if (!_productRepo.CompanyExists(companyID))
                {
                    return NotFound();
                }

                var products = _productRepo.GetAllProducts(companyID);
                return Ok(_mapper.Map<IEnumerable<ProductReadDto>>(products));
            }
            catch
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }
            
        }

        [HttpGet("{productId}", Name = "GetProduct")]
        public IActionResult GetProduct(int companyID, int productId)
        {
            if (!_productRepo.CompanyExists(companyID))
            {
                return NotFound();
            }
            var product = _productRepo.GetProductById(companyID, productId);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ProductReadDto>(product));
        }

        [HttpPut("{productId}")]
        public IActionResult PutProduct(int companyID, int productId, ProductCreateUpdateDto productUpdateDto)
        {
            if (!_productRepo.CompanyExists(companyID))
            {
                return NotFound();
            }
            var product = _productRepo.GetProductById(companyID, productId);

            if (product == null)
            {
                return NotFound();
            }

            _mapper.Map(productUpdateDto, product);
            _productRepo.UpdateProduct(companyID, product);
            _productRepo.SaveChanges();

            return NoContent();
        }

        [HttpPost]
        public IActionResult PostProduct(int companyID, ProductCreateUpdateDto productCreateDto)
        {
            if (!_productRepo.CompanyExists(companyID))
            {
                return NotFound();
            }
            var product = _mapper.Map<Product>(productCreateDto);
            _productRepo.CreateProduct(companyID, product);
            _productRepo.SaveChanges();

            var productReadDto = _mapper.Map<ProductReadDto>(product);

            return CreatedAtRoute("GetProduct", new { companyID = companyID, productId = productReadDto.ProductId }, productReadDto);
        }

        [HttpDelete("{productId}")]
        public IActionResult DeleteProduct(int companyID, int productId)
        {
            if (!_productRepo.CompanyExists(companyID))
            {
                return NotFound();
            }
            var product = _productRepo.GetProductById(companyID, productId);
            if (product == null)
            {
                return NotFound();
            }
            _productRepo.DeleteProduct(product);
            _productRepo.SaveChanges();

            return NoContent();
        }
    }
}
