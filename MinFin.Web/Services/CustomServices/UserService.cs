using AutoMapper;
using MinFin.DB.Domain;
using MinFin.UoW;
using MinFin.Web.Dto.User;
using MinFin.Web.Services.Base;
using MinFin.Web.Services.Interfaces;

namespace MinFin.Web.Services.CustomServices;

public class UserService : AbstractEntityService<User, UserPostDto, UserPutDto, UserListDto>, IUserService
{
    public UserService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork.UserRepository)
    {
    }
}