using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiExample.Business.Manager {
    public interface IUserManager {
        Task<List<User>> GetAllUser();
    }
}
