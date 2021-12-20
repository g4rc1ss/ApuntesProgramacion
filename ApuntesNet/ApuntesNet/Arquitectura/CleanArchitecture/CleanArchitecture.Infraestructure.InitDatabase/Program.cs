using CleanArchitecture.ApplicationCore.Dominio.EntidadesDatabase.Identity;
using CleanArchitecture.Infraestructure.DatabaseConfig;
using CleanArchitecture.Infraestructure.InitDatabase;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureLogging((hostContext, log) => {
    log.AddConfiguration(hostContext.Configuration);
    log.AddConsole();
});

builder.ConfigureServices((hostContext, services) => {
    services.AddOptions();
    services.AddDbContextFactory<EjemploContext>(options => {
        options.UseSqlServer(hostContext.Configuration.GetConnectionString(nameof(EjemploContext)), sql => {
            sql.MigrationsAssembly(typeof(Program).Assembly.FullName);
        });
    });
    services.AddScoped(p => p.GetRequiredService<IDbContextFactory<EjemploContext>>().CreateDbContext());

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
