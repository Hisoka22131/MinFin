using Microsoft.AspNetCore.Mvc;
using MinFin.Repository.Models.Base;
using MinFin.Web.Dto.Base;
using MinFin.Web.Services.Base;

namespace MinFin.Web.Controllers.Base;

[ApiController]
[Route("api/[controller]")]
public abstract class AbstractEntityController<TEntity, TPostDto, TPutDto, TListDto> : ControllerBase
    where TEntity : EntityBase
    where TPutDto : EntityPutDto
    where TPostDto : EntityPostDto
    where TListDto : EntityListDto
{
    private readonly IBaseService<TEntity, TPostDto, TPutDto, TListDto> _baseService;

    public AbstractEntityController(IBaseService<TEntity, TPostDto, TPutDto, TListDto> baseService) => _baseService = baseService;

    [HttpGet]
    public virtual async  Task<IActionResult> Get() => new OkObjectResult(await _baseService.GetEntities());

    [HttpGet]
    [Route("{id:int}")]
    public virtual async Task<IActionResult> GetUsers(int id) => new OkObjectResult(await _baseService.GetEntity(id));

    [HttpPut]
    public virtual async Task Put(TPutDto dto) => await _baseService.PutEntity(dto);

    [HttpPost]
    public virtual async Task Post(TPostDto dto) => await _baseService.PostEntity(dto);

    [HttpDelete]
    public virtual async Task Delete(EntityDto dto) => await _baseService.PostDelete(dto.Id);
}