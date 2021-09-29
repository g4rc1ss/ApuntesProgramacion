using WebApiExample.Business.Manager;

namespace WebApiExample.Shared.DTO.Response {
    public class UserResponse {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }

        public static implicit operator UserResponse(User usuario) {
            return new UserResponse {
                Nombre = usuario.Nombre,
                Apellidos = usuario.Apellidos
            };
        }
    }
}
