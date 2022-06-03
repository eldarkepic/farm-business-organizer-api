using farma_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Services
{
    public interface IInvoiceRepo
    {
        IEnumerable<Invoice> GetAllInvoices();
        Invoice GetInvoiceById(int invoiceId);
        void CreateInvoice(int companyID, bool type, int partnerId, Invoice invoice, ICollection<ProductVariation> variation);
        void UpdateInvoice(Invoice invoice);
        void DeleteInvoice(Invoice invoice);
        bool PartnerExists(int partnerId);
        bool SaveChanges();
    }
}
