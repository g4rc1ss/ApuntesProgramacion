using SqlServerEfCore.Database;

namespace SqlServerEfCore.Repository
{
    public class UpdateData
    {
        private readonly EntityFrameworkSqlServerContext _frameworkSqlServerContext;

        public UpdateData(EntityFrameworkSqlServerContext frameworkSqlServerContext)
        {
            _frameworkSqlServerContext = frameworkSqlServerContext;
        }

        internal Task<int> UpdateDataAsync()
        {
            var idPueblo = 1;

            var usuario = (from user in _frameworkSqlServerContext.Usuarios
                           where user.PuebloIdNavigation.Id == idPueblo
                           select user).Single();

            usuario.Nombre = "cnifvbdilcbsuyvrg";

            _frameworkSqlServerContext.Update(usuario);
            return _frameworkSqlServerContext.SaveChangesAsync();
        }
    }
}
