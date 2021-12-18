using CleanArchitecture.ApplicationCore.Dominio.EntidadesDatabase.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infraestructure.DatabaseConfig {
    public class EjemploContext : IdentityDbContext<User, Role, int> {

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Role> Role { get; set; }

        public EjemploContext() {

        }

        public EjemploContext(DbContextOptions<EjemploContext> contextOptions) : base(contextOptions) {

        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            // Cambio de nombre de las tablas de identity
            builder.Entity<User>().ToTable("Users");
            builder.Entity<Role>().ToTable("Roles");
            builder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins");
            builder.Entity<IdentityUserRole<int>>().ToTable("UserRoles");
            builder.Entity<IdentityUserToken<int>>().ToTable("UserTokens");
        }
    }
}
