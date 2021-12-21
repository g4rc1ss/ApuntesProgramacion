using DesktopUI.Backend.Data;
using DesktopUI.Migrations;
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
    services.AddDbContextFactory<ContextoSqlServer>(options =>
    {
        options.UseSqlServer(hostContext.Configuration.GetConnectionString(nameof(ContextoSqlServer)), sql =>
        {
            sql.MigrationsAssembly(typeof(Program).Assembly.FullName);
        });
    });
    services.AddScoped(p => p.GetRequiredService<IDbContextFactory<ContextoSqlServer>>().CreateDbContext());

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

