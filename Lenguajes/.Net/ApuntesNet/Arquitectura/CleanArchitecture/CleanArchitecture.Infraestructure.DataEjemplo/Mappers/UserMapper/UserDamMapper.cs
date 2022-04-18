using CleanArchitecture.Domain.Database.Identity;
using CleanArchitecture.Domain.Negocio.UsersDto;

namespace CleanArchitecture.Infraestructure.DataEjemplo.Mappers.UserMapper
{
    internal static class UserDamMapper
    {
        internal static User GetUserFromUserData(UserData userData)
        {
            return new User
            {
                UserName = userData?.UserName,
                NormalizedUserName = userData?.NormalizedUserName,
                Email = userData?.Email,
                PhoneNumber = userData?.PhoneNumber,
                SecurityStamp = userData?.SecurityStamp,
            };
        }
    }
}
