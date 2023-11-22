using MinFin.DB.Domain;
using MinFin.Repository.GenericRepository;

namespace MinFin.UoW.CustomRepository.UserRepo;

public interface IUserRepository : IGenericRepository<User>
{
}