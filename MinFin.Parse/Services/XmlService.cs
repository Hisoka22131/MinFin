using System.Xml;
using System.Xml.Serialization;
using AutoMapper;
using MinFin.Parse.Interfaces;

namespace MinFin.Parse.Services;

public class XmlService : IXmlService
{
    private readonly IMapper _mapper;

    public XmlService(IMapper mapper)
    {
        _mapper = mapper;
    }

    private static async Task<string> CreateXmlPackage(object obj)
    {
        var settings = new XmlWriterSettings { Async = true };

        var serializer = new XmlSerializer(obj.GetType());

        await using var stringWriter = new StringWriter();
        await using var xmlWriter = XmlWriter.Create(stringWriter, settings);
        serializer.Serialize(xmlWriter, obj);

        return stringWriter.ToString();
    }

    public async Task<string?> CreateData<TResponseDto, TModel>(IEnumerable<TModel>? models)
    {
        if (models == null) return "";

        try
        {
            var result = models!.Select(model => _mapper.Map<TResponseDto>(model)).ToList();

            return await CreateXmlPackage(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    
    
    public async Task<IEnumerable<TEntity>?> UploadData<TEntity, TRequestDto>(IEnumerable<TRequestDto>? models)
    {
        try
        {
            return models == null
                ? Enumerable.Empty<TEntity>()
                : models!.Select(model => _mapper.Map<TEntity>(model)).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}