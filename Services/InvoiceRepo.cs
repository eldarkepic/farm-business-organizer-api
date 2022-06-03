using farma_api.Data;
using farma_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Services
{
    public class InvoiceRepo : IInvoiceRepo
    {
        private readonly MyContext _context;
        private readonly IPartnerRepo _partnerRepo;
        private readonly IProductVariationRepo _variationRepo;

        public InvoiceRepo(MyContext context, IPartnerRepo partnerRepo, IProductVariationRepo variationRepo)
        {
            _context = context;
            _partnerRepo = partnerRepo;
            _variationRepo = variationRepo;

        }
        public void CreateInvoice(int companyID, bool type, int partnerId, Invoice invoice, ICollection<ProductVariation> variation)
        {
            var partner = _partnerRepo.GetPartnerById(companyID, partnerId);
            partner.Invoices.Add(invoice);

   

            if (type)
            {
                _variationRepo.CreateVariationForInvoice(companyID, variation);
            }
            //else
            //{
            //     _variationRepo.UpdateProductVariation(variation);
            //}
            
        }

        public void DeleteInvoice(Invoice invoice)
        {
            _context.Invoices.Remove(invoice);
        }

        public IEnumerable<Invoice> GetAllInvoices()
        {
            return _context.Invoices.OrderBy(c => c.Number).ToList();
        }

        public Invoice GetInvoiceById(int invoiceId)
        {
            return _context.Invoices.Include(c => c.Items).Where(p => p.InvoiceId == invoiceId).FirstOrDefault();
        }

        public bool PartnerExists(int partnerId)
        {
            return _context.Partners.Any(c => c.PartnerId == partnerId);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateInvoice(Invoice invoice)
        {
            
        }
    }
}
