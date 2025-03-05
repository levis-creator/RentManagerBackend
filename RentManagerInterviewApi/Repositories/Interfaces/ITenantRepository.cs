using RentManagerInterviewApi.Models.Dtos.Tenant;
using RentManagerInterviewApi.Models.Entities;

namespace RentManagerInterviewApi.Repositories.Interfaces
{
    public interface ITenantRepository: IGenericRepository<Tenant>
    {
        Task<List<TenantDisplayDto>> GetSummaryAsync();
        Task CreateTenantAsync(TenantInputDto tenantDtos);
       Task<Tenant?> GetTenantByIdAsync(int id);

    }
}
