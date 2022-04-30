namespace CleanArchitecture.Domain.Negocio.UsersDto
{
    public class UserIdentityResponse
    {

        public bool Succeed { get; set; }

        public UserIdentityResponse(bool succeed)
        {
            Succeed = succeed;
        }

        public UserIdentityResponse()
        {

        }
    }
}
