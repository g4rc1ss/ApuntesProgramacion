using System;
using System.Linq;
using System.Text;
using Dapper;
using SqliteDapper.Database;
using SqliteDapper.Database.Sqlite;

namespace SqliteDapper.Dam {
    internal class SelectData {
        internal static void SelectDataQuery() {
            using (var connection = DapperExecute.GetConnection()) {
                var sqlUsuario = @$"SELECT Id as {nameof(Usuario.IdUsuario)},
                                    Nombre as {nameof(Usuario.NombreUsuario)}
                                    FROM {nameof(Usuario)} WHERE Id = 'IdUsuario1'";
                var respuestaUsuario = connection.Query<Usuario>(sqlUsuario).FirstOrDefault();

                var sqlPueblo = @$"SELECT Id as {nameof(Pueblo.IdPueblo)},
                                    Nombre as {nameof(Pueblo.NombrePueblo)}
                                    FROM {nameof(Pueblo)}";
                var respuestaPueblo = connection.Query<Pueblo>(sqlPueblo).ToList();

                var sqlUsuarioJoin = new StringBuilder();
                sqlUsuarioJoin.AppendLine($"SELECT user.Id as {nameof(Usuario.IdUsuario)},");
                sqlUsuarioJoin.AppendLine($"user.Nombre as {nameof(Usuario.NombreUsuario)},");
                sqlUsuarioJoin.AppendLine($"village.Id as {nameof(Pueblo.IdPueblo)},");
                sqlUsuarioJoin.AppendLine($"village.Nombre as {nameof(Pueblo.NombrePueblo)}");

                sqlUsuarioJoin.AppendLine($"FROM {nameof(Usuario)} as user");
                sqlUsuarioJoin.AppendLine($"INNER JOIN {nameof(Pueblo)} as village ON user.IdPueblo = village.Id");
                var respuestaJoin = connection.QueryMultiple(sqlUsuarioJoin.ToString());
                var usuarios = respuestaJoin.Read<Usuario, Pueblo, Usuario>((user, village) => {
                    return new Usuario {
                        IdUsuario = user.IdUsuario,
                        NombreUsuario = user.NombreUsuario,
                        FKPueblo = village
                    };
                }, $"{nameof(Pueblo.IdPueblo)}");

                foreach (var user in usuarios) {
                    Console.WriteLine($"Usuario - {user.IdUsuario}_{user.NombreUsuario}");
                    Console.WriteLine($"Pueblo - {user.FKPueblo.IdPueblo}_{user.FKPueblo.NombrePueblo}");
                }
            }
        }
    }
}
