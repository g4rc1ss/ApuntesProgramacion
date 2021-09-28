using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiExample.Databsae.DTO;

namespace WebApiExample.Databsae.Queries {
    public class UsersDatabase : IUsersDatabase {
        private readonly IDapperConfig _dapperConfig;

        public UsersDatabase(IDapperConfig dapperConfig) {
            _dapperConfig = dapperConfig;
        }

        public async Task<IEnumerable<UserDatabase>> GetAllUsers() {
            return new List<UserDatabase>() {
                new UserDatabase {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "nombre prueba",
                    Apellido = "Apellido prueba"
                }
            };
        }
    }
}
