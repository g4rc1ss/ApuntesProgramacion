﻿using RazorPagesExample.Database.DTO;

namespace RazorPagesExample.Database.Queries
{
    public class UsersDatabase : IUsersDatabase
    {

        public async Task<IEnumerable<UserDatabase>> GetAllUsers()
        {
            // Aqui ejecutamos una query a BBDD
            // Suponemos que se realiza
            return new List<UserDatabase> {
                new UserDatabase {
                    UserID = Guid.NewGuid(),
                    Nombre = "Nombre 1",
                    Apellidos = "Apellidos 1"
                },
                new UserDatabase {
                    UserID = Guid.NewGuid(),
                    Nombre = "Nombre 2",
                    Apellidos = "Apellidos 2"
                },
                new UserDatabase {
                    UserID = Guid.NewGuid(),
                    Nombre = "Nombre 2",
                    Apellidos = "Apellidos 2"
                }
            };
        }
    }
}