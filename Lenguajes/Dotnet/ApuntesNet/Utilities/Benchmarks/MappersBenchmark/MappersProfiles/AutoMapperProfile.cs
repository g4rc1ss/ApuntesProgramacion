﻿using AutoMapper;

namespace MappersBenchmark;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Chat, ChatDTO>()
            .ForMember(x => x.FromUser, y => y.MapFrom(x => x.UserIdFromNavigation))
            .ForMember(x => x.ToUser, y => y.MapFrom(x => x.UserIdToNavigation))
            .ForMember(x => x.Properties, y => y.MapFrom(x => x.PropiedadesNavigation))
            .ForMember(x => x.Message, y => y.MapFrom(x => x.Message))
            .ForMember(x => x.IsRead, y => y.MapFrom(x => x.EstaLeido))
            .ReverseMap();

        CreateMap<Propiedad, PropertyDTO>()
            .ReverseMap();

        CreateMap<User, UserDTO>()
            .ForMember(x => x.Nombre, y => y.MapFrom(x => x.Name))
            .ForMember(x => x.Apellidos, y => y.MapFrom(x => x.LastName))
            .ReverseMap();
    }
}
