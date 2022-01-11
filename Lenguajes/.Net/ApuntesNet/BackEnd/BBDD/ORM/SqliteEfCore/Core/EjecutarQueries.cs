using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SqliteEfCore.Core.Modelos;
using SqliteEfCore.Database;

namespace SqliteEfCore.Core
{
    public class EjecutarQueries
    {
        public static bool CrearBaseDeDatos()
        {
            using (var contexto = new ContextoSqlite())
            {
                contexto.CreateDatabase();
                if (contexto.Database.CanConnect())
                {
                    return true;
                }
            }
            return false;
        }

        internal static Task<int> UpdateData()
        {
            using var context = new ContextoSqlite();
            var usuario = (from user in context.Usuarios
                           where user.PuebloIdNavigation.Id == 4
                           select user).FirstOrDefault();
            usuario.Nombre = "cnifvbdilcbsuyvrg";

            context.Update(usuario);
            return context.SaveChangesAsync();
        }

        internal static Task<int> DeleteData()
        {
            using var context = new ContextoSqlite();
            var usuarios = (from user in context.Usuarios
                            where user.Edad < 22
                            select user).ToList();
            context.RemoveRange(usuarios);
            return context.SaveChangesAsync();
        }

        public static Task<List<User>> SelectData()
        {
            using var context = new ContextoSqlite();
            return (from usuario in context.Usuarios
                    join pueblo in context.Pueblos on usuario.PuebloId equals pueblo.Id
                    select new User
                    {
                        Name = usuario.Nombre,
                        Edad = usuario.Edad,
                        Pueblo = new Pueblo
                        {
                            Nombre = pueblo.Nombre
                        }
                    }).ToListAsync();
        }

        internal static Task<int> InsertDataAsync()
        {
            using var context = new ContextoSqlite();

            context.Usuarios.Add(new Database.DTO.Usuario
            {
                Nombre = "Nombre del usuario",
                Edad = 10,
                FechaHoy = DateTime.Now,
                PuebloId = 20,
                PuebloIdNavigation = new Database.DTO.Pueblo
                {
                    Nombre = "Soria"
                }
            });

            return context.SaveChangesAsync();
        }
    }
}
