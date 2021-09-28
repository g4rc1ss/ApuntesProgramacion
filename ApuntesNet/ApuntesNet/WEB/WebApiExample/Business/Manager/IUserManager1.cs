using System.Threading.Tasks;

namespace WebApiExample.Business.Manager {
    public interface IUserManager1 {
        Task<User> GetAllUser();
    }
}