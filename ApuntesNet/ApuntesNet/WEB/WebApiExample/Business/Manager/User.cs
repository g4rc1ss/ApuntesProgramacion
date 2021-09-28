﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiExample.Databsae.DTO;

namespace WebApiExample.Business.Manager {
    public class User {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }

        public static implicit operator User(UserDatabase userDatabase) {
            return new User {
                Id = userDatabase.Id,
                Nombre = userDatabase.Nombre,
                Apellidos = userDatabase.Apellido
            };
        }
    }
}
