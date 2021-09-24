using System;
using System.Collections.Generic;
using System.Linq;
using SqliteEfCore.Core.Modelos;
using SqliteEfCore.Database;

namespace SqliteEfCore.Core {
    public class EjecutarQueries {
        public static bool CrearBaseDeDatos() {
            using (var contexto = new ContextoSqlite()) {
                contexto.CreateDatabase();
                if (contexto.Database.CanConnect()) {
                    return true;
                }
            }
            return false;
        }

        internal static void UpdateData() {
            using (var context = new ContextoSqlite()) {
                var usuario = (from user in context.Usuarios
                               where user.PuebloIdNavigation.Id == 4
                               select user).FirstOrDefault();
                usuario.Nombre = "cnifvbdilcbsuyvrg";
                context.Update(usuario);
                context.SaveChanges();
            }
        }

        internal static void DeleteData() {
            using (var context = new ContextoSqlite()) {
                var usuarios = (from user in context.Usuarios
                                where user.Edad < 22
                                select user).ToList();
                context.RemoveRange(usuarios);
                context.SaveChanges();
            }
        }

        public static List<User> SelectData() {
            using (var context = new ContextoSqlite()) {
                var users = (from usuario in context.Usuarios
                             join pueblo in context.Pueblos on usuario.PuebloId equals pueblo.Id
                             select new User {
                                 Name = usuario.Nombre,
                                 Edad = usuario.Edad,
                                 Pueblo = new Pueblo {
                                     Nombre = pueblo.Nombre
                                 }
                             }).ToList();
                return users;
            }
        }

        internal static void InsertData() {
            using (var context = new ContextoSqlite()) {
                var pueblo = context.Pueblos.Add(new Database.DTO.Pueblo {
                    Nombre = "Soria"
                });

                context.Usuarios.Add(new Database.DTO.Usuario {
                    Nombre = "Nombre del usuario",
                    Edad = 10,
                    FechaHoy = DateTime.Now,
                    PuebloId = pueblo.Entity.Id
                });
            }
        }
    }
}
