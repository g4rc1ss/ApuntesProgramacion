﻿namespace BlazorAuthenticationJWT.Peticiones.Response;

public class JsonWebToken
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
}
