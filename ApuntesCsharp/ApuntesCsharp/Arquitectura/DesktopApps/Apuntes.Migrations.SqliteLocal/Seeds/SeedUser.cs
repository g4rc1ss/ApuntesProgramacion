using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apuntes.BackLocal.DataAccessLayer.Database;
using Apuntes.BackLocal.DataAccessLayer.Database.Sqlite;

namespace Apuntes.Migrations.SqliteLocal.Seeds {
    internal class SeedUser {
        private readonly ContextoSqlite contextoSqlite;

        public SeedUser(ContextoSqlite contextoSqlite) {
            this.contextoSqlite = contextoSqlite;
        }

        internal async Task InicializarDatosFavoritos() {
            var users = new List<Usuario>();

            foreach (var x in Enumerable.Range(0, 100)) {
                users.Add(new Usuario {
                    Nombre = $"Nombre {x}",
                    Edad = new Random().Next(100),
                    FechaHoy = DateTime.Now
                });
            }

            contextoSqlite.Usuarios.AddRange(users);
            await contextoSqlite.SaveChangesAsync();
        }
    }
}
