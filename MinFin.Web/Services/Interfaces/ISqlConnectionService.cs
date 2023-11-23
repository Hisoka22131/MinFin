namespace MinFin.Web.Services.Interfaces;

public interface ISqlConnectionService
{
    /// <summary>
    /// Возврашает список данных
    /// </summary>
    /// <param name="connectionString">строка подключения</param>
    /// <param name="sqlExpression">команда(Select)</param>
    /// <returns></returns>
    Task<List<object>> ExecuteReaderConnect(string connectionString, string sqlExpression);

    /// <summary>
    /// Возврашает скалярное значение
    /// </summary>
    /// <param name="connectionString">строка подключения</param>
    /// <param name="sqlExpression">команда(Min, Max, Sum, Count)</param>
    /// <returns></returns>
    Task<object?> ExecuteScalarConnect(string connectionString, string sqlExpression);

    /// <summary>
    /// Возвращает количество измененных записей
    /// </summary>
    /// <param name="connectionString">строка подключения</param>
    /// <param name="sqlExpression"> INSERT, UPDATE, DELETE, CREATE</param>
    /// <returns></returns>
    Task<int> ExecuteNonQueryConnect(string connectionString, string sqlExpression);
}