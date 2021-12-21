using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvcExample.Business.Manager {
    public interface IUserManager {
        Task<IEnumerable<User>> GetAllUser();
    }
}
