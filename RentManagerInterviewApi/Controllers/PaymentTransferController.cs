using Microsoft.AspNetCore.Mvc;
using RentManagerInterviewApi.Models.Dtos.PaymentTransfer;
using RentManagerInterviewApi.Models.Entities;
using RentManagerInterviewApi.Repositories.Interfaces;

namespace RentManagerInterviewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTransferController : GenericController<PaymentTransfer>
    {
        private readonly IPaymentTransferRepository _paymentTransferRepository;
        public PaymentTransferController(IGenericRepository<PaymentTransfer> repository, IUnitOfWork unitOfWork, IPaymentTransferRepository paymentTransferRepository) : base(repository, unitOfWork)
        {
            _paymentTransferRepository = paymentTransferRepository;
        }
        [HttpGet("summary")]
        public async Task<ActionResult<List<PaymentTransferDisplayDto>>> GetSummary()
        {
            var paymentTransfers = await _paymentTransferRepository.GetSummaryAsync();
            return Ok(paymentTransfers);
        }
    }
}
