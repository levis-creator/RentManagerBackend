using Microsoft.AspNetCore.Mvc;
using RentManagerInterviewApi.Models.Dtos.Tenant;
using RentManagerInterviewApi.Models.Entities;
using RentManagerInterviewApi.Repositories.Interfaces;

namespace RentManagerInterviewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : GenericController<Tenant>
    {
        private readonly ITenantRepository tenantRepository;
        public TenantController(IGenericRepository<Tenant> repository, IUnitOfWork unitOfWork, ITenantRepository _tenantRepository) : base(repository, unitOfWork)
        {
            tenantRepository = _tenantRepository;
        }

        [HttpGet("summary")]
        public async Task<ActionResult<List<TenantDisplayDto>>> GetSummaryAsync()
        {
            var tenants = await tenantRepository.GetSummaryAsync();
            return Ok(tenants);
        }
       
    }
}
