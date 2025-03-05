using RentManagerInterviewApi.Models.Dtos.Invoice;
using RentManagerInterviewApi.Models.Entities;

namespace RentManagerInterviewApi.Repositories.Interfaces
{
    public interface IInvoiceRepository: IGenericRepository<Invoice>
    {
        Task<List<InvoiceDisplayDto>> GetAllSummaryAsync();
        Task<List<InvoiceArrears>> GetRentArrearsAsync();
    }
}
