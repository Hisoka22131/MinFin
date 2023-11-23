using Microsoft.AspNetCore.Mvc;
using MinFin.DB.Domain;
using MinFin.Parse.Interfaces;
using MinFin.UoW;
using MinFin.UoW.CustomRepository.UserRepo;
using MinFin.Web.Integration.User;

namespace MinFin.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class XmlController : ControllerBase
{
    private readonly IXmlService _xmlService;

    private readonly IUserRepository _userRepository;

    public XmlController(IXmlService xmlService, IUnitOfWork unitOfWork)
    {
        _xmlService = xmlService;
        _userRepository = unitOfWork.UserRepository;
    }

    [HttpGet("users")]
    public async Task<IActionResult> GetUsers()
    {
        var xmlContent = await _xmlService.CreateData<UserIntGetDto, User>(_userRepository.GetActualEntities());

        var contentResult = new ContentResult
        {
            Content = xmlContent,
            ContentType = "application/xml; charset=utf-8",
            StatusCode = 200
        };

        return contentResult;
    }

    [HttpPost("users")]
    public async Task PostUsers([FromBody] List<UserIntPutDto> request)
    {
        try
        {
            var users = _xmlService.UploadData<User, UserIntPutDto>(request);
            
            // дальнейшая обработка юзеров
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing XML data: {ex.Message}");
        }
    }
}