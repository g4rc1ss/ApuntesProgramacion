using WebApiExample.Database.DTO;
using WebApiExample.Shared.DTO.Request;

namespace WebApiExample.Business.Manager {
    public class User {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }

        public static implicit operator User(UserDatabase userDatabase) {
            return new User {
                Id = userDatabase.UserID.ToString(),
                Nombre = userDatabase.Nombre,
                Apellidos = userDatabase.Apellidos
            };
        }

        public static implicit operator User(UserRequest userRequest) {
            return new User {
                Nombre = userRequest.Nombre,
                Apellidos = userRequest.Apellido
            };
        }
    }
}
