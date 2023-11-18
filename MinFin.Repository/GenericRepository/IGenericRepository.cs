using System.Linq.Expressions;
using MinFin.Repository.Models.Base;

namespace MinFin.Repository.GenericRepository;

public interface IGenericRepository<TEntity> where TEntity : EntityBase
{
    Task InsertAsync(TEntity entity);
    Task RemoveAsync(int id);
    Task RemoveAsync(TEntity entity);
    Task<TEntity?> GetEntityAsync(int id);
    Task<TEntity?> GetEntityAsync(int id, params Expression<Func<TEntity, object>>[] includes);
    IEnumerable<TEntity> GetEntities(params Expression<Func<TEntity, object>>[] includes);
    IEnumerable<TEntity> GetActualEntities();
    IEnumerable<TEntity> GetActualEntities(params Expression<Func<TEntity, object>>[] includes);
    Task<bool> AllAsync(Expression<Func<TEntity, bool>> predicate);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
}
