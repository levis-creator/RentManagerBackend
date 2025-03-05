using Microsoft.AspNetCore.Mvc;
using RentManagerInterviewApi.Models.Dtos.LeaseAgreement;
using RentManagerInterviewApi.Models.Dtos.Payment;
using RentManagerInterviewApi.Models.Entities;
using RentManagerInterviewApi.Repositories;
using RentManagerInterviewApi.Repositories.Interfaces;

namespace RentManagerInterviewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : GenericController<Payment>
    {
        private IPaymentRepository paymentRepository;
        public PaymentController(IGenericRepository<Payment> repository, IUnitOfWork unitOfWork, IPaymentRepository _paymentRepository) : base(repository, unitOfWork)
        {
            paymentRepository = _paymentRepository;
        }

        [HttpGet("summary")]
        public async Task<ActionResult<IEnumerable<PaymentDisplayDto>>> GetAllSummary([FromQuery] DateOnly? startDate = null, [FromQuery] DateOnly? endDate = null)
        {
            try
            {
                // Fetch data with optional filters
                var entities = await paymentRepository.GetAllSummaryAsync(startDate, endDate);

                // Always return data, even if empty list
                return Ok(entities);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

    }
}
