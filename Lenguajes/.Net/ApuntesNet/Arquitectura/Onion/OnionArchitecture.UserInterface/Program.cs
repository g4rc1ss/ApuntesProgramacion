using Microsoft.Extensions.DependencyInjection;
using OnionArchitecture.ApplicationServices;
using OnionArchitecture.Database;
using OnionArchitecture.Domain.Interfaces.UserInterfaceContracts;
using OnionArchitecture.UserInterface;

var serviceCollection = new ServiceCollection();
serviceCollection.AddUserIntefaces();
serviceCollection.AddApplicationService();
serviceCollection.AddDatabase();

var provider = serviceCollection.BuildServiceProvider();
provider.GetRequiredService<IListaUsuarioUI>().PintarListaUsuarios();
