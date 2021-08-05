using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionesInternetCSharp.Email {
    public class EnviarMailInyeccionDependenciasParaProtector {
        public EnviarMailInyeccionDependenciasParaProtector() {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDataProtection();
            var services = serviceCollection.BuildServiceProvider();

            var instance = ActivatorUtilities.CreateInstance<EnviarEmail>(services);
            instance.EnvioMail();
        }
    }
}
