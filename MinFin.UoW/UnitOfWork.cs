using MinFin.DB.Context;
using MinFin.UoW.CustomRepository.UserRepo;

namespace MinFin.UoW;

public class UnitOfWork : IUnitOfWork
{
    private readonly MinFinDBContext _dbContext;
    public IUserRepository UserRepository { get; set; }

    public UnitOfWork(MinFinDBContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentException(null, nameof(dbContext));
        UserRepository = new UserRepository(_dbContext);
    }
    
    public int Save() => _dbContext.SaveChanges();
    
    public void Dispose() => _dbContext.Dispose();
}