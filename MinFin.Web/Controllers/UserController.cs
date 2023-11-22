using Microsoft.AspNetCore.Mvc;
using MinFin.DB.Domain;
using MinFin.Web.Controllers.Base;
using MinFin.Web.Dto.User;
using MinFin.Web.Services.Interfaces;

namespace MinFin.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : AbstractEntityController<User, UserPostDto, UserPutDto, UserListDto>
{
    public UserController(IUserService userService) : base(userService)
    {
    }
}