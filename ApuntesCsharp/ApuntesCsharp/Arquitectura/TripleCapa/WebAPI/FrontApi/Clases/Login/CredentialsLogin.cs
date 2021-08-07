namespace FrontApi.Clases.Login {
    public class CredentialsLogin {
        public string Username { get; set; }
        public string Password { get; set; }

        public CredentialsLogin(string username, string password) {
            Username = username;
            Password = password;
        }
    }
}
