using MinFin.UoW.CustomRepository.UserRepo;

namespace MinFin.UoW;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; set; }
}