using System.Globalization;
using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using MinFin.ParseService.Interfaces;

namespace MinFin.ParseService.Services;

public class CsvService : ICsvService
{
    private readonly IMapper _mapper;

    public CsvService(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    private static async Task<string> CreateCsvPackage<TResponseDto>(IEnumerable<TResponseDto> obj)
    {
        await using var writer = new StringWriter();
        await using var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture));
        
        await csv.WriteRecordsAsync(obj);

        return writer.ToString();
    }
    
    public async Task<string?> CreateData<TResponseDto, TModel>(IEnumerable<TModel>? models)
    {
        if (models == null) return "";

        try
        {
            var result = models!.Select(model => _mapper.Map<TResponseDto>(model)).ToList();

            return await CreateCsvPackage(result);
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