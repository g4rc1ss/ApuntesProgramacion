using CleanArchitecture.Ejemplo.API.Extensions;
using CleanArchitecture.Ejemplo.API.Middlewares;
using CleanArchitecture.Infraestructure.DatabaseConfig;
using MediatR;

var builder = WebApplication.CreateBuilder(args);
builder.Host.AddLoggerConfiguration(builder.Configuration.GetConnectionString(nameof(EjemploContext)));

// Add services to the container.
builder.Services.AddAppConfiguration(builder.Configuration);
builder.Services.AddRedisCache();
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<EjemploMiddleware>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Cuando se van a realizar solicitudes sobre el mismo origen, por ejemplo, ejecutando una app Blazor se requiere permitirlo mediante una policita de configuracion
builder.Services.AddCors(option =>
{
    option.AddPolicy("open", builder => builder.AllowAnyOrigin().AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("open");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<EjemploMiddleware>();

app.MapControllers();

app.Run();
