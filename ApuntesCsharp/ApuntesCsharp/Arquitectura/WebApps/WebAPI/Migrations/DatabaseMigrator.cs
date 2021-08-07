﻿using System.Threading.Tasks;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace Migrations {
    /// <summary>
    /// Clase para instancias los contextos de los que hay que ejecutar las migraciones para crearlos
    /// </summary>
    public class DatabaseMigrator {
        private readonly WebApiPruebaContext webApiPruebaContext;

        public DatabaseMigrator(WebApiPruebaContext webApiPruebaContext) {
            this.webApiPruebaContext = webApiPruebaContext;
        }

        public Task Migrate() {
            return webApiPruebaContext.Database.MigrateAsync();
        }
    }
}