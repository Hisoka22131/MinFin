namespace MinFin.ParseService.Interfaces;

public interface IParseService
{
    /// <summary>
    /// Отправить данные в другую систему
    /// Обязательно прописывать маппинг
    /// </summary>
    /// <param name="models">Список объектов</param>
    /// <typeparam name="TResponseDto">Отправляемая модель</typeparam>
    /// <typeparam name="TModel">Исходная модель</typeparam>
    /// <returns></returns>
    Task<string?> CreateData<TResponseDto, TModel>(IEnumerable<TModel>? models);

    Task<IEnumerable<TEntity>?> UploadData<TEntity, TRequestDto>(IEnumerable<TRequestDto>? models);
}