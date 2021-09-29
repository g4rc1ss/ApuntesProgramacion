using System.Collections.Generic;
using System.Threading.Tasks;

namespace RazorPagesExample.Business.Manager {
    public interface IUserManager {
        Task<IEnumerable<User>> GetAllUser();
    }
}
