using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiExample.Database.DTO;

namespace WebApiExample.Database.Queries {
    public interface IUsersDatabase {
        Task<IEnumerable<UserDatabase>> GetAllUsers();
    }
}
