using AutoMapper;

using BenchmarkDotNet.Attributes;

using MappersBenchmark.ClassToMap;
using MappersBenchmark.MappersProfiles;

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
        var chatDTO = ClassFake.chatClass.ToDto();
    }

    [Benchmark]
    public void MapperObjectMapperly()
    {
        var chatDTO = _mapperly.ToChatDTO(ClassFake.chatClass);
    }

    [Benchmark]
    public void MapperObjectAutoMapper()
    {
        var chatDTO = _autoMapper.Map<ChatDTO>(ClassFake.chatClass);
    }

    [Benchmark]
    public void MapperListManual()
    {
        var chatDTO = ClassFake.chatEntityList.Select(x => x.ToDto())
            .ToList();
    }

    [Benchmark]
    public void MapperListMapperly()
    {
        var chatDTO = ClassFake.chatEntityList.Select(_mapperly.ToChatDTO)
            .ToList();
    }

    [Benchmark]
    public void MapperListAutoMapper()
    {
        var chatDTO = _autoMapper.Map<List<ChatDTO>>(ClassFake.chatEntityList);
    }
}
