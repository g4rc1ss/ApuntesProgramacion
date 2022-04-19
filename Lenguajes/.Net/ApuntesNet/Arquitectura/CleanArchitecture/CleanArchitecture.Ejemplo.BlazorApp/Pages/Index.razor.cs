using System.Net.Http;
using System.Net.Http.Json;
using CleanArchitecture.Shared.Peticiones.Responses.User.Usuarios;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Caching.Memory;

namespace CleanArchitecture.Ejemplo.BlazorApp.Pages
{
    public partial class Index
    {
        [Inject]
        private IHttpClientFactory? HttpClientFactory { get; set; }
        [Inject]
        private IMemoryCache MemoryCache { get; set; }

        private HttpClient? _httpClientApiCA;

        private bool ShowModal { get; set; }
        internal List<UserResponse>? UsersResponse { get; set; }
        internal UserResponse? UserDetailResponse { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _httpClientApiCA = HttpClientFactory?.CreateClient("API-CleanArchitecture");
            UsersResponse = await _httpClientApiCA?.GetFromJsonAsync<List<UserResponse>>("ListaUsuarios/ObtenerListadoUsuarios");
        }

        public async Task SetModalOpenAsync(int idUsuario)
        {
            if (!MemoryCache.TryGetValue($"DetalleUsuario-{idUsuario}", out UserResponse response))
            {
                response = await _httpClientApiCA?.GetFromJsonAsync<UserResponse>($"UsuariosDetalle/ObtenerDetalleUsuarioGet/{idUsuario}");
                MemoryCache.Set($"DetalleUsuario-{idUsuario}", response);
            }
            UserDetailResponse = response;
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
