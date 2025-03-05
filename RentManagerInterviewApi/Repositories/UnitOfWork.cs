using RentManagerInterviewApi.Data;
using RentManagerInterviewApi.Repositories.Interfaces;

namespace RentManagerInterviewApi.Repositories
{
    public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
    {
        private readonly ApplicationDbContext _context = context;

        private IPropertyOwnerRepository? ownerRepository;

        public IPropertyOwnerRepository PropertyOwner => ownerRepository ??= new PropertyOwnerRepository(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            throw new NotImplementedException();
        }
    }

}
