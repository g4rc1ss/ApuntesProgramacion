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

        public Mappers()
        {
            _mapper = new MapperConfiguration(config =>
            {
                config.AddProfile(new AutoMapperProfile());
            }).CreateMapper();
            _claseOrigen = Helper.Origin;
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
        public void ManualMapping()
        {
            var destino = new ClaseDestino
            {
                Valor1 = _claseOrigen.Valor1,
                Valor2 = _claseOrigen.Valor2,
                Valor3 = _claseOrigen.Valor3,
                Valor4 = _claseOrigen.Valor4,
                Valor5 = _claseOrigen.Valor5,
                Valor6 = _claseOrigen.Valor6,
                Valor7 = _claseOrigen.Valor7,
                Valor8 = _claseOrigen.Valor8,
                Valor9 = _claseOrigen.Valor9,
                Valor10 = _claseOrigen.Valor10,
                Valor11 = _claseOrigen.Valor11,
                Valor12 = _claseOrigen.Valor12,
                Valor13 = _claseOrigen.Valor13,
                Valor14 = _claseOrigen.Valor14,
                Valor15 = _claseOrigen.Valor15,

            };
        }
    }
}

