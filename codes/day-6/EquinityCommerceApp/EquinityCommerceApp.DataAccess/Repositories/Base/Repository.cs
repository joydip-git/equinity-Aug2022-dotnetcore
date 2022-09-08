using EquinityCommerceApp.Core.Entities.Base;
using EquinityCommerceApp.Core.Repositories.Base;
using EquinityCommerceApp.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EquinityCommerceApp.DataAccess.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly EquinityAppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(EquinityAppDbContext context)
        {
            _context = context??throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IReadOnlyList<T>> DeleteRangeAsync(IReadOnlyList<T> values)
        {
            _dbSet.RemoveRange(values);
            await _context.SaveChangesAsync();
            return values;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync<T>(t=>t.Id==id);
        }

        public async Task<IReadOnlyList<T>> SearchAsync(Expression<Func<T, bool>> predicate)
        {
           return await _dbSet.Where(predicate).ToListAsync();
        }
    }
}
