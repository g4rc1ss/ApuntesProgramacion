using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlServerEfCore.Database;

namespace SqlServerEfCore.Repository
{
    internal class DeleteData
    {
        private readonly EntityFrameworkSqlServerContext _frameworkSqlServerContext;

        public DeleteData(EntityFrameworkSqlServerContext frameworkSqlServerContext)
        {
            _frameworkSqlServerContext = frameworkSqlServerContext;
        }

        internal Task<int> DeleteDataAsync()
        {
            var usuarios = (from user in _frameworkSqlServerContext.Usuarios
                            where user.Edad < 22
                            select user).ToList();
            _frameworkSqlServerContext.RemoveRange(usuarios);
            return _frameworkSqlServerContext.SaveChangesAsync();
        }
    }
}
