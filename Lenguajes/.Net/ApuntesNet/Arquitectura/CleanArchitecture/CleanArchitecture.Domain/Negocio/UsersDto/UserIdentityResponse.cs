using CleanArchitecture.Domain.Database.ModelEntity;

namespace CleanArchitecture.Domain.Negocio.UsersDto
{
    public class UserIdentityResponse
    {
        public UserModelEntity User { get; set; }
        public bool Succeed { get; set; }
    }
}
