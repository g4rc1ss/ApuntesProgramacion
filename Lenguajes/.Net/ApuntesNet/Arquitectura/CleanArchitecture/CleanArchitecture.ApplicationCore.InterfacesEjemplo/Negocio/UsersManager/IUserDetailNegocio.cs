using System.Threading.Tasks;
using CleanArchitecture.Domain.Database.Identity;
using CleanArchitecture.Domain.Negocio.Filtros.UserDetail;

namespace CleanArchitecture.ApplicationCore.InterfacesEjemplo.Negocio.UsersManager
{
    public interface IUserDetailNegocio
    {
        Task<User> GetUser(FiltroUser filtro);
    }
}
