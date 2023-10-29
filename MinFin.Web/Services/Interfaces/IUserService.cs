using MinFin.DB.Domain;
using MinFin.Web.Dto.User;
using MinFin.Web.Services.Base;

namespace MinFin.Web.Services.Interfaces;

public interface IUserService : IBaseService<User, UserPostDto, UserPutDto, UserListDto>
{
}