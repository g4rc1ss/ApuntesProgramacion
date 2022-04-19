using System.Net.Http.Json;
using CleanArchitecture.Shared.Peticiones.Responses.User.Usuarios;
using Microsoft.AspNetCore.Components;

namespace CleanArchitecture.Ejemplo.BlazorApp.Pages
{
    public partial class Index
    {
        [Inject]
        private HttpClient _httpClient { get; set; }

        internal List<UserResponse>? UsersResponse { get; set; }

        protected override async Task OnInitializedAsync()
        {
            UsersResponse = await _httpClient.GetFromJsonAsync<List<UserResponse>>("ListaUsuarios/ObtenerListadoUsuarios");
        }
    }
}
