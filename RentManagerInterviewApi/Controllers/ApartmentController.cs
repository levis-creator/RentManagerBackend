using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentManagerInterviewApi.Models.Entities;
using RentManagerInterviewApi.Repositories.Interfaces;

namespace RentManagerInterviewApi.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : GenericController<Apartment>
    {
        public ApartmentController(IGenericRepository<Apartment> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
