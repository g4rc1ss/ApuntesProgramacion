namespace WebApiExample.Business.Manager
{
    public interface IUserManager
    {
        Task<List<User>> GetAllUser();
        Task<bool> InsertUser(User userRequest);
    }
}
