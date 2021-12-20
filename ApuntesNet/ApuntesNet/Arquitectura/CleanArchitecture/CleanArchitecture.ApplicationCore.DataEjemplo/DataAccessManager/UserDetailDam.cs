using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.ApplicationCore.Dominio.Negocio.Filtros.UserDetail;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data;
using CleanArchitecture.ApplicationCore.Shared.Peticiones.Responses.User.Usuarios;
using CleanArchitecture.Infraestructure.DatabaseConfig;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.ApplicationCore.DataEjemplo.DataAccessManager {
    public class UserDetailDam : IUserDetailDam {
        private readonly IDbContextFactory<EjemploContext> _factoryEjemplo;

        public UserDetailDam(IDbContextFactory<EjemploContext> factoryEjemplo) {
            _factoryEjemplo = factoryEjemplo;
        }

        public async Task<UserResponse> GetUser(FiltroUser filtro) {
            using var context = _factoryEjemplo.CreateDbContext();
            return await (from user in context.User
                    where user.Id == filtro.IdUsuario
                    select new UserResponse {
                        Id = user.Id,
                        Nombre = user.NormalizedUserName,
                        NombreUsuario = user.UserName,
                        Email = user.Email,
                        TieneDobleFactor = user.TwoFactorEnabled,
                    }).FirstOrDefaultAsync();
        }
    }
}
