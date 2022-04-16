using AutoMapper;
using CleanArchitecture.ApplicationCore.Domain.Negocio.Filtros.UserDetail;
using CleanArchitecture.Shared.Peticiones.Request.Users.UserDetail;

namespace CleanArchitecture.Ejemplo.AutoMapperProfiles
{
    public class ProfileAutoMapper : Profile
    {
        public ProfileAutoMapper()
        {
            CreateMap<UserDetailRequest, FiltroUser>();

        }
    }
}
