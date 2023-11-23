using Microsoft.AspNetCore.Mvc;
using MinFin.Web.Services.Interfaces;

namespace MinFin.Web.Controllers;

[ApiController]
[Route("api/connect")]
public class SqlAdoConnectionController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly ISqlConnectionService _sqlConnectionService;

    public SqlAdoConnectionController(IConfiguration configuration, ISqlConnectionService sqlConnectionService)
    {
        _configuration = configuration;
        _sqlConnectionService = sqlConnectionService;
    }

    [HttpGet]
    [Route("rest/get-roles")]
    public async Task<IActionResult> ConnectToRestDb()
    {
        var connectionString = _configuration.GetConnectionString("RestDbConnectionString");

        var objList = await _sqlConnectionService.ExecuteReaderConnect(connectionString!, "SELECT * FROM Roles");
        
        return new ObjectResult(objList);
    }
}