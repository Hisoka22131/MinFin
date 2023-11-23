using AutoMapper;
using MinFin.Repository.GenericRepository;
using MinFin.Repository.Models.Base;
using MinFin.Web.Dto.Base;

namespace MinFin.Web.Services.Base;

public abstract class AbstractEntityService<TEntity, TPostDto, TPutDto, TListDto> : IBaseService<TEntity, TPostDto, TPutDto, TListDto>
    where TEntity : EntityBase, new()
    where TPutDto : EntityPutDto, new()
    where TPostDto : EntityPostDto, new()
    where TListDto : EntityListDto, new()
{
    private readonly IMapper _mapper;

    private readonly IGenericRepository<TEntity> _repository;

    public AbstractEntityService(IMapper mapper, IGenericRepository<TEntity> repository)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public virtual async Task<IEnumerable<TListDto>> GetEntities() => _mapper.Map<List<TListDto>>(_repository.GetActualEntities());

    public virtual async Task<TPutDto> GetEntity(int id)
    {
        return id == 0 ? new TPutDto() : _mapper.Map<TPutDto>(await _repository.GetEntityAsync(id));
    }

    public virtual async Task PostEntity(TPostDto dto)
    {
        var entity = _mapper.Map<TEntity>(dto);
        
        await _repository.InsertAsync(entity);
    }

    public virtual async Task PutEntity(TPutDto dto)
    {
        var entity = await _repository.GetEntityAsync(dto.Id);
        
        if (entity == null) return;

        entity = _mapper.Map<TEntity>(dto);
        
        await _repository.InsertAsync(entity);
    }

    public virtual async Task PostDelete(int id) => await _repository.RemoveAsync(id);
}