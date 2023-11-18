using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using MinFin.DB.Domain;
using MinFin.ParseService.Interfaces;
using MinFin.UoW;
using MinFin.UoW.CustomRepository.UserRepo;
using MinFin.Web.Dto.User;
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
    public async Task<IActionResult> GetUsers() => new ObjectResult(await _xmlService.Send<UserGetDto, User>(_userRepository.GetActualEntities()));

    [HttpPost("users")]
    public async Task PostUsers([FromBody] string xmlData)
    {
        try
        {
            var serializer = new XmlSerializer(typeof(List<UserPostDto>));
            using var reader = new StringReader(xmlData);
            
            var users = (List<UserPostDto>)serializer.Deserialize(reader)!;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing XML data: {ex.Message}");
        }
    }
}