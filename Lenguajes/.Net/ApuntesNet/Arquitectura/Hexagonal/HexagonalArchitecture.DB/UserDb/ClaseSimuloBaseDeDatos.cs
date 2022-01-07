using HexagonalArchitecture.Application.Dto;
using HexagonalArchitecture.Application.Ports.UserPort;

namespace HexagonalArchitecture.DB.UserDb
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
