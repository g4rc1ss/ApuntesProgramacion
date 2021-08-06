﻿using System.Collections.Generic;
using System.Linq;
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

        public static List<object> CargaDeBaseDeDatos() {
            var baseDeDatos = new List<object>();
            using (var context = new ContextoSqlite()) {
                var users = (from consulta in context.Usuarios
                             where consulta.Id < 11
                             select new User() {
                                 Name = consulta.Nombre,
                                 Edad = consulta.Edad
                             }).ToList();

                var pueblos = (from query in context.Pueblos
                               select new Pueblo() {
                                   Nombre = query.Nombre
                               }).ToList();

                baseDeDatos.AddRange(users);
                baseDeDatos.AddRange(pueblos);
            }
            return baseDeDatos;
        }
    }
}
