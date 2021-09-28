using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using WebApiExample.Databsae.DTO;

namespace WebApiExample.Databsae.Queries {
    public class UsersDatabase : IUsersDatabase {
        private readonly IDapperConfig _dapperConfig;

        public UsersDatabase(IDapperConfig dapperConfig) {
            _dapperConfig = dapperConfig;
        }

        public async Task<IEnumerable<UserDatabase>> GetAllUsers() {
            using(var connection = _dapperConfig.GetConnection()) {
                return await connection.QueryAsync<UserDatabase>("SELECT * FROM [PruebasConceptoWebApuntesNet].dbo.USUARIO");
            }
        }
    }
}
