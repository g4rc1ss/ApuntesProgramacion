using CleanArchitecture.Infraestructure.DataEjemplo;
using CleanArchitecture.Infraestructure.DataEntityFramework.Contexts;
using CleanArchitecture.Infraestructure.DataEntityFramework.Entities;
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

    services.AddDataProtection()
        .SetApplicationName("Aplicacion.CleanArchitecture")
        .AddDataProtectionEntityFramework(hostContext.Configuration);

    services.AddIdentityEntityFramework(hostContext.Configuration);
    services.AddEntityFrameworkRepositories(hostContext.Configuration);

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
