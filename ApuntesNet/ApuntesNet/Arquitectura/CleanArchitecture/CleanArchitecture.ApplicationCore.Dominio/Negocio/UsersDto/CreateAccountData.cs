﻿namespace CleanArchitecture.ApplicationCore.Dominio.Negocio.UsersDto;

public class CreateAccountData
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string NormalizedUserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}
