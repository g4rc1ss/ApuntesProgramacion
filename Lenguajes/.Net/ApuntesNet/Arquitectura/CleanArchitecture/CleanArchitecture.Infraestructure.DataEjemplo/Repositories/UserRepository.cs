using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data;
using CleanArchitecture.Domain.Database.ModelEntity;
using CleanArchitecture.Infraestructure.DataEntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infraestructure.DataEjemplo.DataAccessManager;

internal class UserRepository : IUserRepository
{
    private readonly IDbContextFactory<EjemploContext> _contextFactory;
    private readonly IMapper _mapper;

    public UserRepository(IDbContextFactory<EjemploContext> contextFactory, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserModelEntity>> GetListUsers()
    {
        using var context = _contextFactory.CreateDbContext();
        var users = await context.User.ToListAsync();

        return _mapper.Map<IEnumerable<UserModelEntity>>(users);
    }
}
