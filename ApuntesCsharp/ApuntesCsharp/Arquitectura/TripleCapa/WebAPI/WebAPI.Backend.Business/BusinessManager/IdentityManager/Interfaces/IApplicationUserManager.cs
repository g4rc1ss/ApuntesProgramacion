namespace WebAPI.Backend.Business.BusinessManager.IdentityManager.Interfaces {
    public interface IApplicationUserManager {
        bool CreateUserAccount(CreateAccountData createAccountData);
        bool Login(string username, string password, bool rememberMe);
        bool Logout();
    }
}
