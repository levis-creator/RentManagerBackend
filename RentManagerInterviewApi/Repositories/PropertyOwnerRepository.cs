using RentManagerInterviewApi.Data;
using RentManagerInterviewApi.Models.Entities;
using RentManagerInterviewApi.Repositories.Interfaces;

namespace RentManagerInterviewApi.Repositories
{
    public class PropertyOwnerRepository : GenericRepository<Invoice>, IPropertyOwnerRepository
    {
        public PropertyOwnerRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
