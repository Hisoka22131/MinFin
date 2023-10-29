using Microsoft.AspNetCore.Mvc;
using MinFin.Web.Dto.User;
using MinFin.Web.Services.Interfaces;

namespace MinFin.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers() => Ok(await _userService.GetEntities());
    
    [HttpGet]
    [Route("get-users/{id:int}")]
    public async Task<IActionResult> GetUsers(int id) => Ok(await _userService.GetEntity(id));

    [HttpPut]
    public async Task UpdateUser(UserPutDto dto) => await _userService.PutEntity(dto);
    
    [HttpPost]
    public async Task CreateUser(UserPostDto dto) => await _userService.PostEntity(dto);
    
    
}