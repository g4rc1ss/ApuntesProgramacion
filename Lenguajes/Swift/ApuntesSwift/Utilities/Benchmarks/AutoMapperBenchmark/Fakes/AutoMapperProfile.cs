using AutoMapper;
using AutoMapperBenchmark.Fakes.Clases;

namespace AutoMapperBenchmark.Fakes
{
    internal class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ClaseOrigen, ClaseDestino>();

            CreateMap<ClaseRelacionadaConOrigen, ClaseOrigen>()
                .ForMember(x => x.Valor1, y => y.MapFrom(x => x.NombreCampo));
        }
    }
}
