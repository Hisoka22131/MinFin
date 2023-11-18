namespace MinFin.ParseService.Interfaces;

public interface IParseService
{
    /// <summary>
    /// Отправить данные в другую систему
    /// </summary>
    /// <param name="models">Список объектов</param>
    /// <returns></returns>
    Task<string?> Send<TSendDto, TModel>(IEnumerable<TModel>? models)
        where TSendDto : class, new() where TModel : class;

    Task<TEntity?> ParseData<TEntity>(object data);
}