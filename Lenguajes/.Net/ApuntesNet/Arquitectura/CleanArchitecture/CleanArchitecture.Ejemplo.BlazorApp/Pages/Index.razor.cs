using System.Net.Http.Json;
using CleanArchitecture.Shared.Peticiones.Responses.User.Usuarios;
using Microsoft.AspNetCore.Components;

namespace CleanArchitecture.Ejemplo.BlazorApp.Pages
{
    public partial class Index
    {
        [Inject]
        private HttpClient _httpClient { get; set; }

        private string? ShowModal { get; set; }
        private string? Display { get; set; } = "d-none";

        internal List<UserResponse>? UsersResponse { get; set; }
        internal UserResponse? UserDetailResponse { get; set; }

        protected override async Task OnInitializedAsync()
        {
            UsersResponse = await _httpClient.GetFromJsonAsync<List<UserResponse>>("ListaUsuarios/ObtenerListadoUsuarios");
        }

        public async Task SetModalOpenAsync(int idUsuario)
        {
            UserDetailResponse = await _httpClient.GetFromJsonAsync<UserResponse>($"UsuariosDetalle/ObtenerDetalleUsuarioGet/{idUsuario}");
            Display = "d-block";
            await Task.Delay(10);
            ShowModal = "show";
            StateHasChanged();
        }

        public async Task SetModalCloseAsync()
        {
            ShowModal = "";
            await Task.Delay(400);
            Display = "d-none";
            StateHasChanged();
        }
    }
}
