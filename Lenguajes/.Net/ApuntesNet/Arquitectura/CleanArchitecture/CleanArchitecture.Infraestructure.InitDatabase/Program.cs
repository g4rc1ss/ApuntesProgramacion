using System.Reflection;
using CleanArchitecture.Infraestructure.DataEjemplo;
using CleanArchitecture.Infraestructure.DataEntityFramework.Contexts;
using CleanArchitecture.Infraestructure.DataEntityFramework.Entities;
using CleanArchitecture.Infraestructure.InitDatabase;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureLogging((hostContext, log) =>
{
    log.AddConfiguration(hostContext.Configuration);
    log.AddConsole();
});

builder.ConfigureServices((hostContext, services) =>
{
    services.AddOptions();

    services.AddDbContextPool<KeyDataProtectorContext>(options =>
    {
        options.UseSqlServer(hostContext.Configuration.GetConnectionString(nameof(KeyDataProtectorContext)), sql => 
            sql.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName));
    });
    services.AddDataProtection()
        .SetApplicationName("Aplicacion.CleanArchitecture")
        .PersistKeysToDbContext<KeyDataProtectorContext>();

    services.AddPooledDbContextFactory<EjemploContext>(options =>
    {
        options.UseSqlServer(hostContext.Configuration.GetConnectionString(nameof(EjemploContext)), sql =>
            sql.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName));
    });

    services.AddDbContextPool<EjemploContext>(options =>
    {
        options.UseSqlServer(hostContext.Configuration.GetConnectionString(nameof(EjemploContext)), sql =>
            sql.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName));
    });

    services.AddIdentity<User, Role>(options =>
    {
        options.Password.RequiredLength = 8;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;

    }).AddEntityFrameworkStores<EjemploContext>();

    services.AddTransient<DatabaseMigrator>();
    services.AddTransient<DatabaseInitializer>();
    services.AddTransient<MigrationService>();

    services.Scan(scan => scan.FromAssemblyOf<DatabaseInitializer>()
    .AddClasses(@class => @class.AssignableTo<IDataSeed>())
    .As<IDataSeed>()
    .WithTransientLifetime());
});

var app = builder.Build();

var migrations = app.Services.GetRequiredService<MigrationService>();

await migrations.StartAsync(CancellationToken.None);
