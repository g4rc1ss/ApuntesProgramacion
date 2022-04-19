using AutoMapper;
using CleanArchitecture.Domain.Database.Identity;
using CleanArchitecture.Domain.Negocio.Filtros.UserDetail;
using CleanArchitecture.Shared.Peticiones.Request.Users.UserDetail;
using CleanArchitecture.Shared.Peticiones.Responses.User.Usuarios;

namespace CleanArchitecture.Ejemplo.API.AutoMapperProfiles
{
    public class ProfileAutoMapper : Profile
    {
        public ProfileAutoMapper()
        {
            CreateMap<UserDetailRequest, FiltroUser>();
            CreateMap<int, FiltroUser>()
                .ForMember(x => x.IdUsuario, y => y.MapFrom(x => x));
            CreateMap<User, UserResponse>()
                .ForMember(x => x.NombreUsuario, y => y.MapFrom(x => x.UserName))
                .ForMember(x => x.TieneDobleFactor, y => y.MapFrom(x => x.TwoFactorEnabled))
                .ForMember(x => x.Nombre, y => y.MapFrom(x => x.NormalizedUserName));

        }
    }
}
