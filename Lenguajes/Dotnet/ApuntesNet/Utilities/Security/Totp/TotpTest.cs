﻿using static Totp.Libs.Totp;
using static Totp.Libs.Base32;

namespace Totp;

public class TotpTest
{
    private static string claveSecreta = "";
    private static string claveSecreta2 = "";

    public TotpTest()
    {
        claveSecreta = Encode("12345");
        claveSecreta2 = Encode("12346");
    }

    [Fact]
    public void TestValidaOk()
    {
        while (RemainingSeconds(30) == 0)
        {
            Thread.Sleep(100);
        }

        string? totpCode = GeneraTotp(claveSecreta);
        (bool valido, long intervalo) = ValidaTotp(totpCode, claveSecreta);
        Assert.True(valido);
        Assert.True(intervalo > 0);
    }

    [Fact]
    public void TestValidaSiguienteVentanaDeTiempo()
    {
        int seconds = RemainingSeconds(3);
        while (seconds == 0)
        {
            Thread.Sleep(100);
            seconds = RemainingSeconds(3);
        }

        string? totpCode = GeneraTotp(claveSecreta, 3);
        (bool valido, long intervalo) = ValidaTotp(totpCode, claveSecreta, 3);
        Assert.True(valido);
        Assert.True(intervalo > 0);

        Thread.Sleep(seconds * 1000);
        while (RemainingSeconds(3) == 0)
        {
            Thread.Sleep(100);
        }

        (bool valido2, long intervalo2) = ValidaTotp(totpCode, claveSecreta, 3);
        Assert.True(valido2);
        Assert.Equal(intervalo, intervalo2);
    }

    [Fact]
    public void TestErrorTiempoCaducado()
    {
        int seconds = RemainingSeconds(3);
        while (seconds == 0)
        {
            Thread.Sleep(100);
            seconds = RemainingSeconds(3);
        }

        string? totpCode = GeneraTotp(claveSecreta, 3);
        (bool valido, long intervalo) = ValidaTotp(totpCode, claveSecreta, 3);
        Assert.True(valido);
        Assert.True(intervalo > 0);

        Thread.Sleep((seconds + 3) * 1000);
        while (RemainingSeconds(3) == 0)
        {
            Thread.Sleep(100);
        }

        (bool valido2, long intervalo2) = ValidaTotp(totpCode, claveSecreta, 3);
        Assert.False(valido2);
        Assert.NotEqual(intervalo, intervalo2);
        Assert.True(intervalo2 > intervalo);
    }

    [Fact]
    public void TestErrorCodigoIncorrecto()
    {
        GeneraTotp(claveSecreta);
        (bool valido, long intervalo) = ValidaTotp("123456", claveSecreta);
        Assert.False(valido);
    }

    [Fact]
    public void TestErrorOtraClave()
    {
        string? totpCode = GeneraTotp(claveSecreta);
        (bool valido, long intervalo) = ValidaTotp(totpCode, claveSecreta2);
        Assert.False(valido);
    }
}