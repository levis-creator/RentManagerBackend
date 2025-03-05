using Microsoft.EntityFrameworkCore;
using RentManagerInterviewApi.Data;
using RentManagerInterviewApi.Models.Dtos.Tenant;
using RentManagerInterviewApi.Models.Entities;
using RentManagerInterviewApi.Repositories.Interfaces;

namespace RentManagerInterviewApi.Repositories
{
    public class TenantRepository : GenericRepository<Tenant>, ITenantRepository
    {
        public TenantRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<TenantDisplayDto>> GetSummaryAsync()
        {
            var tenants = await _context.Tenants
                .Include(t => t.Unit)
                .ThenInclude(u => u!.Apartment)
                .Select(t => new TenantDisplayDto
                {
                    Id = t.Id,
                    FullName = t.FullName,
                    Email = t.Email,
                    Phone = t.Phone,
                    UnitName = t.Unit != null ? t.Unit.UnitNumber : "N/A", // Use "N/A" if Unit is null
                    ApartmentName = t.Unit != null && t.Unit.Apartment != null ? t.Unit.Apartment.ApartmentName : "N/A" // Use "N/A" if Apartment is null
                })
                .ToListAsync();

            return tenants;
        }

        public async Task CreateTenantAsync(TenantInputDto tenantDto)
        {
            var tenant = new Tenant
            {
                FullName = tenantDto.FullName,
                Email = tenantDto.Email,
                Phone = tenantDto.Phone,
                UnitId = tenantDto.UnitId
            };

            // Add the tenant
            _context.Entry(tenant).State = EntityState.Added;
            await _dbSet.AddAsync(tenant);

        }

        public async Task<Tenant?> GetTenantByIdAsync(int id)
        {
            return await _context.Tenants.FindAsync(id);
        }

    }
}