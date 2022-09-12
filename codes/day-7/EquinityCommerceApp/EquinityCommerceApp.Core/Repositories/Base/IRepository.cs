using EquinityCommerceApp.Core.Entities.Base;
using System.Linq.Expressions;

namespace EquinityCommerceApp.Core.Repositories.Base
{
    public interface IRepository<T> where T : Entity
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> SearchAsync(Expression<Func<T,bool>> predicate);
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<IReadOnlyList<T>> DeleteRangeAsync(IReadOnlyList<T> values);
    }
}
