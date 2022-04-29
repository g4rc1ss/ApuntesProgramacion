using System.Threading.Tasks;
using CleanArchitecture.Domain.Database.ModelEntity;
using CleanArchitecture.Domain.Negocio.Filtros.UserDetail;

namespace CleanArchitecture.ApplicationCore.InterfacesEjemplo.Negocio.UsersManager
{
    public interface IUserDetailNegocio
    {
        Task<UserModelEntity> GetUser(FiltroUser filtro);
    }
}
