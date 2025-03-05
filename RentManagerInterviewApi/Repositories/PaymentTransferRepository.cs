using Microsoft.EntityFrameworkCore;
using RentManagerInterviewApi.Data;
using RentManagerInterviewApi.Models.Dtos.PaymentTransfer;
using RentManagerInterviewApi.Models.Entities;
using RentManagerInterviewApi.Repositories.Interfaces;

namespace RentManagerInterviewApi.Repositories
{
    public class PaymentTransferRepository : GenericRepository<PaymentTransfer>, IPaymentTransferRepository
    {
        public PaymentTransferRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<List<PaymentTransferDisplayDto>> GetSummaryAsync()
        {
            // Retrieve payment transfers from the database and map them to PaymentTransferDisplayDto
            var paymentTransfers = await _context.PaymentTransfers
                .Include(pt => pt.Tenant) // Include related Tenant data
                .Include(pt => pt.ToUnit) // Include related Unit data
                .Select(pt => new PaymentTransferDisplayDto
                {
                    Id = pt.Id,
                    TenantId = pt.TenantId,
                    TenantName = pt.Tenant != null ? pt.Tenant.FullName : string.Empty, // Safely access Tenant name
                    ToUnitId = pt.ToUnitId,
                    UnitNumber = pt.ToUnit != null ? pt.ToUnit.UnitNumber : string.Empty, // Safely access Unit number
                    TransferDate = pt.TransferDate
                })
                .ToListAsync();

            return paymentTransfers;
        }
    }
}
