using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Database.ModelEntity;

namespace CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserModelEntity>> GetListUsers();
    }
}
