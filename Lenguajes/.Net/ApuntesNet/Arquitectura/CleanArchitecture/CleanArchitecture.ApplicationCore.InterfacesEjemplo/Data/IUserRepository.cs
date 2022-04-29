using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Database.ModelEntity;
using CleanArchitecture.Domain.Negocio.UsersDto;

namespace CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data
{
    public interface IUserRepository
    {
        Task<List<UserModelEntity>> GetListUsers();
    }
}
