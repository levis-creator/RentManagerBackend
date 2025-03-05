using Microsoft.AspNetCore.Mvc;
using RentManagerInterviewApi.Models.Dtos.Unit;
using RentManagerInterviewApi.Models.Entities;
using RentManagerInterviewApi.Repositories.Interfaces;

namespace RentManagerInterviewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : GenericController<Unit>
    {
        private readonly IUnitRepository _unitrepository;
        public UnitController(IGenericRepository<Unit> repository, IUnitOfWork unitOfWork, IUnitRepository unitRepository) : base(repository, unitOfWork)
        {
            _unitrepository = unitRepository;
        }
        [HttpGet("summary")]
        public async Task<ActionResult<List<UnitDisplayDto>>> GetSummary()
        {
            var units = await _unitrepository.GetSummaryAsync();
            return Ok(units);
        }
        [HttpGet("available")]
        public async Task<ActionResult<List<UnitDisplayDto>>> GetAvailableUnit()
        {
            var units = await _unitrepository.GetAvailableUnitAsync();
            return Ok(units);
        }

    }
}
