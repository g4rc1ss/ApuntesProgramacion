using AutoMapper;
using AutoMapperBenchmark.Fakes.Clases;

namespace AutoMapperBenchmark.Fakes
{
    internal class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ClaseOrigen, ClaseDestino>();
        }
    }
}
