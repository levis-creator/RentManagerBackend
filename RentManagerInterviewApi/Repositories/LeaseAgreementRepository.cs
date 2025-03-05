using Microsoft.EntityFrameworkCore;
using RentManagerInterviewApi.Data;
using RentManagerInterviewApi.Helpers;
using RentManagerInterviewApi.Models.Dtos.LeaseAgreement;
using RentManagerInterviewApi.Models.Entities;
using RentManagerInterviewApi.Repositories.Interfaces;

namespace RentManagerInterviewApi.Repositories
{
    public class LeaseAgreementRepository : GenericRepository<LeaseAgreement>, ILeaseAgreementRepository
    {
        public LeaseAgreementRepository(ApplicationDbContext context) : base(context)
        {
        }
         public async Task<List<LeaseAgreementDisplayDto>> GetAllDtoAsync()
        {
            return await _context.LeaseAgreements
                .Include(l => l.Tenant)
                .Include(l => l.Unit)
                .Select(l => new LeaseAgreementDisplayDto
                {
                    Id = l.Id,
                    TenantName = l.Tenant != null ? l.Tenant.FullName : "N/A",
                    UnitId= l.Unit != null ? l.Unit.Id : null,
                    UnitNumber = l.Unit != null ? l.Unit.UnitNumber : "N/A",
                    StartDate = l.StartDate,
                    EndDate = l.EndDate,
                    RentAmount = l.RentAmount,
                    Status = l.Status,
                    StatusDescription = EnumHelper.GetDescription(l.Status!)

                })
                .ToListAsync();
        }

    }
}
