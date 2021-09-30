using System.Collections.Generic;
using System.Threading.Tasks;
using MvcExample.Database.DTO;

namespace MvcExample.Database.Queries {
    public interface IUsersDatabase {
        Task<IEnumerable<UserDatabase>> GetAllUsers();
    }
}
