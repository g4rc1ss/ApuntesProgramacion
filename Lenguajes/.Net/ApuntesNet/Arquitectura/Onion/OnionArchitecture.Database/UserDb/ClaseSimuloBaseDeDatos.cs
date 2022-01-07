using OnionArchitecture.Domain.Interfaces.DatabaseContracts.UserContracts;
using OnionArchitecture.Domain.Models.Dto;

namespace OnionArchitecture.Database.UserDb
{
    public class ClaseSimuloBaseDeDatos : IClaseSimuloBaseDeDatos
    {
        public Task<List<UserDto>> UserList()
        {
            return Task.FromResult(Enumerable.Range(0, 10000)
                .Select(x => new UserDto
                {
                    Name = $"Usuario{x}",
                    Email = $"Email{x}",
                }).ToList());
        }
    }
}
