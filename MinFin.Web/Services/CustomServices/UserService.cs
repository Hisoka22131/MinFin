using MinFin.UoW;
using MinFin.UoW.CustomRepository.UserRepo;
using MinFin.Web.Dto.User;
using MinFin.Web.Services.Interfaces;

namespace MinFin.Web.Services.CustomServices;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    
    private IUserRepository UserRepo => _unitOfWork.UserRepository;
    
    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public Task<IEnumerable<UserListDto>> GetEntities()
    {
        throw new NotImplementedException();
    }

    public Task<UserPutDto> GetEntity(int id)
    {
        throw new NotImplementedException();
    }

    public Task PostEntity(UserPostDto dto)
    {
        throw new NotImplementedException();
    }

    public Task PutEntity(UserPutDto dto)
    {
        throw new NotImplementedException();
    }

    public Task PostDelete(int id)
    {
        throw new NotImplementedException();
    }
}