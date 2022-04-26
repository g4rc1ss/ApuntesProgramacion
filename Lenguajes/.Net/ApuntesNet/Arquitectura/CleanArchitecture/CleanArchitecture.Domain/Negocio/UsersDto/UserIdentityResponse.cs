using CleanArchitecture.Domain.Database.Identity;

namespace CleanArchitecture.Domain.Negocio.UsersDto
{
    public class UserIdentityResponse
    {
        public User User { get; set; }
        public bool Succeed { get; set; }
    }
}
