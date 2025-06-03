using System.Linq.Expressions;
using Persistence.Models;

namespace Persistence.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<RepositoryResult<TResult>> AddAsync<TResult>(TEntity entity);
        Task<RepositoryResult> AlreadyExistAsync(Expression<Func<TEntity, bool>> expression);
        Task<RepositoryResult<TResult>> DeleteAsync<TResult>(TEntity entity);
        Task<RepositoryResult<IEnumerable<TEntity>>> GetAllAsync();
        Task<RepositoryResult<TEntity?>> GetAsync(Expression<Func<TEntity, bool>> expression);
        Task<RepositoryResult<TResult>> UpdateAsync<TResult>(TEntity entity);
    }
}