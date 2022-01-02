using WebApiExample.Business.Manager;

namespace WebApiExample.Database.DTO
{
    public class UserDatabase
    {
        public Guid UserID { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }

        public static implicit operator UserDatabase(User user)
        {
            return new UserDatabase
            {
                Nombre = user.Nombre,
                Apellidos = user.Apellidos
            };
        }
    }
}
