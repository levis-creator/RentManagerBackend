using Microsoft.AspNetCore.Mvc;
using RentManagerInterviewApi.Models.Dtos.LeaseAgreement;
using RentManagerInterviewApi.Models.Entities;
using RentManagerInterviewApi.Repositories.Interfaces;

namespace RentManagerInterviewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaseAgreementController : GenericController<LeaseAgreement>
    {
        private readonly ILeaseAgreementRepository leaseAgreementRepository;
        public LeaseAgreementController(IGenericRepository<LeaseAgreement> repository, IUnitOfWork unitOfWork, ILeaseAgreementRepository _leaseAgreementRepository) : base(repository, unitOfWork)
        {
            leaseAgreementRepository = _leaseAgreementRepository;
        }
        [HttpGet("summary")]
        public async Task<ActionResult<IEnumerable<LeaseAgreementDisplayDto>>> GetAllSummary()
        {
            var entities = await leaseAgreementRepository.GetAllDtoAsync();
            return Ok(entities);
        }
    }
}
