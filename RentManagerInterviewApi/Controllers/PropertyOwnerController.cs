using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentManagerInterviewApi.Models.Entities;
using RentManagerInterviewApi.Repositories.Interfaces;

namespace RentManagerInterviewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyOwnerController : GenericController<PropertyOwner>
    {
        public PropertyOwnerController(IGenericRepository<PropertyOwner> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
