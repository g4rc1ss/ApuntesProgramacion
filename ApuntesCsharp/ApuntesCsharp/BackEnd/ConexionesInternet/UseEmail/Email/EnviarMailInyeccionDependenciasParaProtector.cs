using Microsoft.Extensions.DependencyInjection;

namespace ConexionesInternetCSharp.Email {
    public class EnviarMailInyeccionDependenciasParaProtector {
        public EnviarMailInyeccionDependenciasParaProtector() {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDataProtection();
            var services = serviceCollection.BuildServiceProvider();

            var instance = ActivatorUtilities.CreateInstance<nviarEmail>(services);
            instance.EnvioMail();
        }
    }
}
