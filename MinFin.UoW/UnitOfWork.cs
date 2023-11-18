using MinFin.DB.Context;
using MinFin.UoW.CustomRepository.UserRepo;

namespace MinFin.UoW;

public class UnitOfWork : IUnitOfWork
{
    private readonly MinFinDbContext _dbContext;
    public IUserRepository UserRepository { get; set; }
    
    public UnitOfWork(MinFinDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentException(null, nameof(dbContext));
        UserRepository = new UserRepository(_dbContext);
    }
    
    public async Task CommitAsync() => await _dbContext.SaveChangesAsync();

    public Task Rollback()
    {
        throw new NotImplementedException();
    }
    
    public void Dispose() => _dbContext.Dispose();
}