using AutoMapper;
using AutoMapperBenchmark.Fakes;
using AutoMapperBenchmark.Fakes.Clases;
using BenchmarkDotNet.Attributes;

namespace AutoMapperBenchmark.Benchmarks
{
    [MemoryDiagnoser]
    public class Mappers
    {
        private readonly IMapper _mapper;
        private readonly ClaseOrigen _claseOrigen;
        private readonly List<ClaseOrigen> _enumerableOrigen;

        public Mappers()
        {
            _mapper = new MapperConfiguration(config =>
            {
                config.AddProfile(new AutoMapperProfile());
            }).CreateMapper();
            _claseOrigen = Helper.Origin;
            _enumerableOrigen = Enumerable.Range(0, 1_000_000).Select(x => Helper.Origin).ToList();
        }

        [Benchmark]
        public void AutoMapper()
        {
            _mapper.Map<ClaseDestino>(_claseOrigen);
        }

        [Benchmark]
        public void ImplicitOperator()
        {
            ClaseDestinoImplicitOperator destino = _claseOrigen;
        }

        [Benchmark]
        public void AutomapperListas()
        {
            _mapper.Map<List<ClaseDestino>>(_enumerableOrigen);
        }

        [Benchmark]
        public void ImplicitOperatorListas()
        {
            _enumerableOrigen.Select(x => (ClaseDestinoImplicitOperator)x).ToList();
        }
    }
}

