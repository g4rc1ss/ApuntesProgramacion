using System.Threading.Tasks;
using CleanArchitecture.ApplicationCore.Dominio.Negocio.Filtros.UserDetail;
using CleanArchitecture.ApplicationCore.Shared.Peticiones.Responses.User.Usuarios;

namespace CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data {
    public interface IUserDetailDam {
        Task<UserResponse> GetUser(FiltroUser filtro);
    }
}
