using RentManagerInterviewApi.Models.Dtos.Payment;
using RentManagerInterviewApi.Models.Entities;

namespace RentManagerInterviewApi.Repositories.Interfaces
{
    public interface IPaymentRepository: IGenericRepository<Payment>
    {
        Task<List<PaymentDisplayDto>> GetAllSummaryAsync(DateOnly? startDate = null, DateOnly? endDate = null);
    }
}
