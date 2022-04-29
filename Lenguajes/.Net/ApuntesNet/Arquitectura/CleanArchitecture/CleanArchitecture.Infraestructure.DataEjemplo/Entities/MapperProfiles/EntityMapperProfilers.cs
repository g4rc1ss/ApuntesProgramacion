using AutoMapper;
using CleanArchitecture.Domain.Database.ModelEntity;

namespace CleanArchitecture.Infraestructure.DataEntityFramework.Entities.MapperProfiles
{
    internal class EntityMapperProfilers : Profile
    {
        public EntityMapperProfilers()
        {
            CreateMap<UserModelEntity, User>().ReverseMap();
            CreateMap<RoleModelEntity, Role>().ReverseMap();
            CreateMap<UserClaimModelEntity, UserClaim>().ReverseMap();
            CreateMap<UserLoginModelEntity, UserLogin>().ReverseMap();
            CreateMap<UserRoleModelEntity, UserRole>().ReverseMap();
            CreateMap<RoleClaimModelEntity, RoleClaim>().ReverseMap();
        }
    }
}
