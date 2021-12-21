using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using WebApiExample.Database.DTO;

namespace WebApiExample.Database.Queries {
    public class UsersDatabase : IUsersDatabase {
        private readonly IDapperConfig _dapperConfig;

        public UsersDatabase(IDapperConfig dapperConfig) {
            _dapperConfig = dapperConfig;
        }

        public async Task<IEnumerable<UserDatabase>> GetAllUsers() {
            using (var connection = _dapperConfig.GetConnection()) {
                return await connection.QueryAsync<UserDatabase>("SELECT * FROM [PruebasConceptoWebApuntesNet].dbo.USUARIO");
            }
        }

        public async Task<bool> InsertUser(UserDatabase userDatabase) {
            using (var connection = _dapperConfig.GetConnection()) {
                var parameters = new DynamicParameters();
                parameters.Add("@Nombre", userDatabase.Nombre);
                parameters.Add("@Apellidos", userDatabase.Apellidos);
                var result = await connection.ExecuteAsync("[dbo].[CrearUsuarioNuevo]", parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
    }
}
