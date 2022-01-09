using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.ApplicationCore.Domain.Negocio.Filtros.UserDetail;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Negocio.UsersManager;
using CleanArchitecture.Shared.Peticiones.Responses.User.Usuarios;

namespace CleanArchitecture.ApplicationCore.NegocioEjemplo.Negocio.UsersManager
{
    internal class UserDetailNegocio : IUserDetailNegocio
    {
        private readonly IUserDetailDam _userDetailDam;

        public UserDetailNegocio(IUserDetailDam userDetailDam)
        {
            _userDetailDam = userDetailDam;
        }

        public async Task<UserResponse> GetUser(FiltroUser filtro)
        {
            var tareas = new List<Task>();

            foreach (var item in Enumerable.Range(0, 10))
            {
                tareas.Add(_userDetailDam.GetUser(filtro));
            }
            await Task.WhenAll(tareas);
            return await _userDetailDam.GetUser(filtro);
        }
    }
}
