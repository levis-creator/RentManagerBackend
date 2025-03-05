using Microsoft.EntityFrameworkCore;
using RentManagerInterviewApi.Data;
using RentManagerInterviewApi.Models.Dtos.Payment;
using RentManagerInterviewApi.Models.Entities;
using RentManagerInterviewApi.Repositories.Interfaces;

namespace RentManagerInterviewApi.Repositories
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<List<PaymentDisplayDto>> GetAllSummaryAsync(DateOnly? startDate = null, DateOnly? endDate = null)
        {
            // Start by querying all payments with necessary includes
            var query = _context.Payments
                .Include(p => p.Invoice)
                .ThenInclude(i => i.LeaseAgreement)
                .ThenInclude(l => l.Unit)
                .Select(p => new PaymentDisplayDto
                {
                    Id = p.Id,
                    InvoiceId = p.InvoiceId,
                    AmountPaid = p.AmountPaid,
                    PaymentDate = p.PaymentDate,
                    PaymentMethod = p.PaymentMethod,
                    TransactionId = p.TransactionId,
                    UnitName = p.Invoice.LeaseAgreement.Unit != null ? p.Invoice.LeaseAgreement.Unit.UnitNumber : "N/A"
                })
                .AsQueryable();

            // Apply filters only if dates are provided
            if (startDate.HasValue && endDate.HasValue)
            {
                query = query.Where(p => p.PaymentDate >= startDate.Value && p.PaymentDate <= endDate.Value);
            }
            else if (startDate.HasValue)
            {
                query = query.Where(p => p.PaymentDate >= startDate.Value);
            }
            else if (endDate.HasValue)
            {
                query = query.Where(p => p.PaymentDate <= endDate.Value);
            }

            // Execute the query
            var payments = await query.ToListAsync();

            return payments;
        }

    }
}
