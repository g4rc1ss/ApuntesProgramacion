using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiExample.Shared.DTO.Request;

namespace WebApiExample.Business.Manager {
    public interface IUserManager {
        Task<List<User>> GetAllUser();
        Task<bool> InsertUser(User userRequest);
    }
}
