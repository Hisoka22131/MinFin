using System.Xml;
using System.Xml.Serialization;
using MinFin.ParseService.Helpers;
using MinFin.ParseService.Interfaces;

namespace MinFin.ParseService.Services;

public class XmlService : IXmlService
{
    public async Task<string?> Send<TSendDto, TModel>(IEnumerable<TModel>? models)
        where TSendDto : class, new() where TModel : class
    {
        if (models == null) return "";

        try
        {
            var result = new List<TSendDto>();

            foreach (var model in models)
            {
                var sendDto = new TSendDto();

                ConvertHelper.Convert(sendDto, model);

                result.Add(sendDto);
            }

            var settings = new XmlWriterSettings { Async = true };

            var serializer = new XmlSerializer(result.GetType());

            await using var stringWriter = new StringWriter();
            await using var xmlWriter = XmlWriter.Create(stringWriter, settings);
            serializer.Serialize(xmlWriter, result);

            return stringWriter.ToString();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<TEntity?> ParseData<TEntity>(object data)
    {
        throw new AggregateException(nameof(data));
    }
}