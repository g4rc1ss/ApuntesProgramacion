﻿using MvcExample.Database.DTO;

namespace MvcExample.Business.Manager {
    public class User {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }

        public static implicit operator User(UserDatabase userDatabase) {
            return new User {
                Id = userDatabase.UserID.ToString(),
                Nombre = userDatabase.Nombre,
                Apellidos = userDatabase.Apellidos
            };
        }
    }
}
