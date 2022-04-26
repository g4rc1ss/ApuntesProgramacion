using System.Security.Cryptography.X509Certificates;
using CleanArchitecture.Domain.Database.Identity;
using CleanArchitecture.Infraestructure.DatabaseConfig;
using CleanArchitecture.Infraestructure.InitDatabase;
using Microsoft.AspNetCore.DataProtection;
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
    services.AddDbContextFactory<EjemploContext>(options =>
    {
        options.UseSqlServer(hostContext.Configuration.GetConnectionString(nameof(EjemploContext)), sql =>
        {
            sql.MigrationsAssembly(typeof(Program).Assembly.FullName);
        });
    });
    services.AddScoped(p => p.GetRequiredService<IDbContextFactory<EjemploContext>>().CreateDbContext());

    services.AddDbContextPool<KeyDataProtectorContext>(options =>
    {
        options.UseSqlServer(hostContext.Configuration.GetConnectionString(nameof(KeyDataProtectorContext)), sql =>
        {
            sql.MigrationsAssembly(typeof(Program).Assembly.FullName);
        });
    });


    services.AddDataProtection()
        .PersistKeysToDbContext<KeyDataProtectorContext>()
        .SetApplicationName("Aplicacion.CleanArchitecture");

    services.AddIdentity<User, Role>()
        .AddEntityFrameworkStores<EjemploContext>();

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
