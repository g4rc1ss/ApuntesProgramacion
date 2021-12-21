using System.Collections.Generic;
using System.Threading.Tasks;
using MvcExample.Business.Manager;

namespace MvcExample.Business.Action {
    public interface IUserAction {
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
