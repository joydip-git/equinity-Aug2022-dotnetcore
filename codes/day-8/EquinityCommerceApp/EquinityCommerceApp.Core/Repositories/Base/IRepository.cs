using EquinityCommerceApp.Core.Entities.Base;
using System.Linq.Expressions;

namespace EquinityCommerceApp.Core.Repositories.Base
{
    public interface IRepository<T> where T : Entity
    {
        Task<IReadOnlyList<T>> GetAllAsync(string? includeProperties = null);
        Task<IReadOnlyList<T>> SearchAsync(Expression<Func<T, bool>> predicate, string? includeProperties = null);
        Task<T> GetByIdAsync(int id, string? includeProperties = null);
        Task<T> AddAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<IReadOnlyList<T>> DeleteRangeAsync(IReadOnlyList<T> values);
    }
}
