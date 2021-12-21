using Microsoft.Extensions.DependencyInjection;

namespace UseEmail.Email
{
    public class EnviarMailInyeccionDependenciasParaProtector
    {
        public EnviarMailInyeccionDependenciasParaProtector()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDataProtection();
            var services = serviceCollection.BuildServiceProvider();

            var instance = ActivatorUtilities.CreateInstance<EnviarEmail>(services);
            instance.EnvioMail();
        }
    }
}
