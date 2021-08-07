using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesktopUI.Backend.Data;
using DesktopUI.Backend.Data.Database;

namespace DesktopUI.Migrations.Seeds {
    internal class SeedUser {
        private readonly ContextoSqlServer contextoSqlite;

        public SeedUser(ContextoSqlServer contextoSqlite) {
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
