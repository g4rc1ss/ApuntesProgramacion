namespace MvcExample.Business.Manager
{
    public interface IUserManager
    {
        Task<IEnumerable<User>> GetAllUser();
    }
}
