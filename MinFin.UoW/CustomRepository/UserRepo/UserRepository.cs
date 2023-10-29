using Microsoft.EntityFrameworkCore;
using MinFin.DB.Domain;
using MinFin.Repository.GenericRepository;

namespace MinFin.UoW.CustomRepository.UserRepo;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(DbContext context) : base(context)
    {
    }
}