using Microsoft.EntityFrameworkCore;
using RentManagerInterviewApi.Data;
using RentManagerInterviewApi.Helpers;
using RentManagerInterviewApi.Models.Dtos.Unit;
using RentManagerInterviewApi.Models.Entities;
using RentManagerInterviewApi.Repositories.Interfaces;

namespace RentManagerInterviewApi.Repositories
{
    public class UnitRepository : GenericRepository<Unit>, IUnitRepository
    {
        public UnitRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<UnitDisplayDto>> GetSummaryAsync()
        {
            // Retrieve units from the database and map them to UnitDisplayDto
            var units = await _context.Units
                .Include(u => u.Apartment)
                .Include(u => u.Tenant)
                .Select(u => new UnitDisplayDto
                {
                    Id = u.Id,
                    UnitNumber = u.UnitNumber,
                    Status = u.Tenant != null ? UnitStatus.Occupied : UnitStatus.Available,
                    StatusDescription = EnumHelper.GetDescription(u.Tenant != null ? UnitStatus.Occupied : UnitStatus.Available),
                    ApartmentName = u.Apartment != null ? u.Apartment.ApartmentName : "N/A"
                })
                .ToListAsync();

            return units;
        }

        public async Task<List<UnitDisplayDto>> GetAvailableUnitAsync()
        {
            // Retrieve only available units (units without tenants)
            var availableUnits = await _context.Units
                .Include(u => u.Apartment)
                .Where(u => u.Tenant == null) // Filter units with no tenants
                .Select(u => new UnitDisplayDto
                {
                    Id = u.Id,
                    UnitNumber = u.UnitNumber,
                    Status = UnitStatus.Available,
                    StatusDescription = EnumHelper.GetDescription(UnitStatus.Available),
                    ApartmentName = u.Apartment != null ? u.Apartment.ApartmentName : "N/A"
                })
                .ToListAsync();

            return availableUnits;
        }
    }
}
