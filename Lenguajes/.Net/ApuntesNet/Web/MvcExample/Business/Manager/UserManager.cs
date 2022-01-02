using MvcExample.Database.Queries;

namespace MvcExample.Business.Manager
{
    public class UserManager : IUserManager
    {
        private readonly IUsersDatabase _usersDatabase;

        public UserManager(IUsersDatabase usersDatabase)
        {
            _usersDatabase = usersDatabase;
        }

        public async Task<IEnumerable<User>> GetAllUser()
        {
            var response = await _usersDatabase.GetAllUsers();
            return response.Select(x => (User)x);
        }
    }
}
