﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiExample.Databsae.Queries;

namespace WebApiExample.Business.Manager {
    public class UserManager : IUserManager {
        private readonly IUsersDatabase _usersDatabase;

        public UserManager(IUsersDatabase usersDatabase) {
            _usersDatabase = usersDatabase;
        }

        public async Task<List<User>> GetAllUser() {
            var response = await _usersDatabase.GetAllUsers();
            return response.Select(x => (User)x).ToList();
        }
    }
}
