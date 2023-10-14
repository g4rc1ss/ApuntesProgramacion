using BenchmarkDotNet.Filters;
using MapperlyBenchmark.Fakes.Clases;
using Riok.Mapperly.Abstractions;

namespace MapperlyBenchmark.Fakes;

[Mapper]
internal partial class MapperlyMapper
{
    internal partial ClaseDestino ToClaseDestino(ClaseOrigen claseOrigen);
    
    [MapProperty(nameof(@ClaseRelacionadaConOrigen.NombreCampo), nameof(@ClaseOrigen.Valor1))]
    internal partial ClaseOrigen ToClaseOrigen(ClaseRelacionadaConOrigen claseRelacionadaConOrigen);
}
