namespace CleanArchitecture.ApplicationCore.Shared.Peticiones.Responses.User.Usuarios
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public bool TieneDobleFactor { get; set; }
    }
}
