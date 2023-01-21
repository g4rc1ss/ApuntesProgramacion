using Microsoft.AspNetCore.DataProtection;

namespace DataProtectionLibrary.Protections
{
    internal class DataProtectionExample
    {
        private readonly IDataProtector _dataProtector;
        public DataProtectionExample(IDataProtectionProvider dataProtection)
        {
            _dataProtector = dataProtection.CreateProtector("purpose.para.encriptar.identificar.los.datos");
        }

        public void ProtectingData()
        {
            var stringToEncrypt = "Valor original que vamos a encriptar";
            Console.WriteLine($"{stringToEncrypt}");

            var valorEncriptado = _dataProtector.Protect(stringToEncrypt);
            Console.WriteLine($"{valorEncriptado}");

            var valorDesencriptado = _dataProtector.Unprotect(valorEncriptado);
            Console.WriteLine($"{valorDesencriptado}");

        }
    }
}
