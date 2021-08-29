using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait.Async {
    public class Asincronia {
        internal void LlamadaAwaitMetodo() {
            Thread.Sleep(10000);
            Console.WriteLine("Codigo NO asincrono terminado");
        }

        internal async Task LlamadaAwaitMetodoAsync() {
            await MetodoAsync();
        }

        private Task MetodoAsync() {
            return Task.Run(() => {
                Thread.Sleep(10000);
                Console.WriteLine("Codigo asincrono terminado");
            });
        }
    }
}
