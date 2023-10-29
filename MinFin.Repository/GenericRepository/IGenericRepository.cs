using System.Linq.Expressions;
using MinFin.Repository.Models.Base;

namespace MinFin.Repository.GenericRepository;

public interface IGenericRepository<TEntity> where TEntity : EntityBase
{
    Task Insert(TEntity entity);
    Task RemoveAsync(int id);
    Task RemoveAsync(TEntity entity);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
    Task<bool> AllAsync(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity> GetEntityAsync(int id);
    Task<TEntity> GetEntityByIncludeAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
    IEnumerable<TEntity> GetAllEntities();
    IEnumerable<TEntity> GetAllEntitiesByInclude(params Expression<Func<TEntity, object>>[] includes);
    IEnumerable<TEntity> GetAllActualEntities();
    IEnumerable<TEntity> GetAllActualEntitiesByInclude(params Expression<Func<TEntity, object>>[] includes);
}