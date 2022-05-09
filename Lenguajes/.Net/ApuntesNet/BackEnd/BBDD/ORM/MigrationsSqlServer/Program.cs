using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MigrationsSqlServer;
using SqlServerEfCore.Database;

var builder = Host.CreateDefaultBuilder();

builder.ConfigureAppConfiguration(options =>
{

});

builder.ConfigureServices((hostContext, services) =>
{
    services.AddDbContextPool<EntityFrameworkSqlServerContext>(dbContextBuilder =>
    {
        dbContextBuilder.UseSqlServer(hostContext.Configuration.GetConnectionString(nameof(EntityFrameworkSqlServerContext)),
            options =>
            {
                options.MigrationsAssembly(typeof(MigrationService).Assembly.FullName);
            });
    });
        services.AddTransient<MigrationService>();
});

var app = builder.Build();

var migration = app.Services.GetRequiredService<MigrationService>();

await migration.MigrateApplicationAsync();
