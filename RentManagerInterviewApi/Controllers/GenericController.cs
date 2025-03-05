using Microsoft.AspNetCore.Mvc;
using RentManagerInterviewApi.Repositories.Interfaces;

namespace RentManagerInterviewApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenericController<T> : ControllerBase where T : class
    {
        protected readonly IGenericRepository<T> _repository;
        protected readonly IUnitOfWork _unitOfWork;

        public GenericController(IGenericRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        // GET: api/[controller]
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<T>>> GetAll()
        {
            var entities = await _repository.GetAllAsync();
            return Ok(entities);
        }

        // GET: api/[controller]/{id}
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<T>> GetById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }

        // POST: api/[controller]
        [HttpPost]
        public virtual async Task<IActionResult> Create([FromBody] T entity)
        {
            if (entity == null) return BadRequest();

            await _repository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = entity.GetType().GetProperty("Id")?.GetValue(entity) }, entity);
        }

        // PUT: api/[controller]/{id}
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(int id, [FromBody] T entity)
        {
            if (entity == null || !id.Equals(entity.GetType().GetProperty("Id")?.GetValue(entity)))
                return BadRequest();

            _repository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/[controller]/{id}
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return NotFound();

            _repository.Delete(entity);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}