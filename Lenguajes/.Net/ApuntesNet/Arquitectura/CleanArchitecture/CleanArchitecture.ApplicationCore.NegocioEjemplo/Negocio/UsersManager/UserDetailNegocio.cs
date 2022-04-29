using System.Threading.Tasks;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Negocio.UsersManager;
using CleanArchitecture.ApplicationCore.NegocioEjemplo.ExtensionsHelper;
using CleanArchitecture.Domain.Database.ModelEntity;
using CleanArchitecture.Domain.Negocio.Filtros.UserDetail;
using CleanArchitecture.Domain.Utilities.LoggingMediatr;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Caching.Distributed;

namespace CleanArchitecture.ApplicationCore.NegocioEjemplo.Negocio.UsersManager
{
    internal class UserDetailNegocio : IUserDetailNegocio
    {
        private readonly IUserDetailRepository _userDetailDam;
        private readonly IMediator _mediator;
        private readonly IDistributedCache _distributedCache;
        private readonly IDataProtector _protector;

        public UserDetailNegocio(IUserDetailRepository userDetailDam, IMediator mediator, IDistributedCache distributedCache, IDataProtectionProvider dataProtectionProvider)
        {
            _userDetailDam = userDetailDam;
            _mediator = mediator;
            _distributedCache = distributedCache;
            _protector = dataProtectionProvider.CreateProtector("Identity.Users");
        }

        public async Task<UserModelEntity> GetUser(FiltroUser filtro)
        {
            await _mediator.Publish(new LoggingRequest(filtro, LogType.Warning));

            var key = $"ObtenerUsuario_{filtro.IdUsuario}";
            var user = await _distributedCache.GetObjectCache<UserModelEntity>(key);

            if (user == null)
            {
                var usuario = await _userDetailDam.GetUser(filtro);
                user = await _distributedCache.SetObjectCache(key, usuario);
            }

            await _mediator.Publish(new LoggingRequest(user, LogType.Warning));

            user.Email = _protector.Unprotect(user.Email);
            user.PhoneNumber = _protector.Unprotect(user.PhoneNumber);
            return user;
        }
    }
}
