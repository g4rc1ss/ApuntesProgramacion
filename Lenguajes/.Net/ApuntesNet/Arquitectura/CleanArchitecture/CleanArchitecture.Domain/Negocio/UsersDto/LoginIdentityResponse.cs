using CleanArchitecture.Domain.Database.ModelEntity;

namespace CleanArchitecture.Domain.Negocio.UsersDto
{
    public class LoginIdentityResponse
    {
        public LoginIdentityResponse()
        {

        }

        public LoginIdentityResponse(bool validatePassword, UserModelEntity userModel, RoleModelEntity roleModel)
        {
            ValidatePassword = validatePassword;
            UserModel = userModel;
            RoleModel = roleModel;
        }

        public bool ValidatePassword { get; set; }
        public UserModelEntity UserModel { get; set; }
        public RoleModelEntity RoleModel { get; set; }
    }
}
