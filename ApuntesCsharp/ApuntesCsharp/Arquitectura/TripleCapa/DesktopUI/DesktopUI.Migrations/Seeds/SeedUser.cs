using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesktopUI.Backend.Data;
using DesktopUI.Backend.Data.Database;

namespace DesktopUI.Migrations.Seeds {
    internal class SeedUser {
        private readonly ContextoSqlServer contexto;

        public SeedUser(ContextoSqlServer contexto) {
            this.contexto = contexto;
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

            contexto.Usuarios.AddRange(users);
            await contexto.SaveChangesAsync();
        }
    }
}
