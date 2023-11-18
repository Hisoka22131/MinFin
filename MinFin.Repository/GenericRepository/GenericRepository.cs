using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MinFin.Repository.Models.Base;

namespace MinFin.Repository.GenericRepository;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : EntityBase, new()
{
    private readonly DbContext _context;
    private DbSet<TEntity> DbSet => _context.Set<TEntity>();

    protected GenericRepository(DbContext context) =>
        _context = context ?? throw new ArgumentNullException(nameof(context));

    public virtual async Task InsertAsync(TEntity entity)
    {
        var entityExists = await DbSet.AnyAsync(q => q.Id == entity.Id);

        if (entityExists)
        {
            entity.UpdateDt = DateTime.Now;
            DbSet.Update(entity);
        }
        else
        {
            entity.CreateDt = entity.UpdateDt = DateTime.Now;
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
        if (entity == null) return;

        entity.UpdateDt = DateTime.Now;
        entity.IsDeleted = true;
        DbSet.Update(entity);
    }

    public virtual IEnumerable<TEntity> GetAllEntities() => DbSet.ToList();

    public virtual IEnumerable<TEntity> GetActualEntities() => DbSet.Where(q => !q.IsDeleted).ToList();

    public IEnumerable<TEntity> GetActualEntities(params Expression<Func<TEntity, object>>[] includes)
        => includes.Aggregate(DbSet.Where(q => !q.IsDeleted),
            (current, includeProperty) => current.Include(includeProperty));

    public IEnumerable<TEntity> GetEntities(params Expression<Func<TEntity, object>>[] includes)
        => includes.Aggregate(DbSet.Where(q => true), (current, includeProperty) => current.Include(includeProperty));

    public async Task<TEntity?> GetEntityAsync(int id) => await DbSet.FindAsync(id);

    public async Task<TEntity?> GetEntityAsync(int id, params Expression<Func<TEntity, object>>[] includes)
    {
        var entity = await DbSet.FindAsync(id);

        if (entity == null) return null;

        foreach (var include in includes)
        {
            await _context.Entry(entity).Reference(include!).LoadAsync();
        }

        return entity;
    }
    
    public async Task<bool> AllAsync(Expression<Func<TEntity, bool>> predicate) => await DbSet.AllAsync(predicate);

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate) => await DbSet.AnyAsync(predicate);
}

