using AutoMapper;
using BenchmarkDotNet.Attributes;

namespace MappersBenchmark;

[MemoryDiagnoser]
public class Mappers
{
    private readonly IMapper _autoMapper;
    private readonly MapperlyProfile _mapperly;

    public Mappers()
    {
        _autoMapper = new MapperConfiguration(x => x.AddProfile(new AutoMapperProfile())).CreateMapper();
        _mapperly = new MapperlyProfile();
    }

    [Benchmark]
    public void MapperObjectManual()
    {
        var chatDTO = ClassFake.ChatClass.ToDto();
    }

    [Benchmark]
    public void MapperObjectMapperly()
    {
        var chatDTO = _mapperly.ToChatDTO(ClassFake.ChatClass);
    }

    [Benchmark]
    public void MapperObjectAutoMapper()
    {
        var chatDTO = _autoMapper.Map<ChatDTO>(ClassFake.ChatClass);
    }

    [Benchmark]
    public void MapperListManual()
    {
        var chatDTO = ClassFake.ChatEntityList.Select(x => x.ToDto())
            .ToList();
    }

    [Benchmark]
    public void MapperListMapperly()
    {
        var chatDTO = ClassFake.ChatEntityList.Select(x => _mapperly.ToChatDTO(x))
            .ToList();
    }

    [Benchmark]
    public void MapperListAutoMapper()
    {
        var chatDTO = _autoMapper.Map<List<ChatDTO>>(ClassFake.ChatEntityList);
    }
}
