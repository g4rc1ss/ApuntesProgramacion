using WebApiExample.Database.Queries;

namespace WebApiExample.Business.Manager
{
    public class UserManager : IUserManager
    {
        private readonly IUsersDatabase _usersDatabase;

        public UserManager(IUsersDatabase usersDatabase)
        {
            _usersDatabase = usersDatabase;
        }

        public async Task<List<User>> GetAllUser()
        {
            var response = await _usersDatabase.GetAllUsers();
            return response.Select(x => (User)x).ToList();
        }

        public async Task<bool> InsertUser(User userRequest)
        {
            return await _usersDatabase.InsertUser(userRequest);
        }
    }
}
