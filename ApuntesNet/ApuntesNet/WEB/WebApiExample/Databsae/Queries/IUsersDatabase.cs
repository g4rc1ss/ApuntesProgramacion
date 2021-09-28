using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiExample.Databsae.DTO;

namespace WebApiExample.Databsae.Queries {
    public interface IUsersDatabase {
        Task<IEnumerable<UserDatabase>> GetAllUsers();
    }
}
