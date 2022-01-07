using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnionArchitecture.ApplicationServices;
using OnionArchitecture.Database;
using OnionArchitecture.Domain.Interfaces.UserInterfaceContracts;
using OnionArchitecture.UserInterface;

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices(services =>
{
    services.AddUserIntefaces();
    services.AddApplicationService();
    services.AddDatabase();
});

var app = builder.Build();

var listaUsuariosUI = app.Services.GetRequiredService<IListaUsuarioUI>();

await listaUsuariosUI.PintarListaUsuarios();
