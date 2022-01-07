using OnionArchitecture.Domain.Interfaces.BusinessContracts;
using OnionArchitecture.Domain.Interfaces.UserInterfaceContracts;

namespace OnionArchitecture.UserInterface.ListaUsuarios
{
    public class ListaUsuariosUI : IListaUsuarioUI
    {
        private readonly IUserManager _userManager;

        public ListaUsuariosUI(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public async Task PintarListaUsuarios()
        {
            var listaUsuarios = await _userManager.GetUsersList();

            foreach (var item in listaUsuarios)
            {
                Console.WriteLine($"{item.Name}------------{item.Email}");
            }
        }
    }
}
