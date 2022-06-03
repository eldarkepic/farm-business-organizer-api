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
    [Route("api/invoices")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceRepo _invoiceRepo;
        private readonly IMapper _mapper;

        public InvoicesController(IInvoiceRepo invoiceRepo, IMapper mapper)
        {
            _invoiceRepo = invoiceRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetInvoices()
        {
            var invoices = _invoiceRepo.GetAllInvoices();
            return Ok(_mapper.Map<IEnumerable<InvoiceReadDto>>(invoices));
        }

        //[HttpGet]
        //public IActionResult GetInvoicesByPartner(int partnerId)
        //{
        //    if (!_invoiceRepo.PartnerExists(partnerId))
        //    {
        //        return NotFound();
        //    }

        //    var invoices = _invoiceRepo.GetAllInvoicesByPartner(partnerId);
        //    return Ok(_mapper.Map<IEnumerable<InvoiceReadDto>>(invoices));
        //}

        [HttpGet("{invoiceId}", Name = "GetInvoice")]
        public IActionResult GetInvoice(int invoiceId)
        {
            var invoice = _invoiceRepo.GetInvoiceById(invoiceId);

            if (invoice == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<InvoiceReadDto>(invoice));
        }

        //[HttpGet("{invoiceId}", Name = "GetInvoiceByPartner")]
        //public IActionResult GetInvoiceByPartner(int partnerId, int invoiceId)
        //{
        //    if (!_invoiceRepo.PartnerExists(partnerId))
        //    {
        //        return NotFound();
        //    }

        //    var invoice = _invoiceRepo.GetInvoiceByIdPartner(partnerId, invoiceId);

        //    if (invoice == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(_mapper.Map<InvoiceReadDto>(invoice));
        //}

        [HttpPost]
        public IActionResult PostInvoice(int companyID, bool type, int partnerId, [FromBody] InvoiceCreateUpdateDto invoiceCreateDto)
        {
            if (!_invoiceRepo.PartnerExists(partnerId))
            {
                return NotFound();
            }

            var invoice = _mapper.Map<Invoice>(invoiceCreateDto);
            _invoiceRepo.CreateInvoice(companyID, type, partnerId, invoice, invoice.Items);
            _invoiceRepo.SaveChanges();

            var invoiceReadDto = _mapper.Map<InvoiceReadDto>(invoice);

            return CreatedAtRoute("GetInvoice", new { id = partnerId }, invoiceReadDto);
        }

        [HttpPut("{invoiceId}")]
        public IActionResult PutInvoice(int invoiceId, InvoiceCreateUpdateDto invoiceUpdateDto)
        {
            var invoice = _invoiceRepo.GetInvoiceById(invoiceId);

            if (invoice == null)
            {
                return NotFound();
            }

            _mapper.Map(invoiceUpdateDto, invoice);
            _invoiceRepo.UpdateInvoice(invoice);
            _invoiceRepo.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{invoiceId}")]
        public IActionResult DeleteCompany(int invoiceId)
        {
            var invoice = _invoiceRepo.GetInvoiceById(invoiceId);
            if (invoice == null)
            {
                return NotFound();
            }
            _invoiceRepo.DeleteInvoice(invoice);
            _invoiceRepo.SaveChanges();

            return NoContent();
        }

    }
}
