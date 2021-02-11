using System;
using System.Threading.Tasks;

namespace SincroniaAsincronia.Async {
    public class Asincronia {
        public async Task<string> LlamadaAwaitMetodoAsync(string hola = "") {
            return await MetodoAsync(hola);
        }
        private async Task<string> MetodoAsync(string hola = "") {
            return await Task.Run(() => {
                for (var x = 0; x < 10000; x++)
                    Console.WriteLine("Ejecutando MetodoAsync");
                return hola;
            });
        }
    }
}
