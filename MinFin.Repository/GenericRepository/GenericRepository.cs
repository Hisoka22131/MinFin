using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MinFin.Repository.Models.Base;

namespace MinFin.Repository.GenericRepository;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : EntityBase
{
    private readonly DbContext _context;
    private DbSet<TEntity> DbSet => _context.Set<TEntity>();

    protected GenericRepository(DbContext context) =>
        _context = context ?? throw new ArgumentNullException(nameof(context));
    
    public virtual async Task Insert(TEntity entity)
    {
        if (await DbSet.AnyAsync(q => q.Id == entity.Id))
        {
            entity.UpdateDt = DateTime.Now;
            DbSet.Update(entity);
        }
        else
        {
            entity.CreateDt = DateTime.Now;
            entity.UpdateDt = DateTime.Now;
            await DbSet.AddAsync(entity);
        }
    }

    public virtual async Task RemoveAsync(TEntity entity)
    {
        entity.UpdateDt = DateTime.Now;
        entity.IsDeleted = true;
        DbSet.Update(entity);
    }

    public virtual async Task RemoveAsync(int id)
    {
        var entity = await DbSet.FindAsync(id);
        entity.UpdateDt = DateTime.Now;
        entity.IsDeleted = true;
        DbSet.Update(entity);
    }

    public async Task<bool> AllAsync(Expression<Func<TEntity, bool>> predicate) => await DbSet.AllAsync(predicate);
    
    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate) => await DbSet.AnyAsync(predicate);

    public virtual IEnumerable<TEntity> GetAllActualEntities() => DbSet.Where(q => !q.IsDeleted).ToList();

    public IEnumerable<TEntity> GetAllActualEntitiesByInclude(params Expression<Func<TEntity, object>>[] includes)
        => includes.Aggregate(DbSet.Where(q => !q.IsDeleted), (current, includeProperty) => current.Include(includeProperty));
    
    public virtual IEnumerable<TEntity> GetAllEntities() => DbSet.ToList();

    public IEnumerable<TEntity> GetAllEntitiesByInclude(params Expression<Func<TEntity, object>>[] includes)
        => includes.Aggregate(DbSet.Where(q => true), (current, includeProperty) => current.Include(includeProperty));

    public async Task<TEntity> GetEntityAsync(int id) => await _context.FindAsync<TEntity>(id);

    public async Task<TEntity> GetEntityByIncludeAsync(Expression<Func<TEntity, bool>> predicate,
        params Expression<Func<TEntity, object>>[] includes) =>
        await includes.Aggregate(DbSet.Where(predicate), (current, includeProperty) => current.Include(includeProperty))
            .FirstOrDefaultAsync();
}