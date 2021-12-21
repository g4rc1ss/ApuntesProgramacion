namespace RazorPagesExample.Business.Manager
{
    public interface IUserManager
    {
        Task<IEnumerable<User>> GetAllUser();
    }
}
