using RentManagerInterviewApi.Models.Dtos.LeaseAgreement;
using RentManagerInterviewApi.Models.Entities;

namespace RentManagerInterviewApi.Repositories.Interfaces
{
    public interface ILeaseAgreementRepository:IGenericRepository<LeaseAgreement>
    {
        Task<List<LeaseAgreementDisplayDto>> GetAllDtoAsync();
    }
}
