using RentManagerInterviewApi.Models.Dtos.Unit;
using RentManagerInterviewApi.Models.Entities;

namespace RentManagerInterviewApi.Repositories.Interfaces
{
    public interface IUnitRepository : IGenericRepository<Unit>
    {
        Task<List<UnitDisplayDto>> GetSummaryAsync();
        Task<List<UnitDisplayDto>> GetAvailableUnitAsync();
    }
}
