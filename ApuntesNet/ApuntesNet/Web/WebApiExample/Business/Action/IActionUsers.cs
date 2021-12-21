using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiExample.Business.Manager;
using WebApiExample.Shared.DTO.Request;

namespace WebApiExample.Business.Action {
    public interface IActionUsers {
        Task<List<User>> GetAllUsersAsync();
        Task<bool> InsertUser(UserRequest userRequest);
    }
}
