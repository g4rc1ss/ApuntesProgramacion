using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data;
using CleanArchitecture.Domain.Database.ModelEntity;
using CleanArchitecture.Domain.Negocio.Filtros.UserDetail;
using CleanArchitecture.Infraestructure.DataEntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infraestructure.DataEntityFramework.Repositories
{
    internal class UserDetailRepository : IUserDetailRepository
    {
        private readonly IDbContextFactory<EjemploContext> _dbContextFactory;
        private readonly IMapper _mapper;

        public UserDetailRepository(IDbContextFactory<EjemploContext> dbContextFactory, IMapper mapper)
        {
            _dbContextFactory = dbContextFactory;
            _mapper = mapper;
        }

        public async Task<UserModelEntity> GetUser(FiltroUser filtro)
        {
            using var context = _dbContextFactory.CreateDbContext();
            var user = await context.User.Where(x => x.Id == filtro.IdUsuario).SingleOrDefaultAsync();
            return _mapper.Map<UserModelEntity>(user);
        }
    }
}
