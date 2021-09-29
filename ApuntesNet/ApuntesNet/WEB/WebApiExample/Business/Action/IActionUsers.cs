using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiExample.Business.Manager;

namespace WebApiExample.Business.Action {
    public interface IActionUsers {
        Task<List<User>> GetAllUsersAsync();
    }
}
