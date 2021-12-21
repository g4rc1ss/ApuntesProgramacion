using CleanArchitecture.ApplicationCore.Dominio.EntidadesDatabase.Identity;
using CleanArchitecture.Infraestructure.DatabaseConfig;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Infraestructure.InitDatabase.Seeds;

public class SeedGenerator : IDataSeed
{
    private readonly UserManager<User> userManager;
    private readonly RoleManager<Role> roleManager;

    public SeedGenerator(UserManager<User> userManager, RoleManager<Role> roleManager)
    {
        this.userManager = userManager;
        this.roleManager = roleManager;
    }

    // Datos a rellenar en el contexto de MySql
    public async Task Seed(EjemploContext webApiPruebaContext, CancellationToken cancellationToken = default)
    {
        await InicializarDatosEguzkimendiBBDD();
    }

    private async Task InicializarDatosEguzkimendiBBDD()
    {
        try
        {
            var rolAdministrador = new Role()
            {
                Name = "Administrador",
                NormalizedName = "Administrador"
            };
            var rolUsuario = new Role()
            {
                Name = "Usuario",
                NormalizedName = "Usuario"
            };
            await roleManager.CreateAsync(rolAdministrador);
            await roleManager.CreateAsync(rolUsuario);

            var usuario = new User()
            {
                UserName = "prueba",
                NormalizedUserName = "Nombre completo",
                Email = "jaja@prueba.com",
                PhoneNumber = "655666555",
                SecurityStamp = new Guid().ToString()
            };
            // Creamos el usuario
            await userManager.CreateAsync(usuario, "Prueba2020!");
            // Agregamos el rol de administrador al usuario creado en el paso anterior
            await userManager.AddToRoleAsync(usuario, "Administrador");
        }
        catch (Exception)
        {
            Console.WriteLine("");
        }
    }
}
