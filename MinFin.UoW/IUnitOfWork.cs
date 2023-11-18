using MinFin.UoW.CustomRepository.UserRepo;

namespace MinFin.UoW;

public interface IUnitOfWork : IDisposable
{
    Task CommitAsync();
    Task Rollback();
    IUserRepository UserRepository { get; set; }
}