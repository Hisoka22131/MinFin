using MinFin.Repository.Models.Base;
using MinFin.Web.Dto.Base;

namespace MinFin.Web.Services.Base;

public interface IBaseService<TEntity, TPostDto, TPutDto, TListDto>
    where TEntity : EntityBase
    where TPutDto : EntityPutDto
    where TPostDto : EntityPostDto
    where TListDto : EntityListDto
{
    /// <summary>
    /// Выводим список данных
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<TListDto>> GetEntities();

    /// <summary>
    /// Получаем сущность
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<TPutDto> GetEntity(int id);

    /// <summary>
    /// Создаем сущность
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task PostEntity(TPostDto dto);

    /// <summary>
    /// Обновляем сущность
    /// </summary>
    /// <returns></returns>
    Task PutEntity(TPutDto dto);

    /// <summary>
    /// Удаляем сущность
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task PostDelete(int id);
}