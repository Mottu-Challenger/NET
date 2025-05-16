using Api.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure.Persistence.Repositories
{

    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly UserContext _context;
        protected readonly DbSet<T> _dbSet;
        private IRepository<T> _repositoryImplementation;

        public Repository(UserContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T?> GetByIdAsync(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Task<T> GetByIdAsync(Guid id)
        {
            return _repositoryImplementation.GetByIdAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task AddAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity) => _dbSet.Update(entity);

        public void Delete(T entity) => _dbSet.Remove(entity);
    }
    
}