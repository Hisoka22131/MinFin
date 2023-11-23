using Microsoft.AspNetCore.Mvc;
using MinFin.DB.Domain;
using MinFin.Parse.Interfaces;
using MinFin.UoW;
using MinFin.UoW.CustomRepository.UserRepo;
using MinFin.Web.Integration.User;

namespace MinFin.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CsvController : ControllerBase
{
    private readonly ICsvService _csvService;

    private readonly IUserRepository _userRepository;

    public CsvController(ICsvService csvService, IUnitOfWork unitOfWork)
    {
        _csvService = csvService;
        _userRepository = unitOfWork.UserRepository;
    }

    [HttpGet("users")]
    public async Task<IActionResult> GetUsers()
    {
        var csvContent = await _csvService.CreateData<UserIntGetDto, User>(_userRepository.GetActualEntities());

        var contentResult = new ContentResult
        {
            Content = csvContent,
            ContentType = "text/csv; charset=utf-8",
            StatusCode = 200
        };

        return contentResult;
    }

    [HttpPost("users")]
    public async Task PostUsers([FromBody] List<UserIntPutDto> request)
    {
        try
        {
            var users = _csvService.UploadData<User, UserIntPutDto>(request);

            // дальнейшая обработка юзеров
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing XML data: {ex.Message}");
        }
    }
}