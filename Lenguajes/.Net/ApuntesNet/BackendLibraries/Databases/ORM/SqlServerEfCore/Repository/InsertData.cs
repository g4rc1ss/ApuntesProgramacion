using SqlServerEfCore.Database;
using SqlServerEfCore.Database.Entities;

namespace SqlServerEfCore.Repository
{
    public class InsertData
    {
        private readonly EntityFrameworkSqlServerContext _frameworkSqlServerContext;

        public InsertData(EntityFrameworkSqlServerContext frameworkSqlServerContext)
        {
            _frameworkSqlServerContext = frameworkSqlServerContext;
        }

        internal Task<int> InsertDataAsync()
        {
            var usuarioAgregar = new Usuario
            {
                Nombre = "Nombre del usuario",
                Edad = 10,
                FechaHoy = DateTime.Now,
                PuebloId = 20,
                PuebloIdNavigation = new Pueblo
                {
                    Nombre = "Soria"
                }
            };

            _frameworkSqlServerContext.Usuarios.Add(usuarioAgregar);
            return _frameworkSqlServerContext.SaveChangesAsync();
        }
    }
}
