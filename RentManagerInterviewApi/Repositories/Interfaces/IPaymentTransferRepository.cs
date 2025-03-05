using RentManagerInterviewApi.Models.Dtos.PaymentTransfer;
using RentManagerInterviewApi.Models.Entities;

namespace RentManagerInterviewApi.Repositories.Interfaces
{
    public interface IPaymentTransferRepository: IGenericRepository<PaymentTransfer>
    {
        Task<List<PaymentTransferDisplayDto>> GetSummaryAsync();
    }
}
