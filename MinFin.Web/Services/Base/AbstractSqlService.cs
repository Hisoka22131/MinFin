using System.Dynamic;
using Microsoft.Data.SqlClient;
using MinFin.Web.Services.Interfaces;

namespace MinFin.Web.Services.Base;

public abstract class AbstractSqlService : ISqlConnectionService
{
    public async Task<List<object>> ExecuteReaderConnect(string connectionString, string sqlExpression)
    {
        var objList = new List<object>();

        try
        {
            await using var connection = new SqlConnection(connectionString);
            await connection.OpenAsync();

            var command = new SqlCommand(sqlExpression, connection);
            var sqlDataReader = await command.ExecuteReaderAsync();

            if (!sqlDataReader.HasRows) return new List<object>();

            while (await sqlDataReader.ReadAsync())
            {
                var obj = new ExpandoObject();
                var objDict = (IDictionary<string, object>)obj;

                for (var i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    var propertyName = sqlDataReader.GetName(i);
                    var propertyValue = sqlDataReader.GetValue(i);

                    objDict[propertyName] = propertyValue;
                }

                objList.Add(obj);
            }

            await sqlDataReader.CloseAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return objList;
    }

    public async Task<object?> ExecuteScalarConnect(string connectionString, string sqlExpression)
    {
        try
        {
            await using var connection = new SqlConnection(connectionString);
            await connection.OpenAsync();

            var command = new SqlCommand(sqlExpression, connection);
            return await command.ExecuteScalarAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return null;
    }

    public async Task<int> ExecuteNonQueryConnect(string connectionString, string sqlExpression)
    {
        try
        {
            await using var connection = new SqlConnection(connectionString);
            await connection.OpenAsync();

            var command = new SqlCommand(sqlExpression, connection);
            return await command.ExecuteNonQueryAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return 0;
    }
}