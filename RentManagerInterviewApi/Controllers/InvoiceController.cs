using Microsoft.AspNetCore.Mvc;
using RentManagerInterviewApi.Models.Dtos.Invoice;
using RentManagerInterviewApi.Models.Dtos.LeaseAgreement;
using RentManagerInterviewApi.Models.Entities;
using RentManagerInterviewApi.Repositories;
using RentManagerInterviewApi.Repositories.Interfaces;

namespace RentManagerInterviewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : GenericController<Invoice>
    {
        private  IInvoiceRepository invoiceRepository;
        public InvoiceController(IGenericRepository<Invoice> repository, IUnitOfWork unitOfWork, IInvoiceRepository _invoiceRepository) : base(repository, unitOfWork)
        {
            invoiceRepository = _invoiceRepository;
        }
        [HttpGet("summary")]
        public async Task<ActionResult<IEnumerable<InvoiceDisplayDto>>> GetAllSummary()
        {
            var entities = await invoiceRepository.GetAllSummaryAsync();
            return Ok(entities);
        }
        [HttpGet("arrears")]
        public async Task<IActionResult> GetRentArrears()
        {
            var arrears = await invoiceRepository.GetRentArrearsAsync();
            return Ok(arrears);
        }
    }
}
