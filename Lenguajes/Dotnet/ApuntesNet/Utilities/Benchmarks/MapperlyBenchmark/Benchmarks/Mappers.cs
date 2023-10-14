using BenchmarkDotNet.Attributes;
using MapperlyBenchmark.Fakes;
using MapperlyBenchmark.Fakes.Clases;

namespace MapperlyBenchmark.Benchmarks;

[MemoryDiagnoser]
public class Mappers
{
    private readonly MapperlyMapper _mapper;
    private readonly ClaseRelacionadaConOrigen _claseRelacionadaConOrigen;
    private readonly List<ClaseRelacionadaConOrigen> _enumerableRelacion;
    private readonly ClaseOrigen _claseOrigen;
    private readonly List<ClaseOrigen> _enumerableOrigen;

    public Mappers()
    {
        _mapper = new MapperlyMapper();
        _claseOrigen = Helper.Origin;
        _claseRelacionadaConOrigen = Helper.ClaseRelacion;
        _enumerableOrigen = Enumerable.Range(0, 5_000).Select(x => Helper.Origin).ToList();
        _enumerableRelacion = Enumerable.Range(0, 1).Select(x => Helper.ClaseRelacion).ToList();
    }

    [Benchmark]
    public void Mapperly()
    {
        _mapper.ToClaseDestino(_claseOrigen);
    }

    [Benchmark]
    public void ImplicitOperator()
    {
        ClaseDestinoImplicitOperator destino = _claseOrigen;
    }

    [Benchmark]
    public void MapperlyListas()
    {
        _enumerableOrigen.Select(x => _mapper.ToClaseDestino(x)).ToList();
    }

    [Benchmark]
    public void ImplicitOperatorListas()
    {
        _enumerableOrigen.Select(x => (ClaseDestinoImplicitOperator)x).ToList();
    }

    [Benchmark]
    public void RelacionLinqMapperlyEnSelect()
    {
        var result = (from origen in _enumerableOrigen
                      from relacion in _enumerableRelacion
                      where relacion.ClaseOriginId == origen.IdRelacion
                      select _mapper.ToClaseOrigen(relacion)).ToList();
    }

    [Benchmark]
    public void RelacionLinqMapeoManualEnSelect()
    {
        (from origen in _enumerableOrigen
         from relacion in _enumerableRelacion
         where relacion.ClaseOriginId == origen.IdRelacion
         select new ClaseOrigen
         {
             IdRelacion = origen.IdRelacion,
             Valor1 = relacion.NombreCampo,
             Valor2 = origen.Valor2,
             Valor3 = origen.Valor3,
             Valor4 = origen.Valor4,
             Valor5 = origen.Valor5,
             Valor6 = origen.Valor6,
             Valor7 = origen.Valor7,
             Valor8 = origen.Valor8,
             Valor9 = origen.Valor9,
             Valor10 = origen.Valor10,
             Valor11 = origen.Valor11,
             Valor12 = origen.Valor12,
             Valor13 = origen.Valor13,
             Valor14 = origen.Valor14,
             Valor15 = origen.Valor15,
         }).ToList();
    }

}

