﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait.Async
{
    public class Asincronia
    {
        internal void LlamadaMetodo()
        {
            Thread.Sleep(10000);
            Console.WriteLine("Codigo NO asincrono terminado");
        }

        internal async Task CpuAsync()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(10000);
                Console.WriteLine("Codigo asincrono CPU terminado");
            });
        }

        internal async Task ESAsync()
        {
            var cliente = new HttpClient();
            var descarga = await cliente.GetByteArrayAsync("https://docs.microsoft.com/en-us/");
            Console.WriteLine("Codigo asincrono E/S terminado");
        }

        internal async Task ExecuteIEnumerableAsync()
        {
            await foreach (var item in RangeAsync(0, int.MaxValue))
            {
            }
            Console.WriteLine("Codigo asincrono IAsyncEnumerable terminado");
        }

        private async IAsyncEnumerable<int> RangeAsync(int start, int count)
        {
            for (; start < count; start++)
            {
                await Task.Delay(10);
                yield return start + 1;
            }
        }
    }
}