using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Negocio.UsersManager;
using CleanArchitecture.ApplicationCore.NegocioEjemplo.ExtensionsHelper;
using CleanArchitecture.Domain.Database.Identity;
using CleanArchitecture.Domain.Negocio.Filtros.UserDetail;
using CleanArchitecture.Domain.Utilities.MemoryCacheMediatr;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace CleanArchitecture.ApplicationCore.NegocioEjemplo.Negocio.UsersManager
{
    internal class UserDetailNegocio : IUserDetailNegocio
    {
        private readonly IUserDetailDam _userDetailDam;
        private readonly IMediator _mediator;
        private readonly IDistributedCache _distributedCache;

        public UserDetailNegocio(IUserDetailDam userDetailDam, IMediator mediator, IDistributedCache distributedCache)
        {
            _userDetailDam = userDetailDam;
            _mediator = mediator;
            _distributedCache = distributedCache;
        }

        public async Task<User> GetUser(FiltroUser filtro)
        {
            var key = $"ObtenerUsuario_{filtro.IdUsuario}";
            var user = await _distributedCache.GetObjectCache<User>(key);

            if (user != null)
            {
                return user;
            }

            var usuario = await _userDetailDam.GetUser(filtro);
            return await _distributedCache.SetObjectCache(key, usuario);
        }
    }
}
