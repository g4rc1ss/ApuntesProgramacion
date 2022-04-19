using System.Net.Http.Json;
using CleanArchitecture.Shared.Peticiones.Responses.User.Usuarios;
using Microsoft.AspNetCore.Components;

namespace CleanArchitecture.Ejemplo.BlazorApp.Pages
{
    public partial class Index
    {
        [Inject]
        private HttpClient _httpClient { get; set; }

        private bool ShowModal { get; set; }

        internal List<UserResponse>? UsersResponse { get; set; }
        internal UserResponse? UserDetailResponse { get; set; }

        protected override async Task OnInitializedAsync()
        {
            UsersResponse = await _httpClient.GetFromJsonAsync<List<UserResponse>>("ListaUsuarios/ObtenerListadoUsuarios");
        }

        public async Task SetModalOpenAsync(int idUsuario)
        {
            UserDetailResponse = await _httpClient.GetFromJsonAsync<UserResponse>($"UsuariosDetalle/ObtenerDetalleUsuarioGet/{idUsuario}");
            ShowModal = true;
            await Task.Delay(300);
            StateHasChanged();
        }

        public async Task SetModalCloseAsync()
        {
            ShowModal = false;
            await Task.Delay(300);
            StateHasChanged();
        }
    }
}
