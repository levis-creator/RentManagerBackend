using Microsoft.EntityFrameworkCore;
using RentManagerInterviewApi.Data;
using RentManagerInterviewApi.Helpers;
using RentManagerInterviewApi.Models.Dtos.Invoice;
using RentManagerInterviewApi.Models.Entities;
using RentManagerInterviewApi.Repositories.Interfaces;

namespace RentManagerInterviewApi.Repositories
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<List<InvoiceDisplayDto>> GetAllSummaryAsync()
        {
            var invoices = await _context.Invoices
                .Include(i => i.LeaseAgreement)
                    .ThenInclude(la => la.Tenant)
                .Select(i => new InvoiceDisplayDto
                {
                    Id = i.Id,
                    TenantName = i.LeaseAgreement.Tenant != null ? i.LeaseAgreement.Tenant.FullName : "Unknown Tenant",
                    AmountDue = i.AmountDue,
                    Status = i.Status,
                    StatusDescription = EnumHelper.GetDescription(i.Status)

                })
                .ToListAsync();

            return invoices!;
        }
        public async Task<List<InvoiceArrears>> GetRentArrearsAsync()
        {
            return await _context.Invoices
                .Include(i => i.LeaseAgreement)
                .ThenInclude(l => l.Tenant)
                .Include(i => i.Payments)
                .Include(i => i.LeaseAgreement.Unit)
                .Where(i => i.Status == InvoiceStatus.Pending || i.Payments.Sum(p => p.AmountPaid) < i.AmountDue || i.Payments.Sum(p => p.AmountPaid) > i.AmountDue) // Include Overpaid Invoices
                  .Select(i => new InvoiceArrears
                  {
                      TenantName = i.LeaseAgreement.Tenant != null ? i.LeaseAgreement.Tenant.FullName : "N/A",
                      ApartmentName = i.LeaseAgreement.Unit != null ? i.LeaseAgreement.Unit.Apartment != null ? i.LeaseAgreement.Unit.Apartment.ApartmentName : "N/A" : "N/A",
                      UnitName = i.LeaseAgreement.Unit != null ? i.LeaseAgreement.Unit.UnitNumber : "N/A",
                      AmountDue = i.AmountDue,
                      AmountPaid = i.Payments.Sum(p => p.AmountPaid),
                      BalanceDue = i.Payments.Sum(p => p.AmountPaid) >= i.AmountDue ? 0 : i.AmountDue - i.Payments.Sum(p => p.AmountPaid),
                      OverpaidAmount = i.Payments.Sum(p => p.AmountPaid) > i.AmountDue ? i.Payments.Sum(p => p.AmountPaid) - i.AmountDue : 0,
                      PaymentStatus = i.Payments.Sum(p => p.AmountPaid) > i.AmountDue ? "Overpaid" :
                            i.Payments.Sum(p => p.AmountPaid) == i.AmountDue ? "Fully Paid" :
                            "Arrears"
                  })
                .ToListAsync();
        }



    }
}
