namespace ApiJWT.Configuration;

public class JwtConfig
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string SignInKey { get; set; }
}
