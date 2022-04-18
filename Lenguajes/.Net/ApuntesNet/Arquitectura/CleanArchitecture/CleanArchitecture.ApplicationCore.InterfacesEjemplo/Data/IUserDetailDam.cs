using System.Threading.Tasks;
using CleanArchitecture.Domain.Database.Identity;
using CleanArchitecture.Domain.Negocio.Filtros.UserDetail;

namespace CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data
{
    public interface IUserDetailDam
    {
        Task<User> GetUser(FiltroUser filtro);
    }
}
