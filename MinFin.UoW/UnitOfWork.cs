using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MinFin.DB.Context;
using MinFin.UoW.CustomRepository.UserRepo;

namespace MinFin.UoW;

public class UnitOfWork : IUnitOfWork
{
    private readonly MinFinDbContext _dbContext;
    private readonly ChangeTracker _changeTracker;
    
    public IUserRepository UserRepository { get; set; }
    
    public UnitOfWork(MinFinDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentException(null, nameof(dbContext));
        UserRepository = new UserRepository(_dbContext);
        _changeTracker = dbContext.ChangeTracker;
    }
    
    public async Task CommitAsync() => await _dbContext.SaveChangesAsync();

    public async Task Rollback()
    {
        foreach (var entry in _changeTracker.Entries().ToList())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.State = EntityState.Detached;
                    break;
                case EntityState.Modified:
                    await entry.ReloadAsync();
                    break;
                case EntityState.Deleted:
                    entry.State = EntityState.Unchanged;
                    break;
            }
        }
    }
    
    public void Dispose() => _dbContext.Dispose();
}