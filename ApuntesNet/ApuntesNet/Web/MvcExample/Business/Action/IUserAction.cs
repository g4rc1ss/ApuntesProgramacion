using MvcExample.Business.Manager;

namespace MvcExample.Business.Action
{
    public interface IUserAction
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
