using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.ApplicationCore.Domain.Negocio.Filtros.UserDetail;
using CleanArchitecture.ApplicationCore.Domain.Utilities.MemoryCacheMediatr;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Negocio.UsersManager;
using CleanArchitecture.Shared.Peticiones.Responses.User.Usuarios;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace CleanArchitecture.ApplicationCore.NegocioEjemplo.Negocio.UsersManager
{
    internal class UserDetailNegocio : IUserDetailNegocio
    {
        private readonly IUserDetailDam _userDetailDam;
        private readonly IMediator _mediator;

        public UserDetailNegocio(IUserDetailDam userDetailDam, IMediator mediator)
        {
            _userDetailDam = userDetailDam;
            _mediator = mediator;
        }

        public async Task<UserResponse> GetUser(FiltroUser filtro)
        {
            var cache = await _mediator.Send(new MemoryCacheRequest
            {
                Key = "ObtenerUsuarios"
            });

            if (!cache.Succeed)
            {
                var tareas = new List<Task>();

                foreach (var item in Enumerable.Range(0, 10))
                {
                    tareas.Add(_userDetailDam.GetUser(filtro));
                }
                await Task.WhenAll(tareas);
                cache = await _mediator.Send(new MemoryCacheRequest
                {
                    Key = "ObtenerUsuarios",
                    Value = await _userDetailDam.GetUser(filtro)
                });
            }
            return (UserResponse)cache.Value;
        }
    }
}
