using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using WebAPI.Backend.Business.BusinessManager.CipherManager;

namespace WebApi.Benchmarks.BenchmarkManager {
    internal class CipherManagerBench {
        private const string TEXTO_CIFRAR = "Hola, me llamo Ralph";
        private static CipherManager cipherManager;

        [GlobalSetup]
        internal void Inicializar() {
            cipherManager = new CipherManager();
        }

        [Benchmark]
        internal void Login() {
            cipherManager.CifrarText(TEXTO_CIFRAR);
        }
    }
}
