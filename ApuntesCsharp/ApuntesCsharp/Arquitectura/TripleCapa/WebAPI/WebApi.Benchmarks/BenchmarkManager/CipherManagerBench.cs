using BenchmarkDotNet.Attributes;
using WebAPI.Backend.Business.BusinessManager.CipherManager;

namespace WebApi.Benchmarks.BenchmarkManager {

    [SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.NetCoreApp31)]
    [SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net50)]
    public class CipherManagerBench {
        private const string TEXTO_CIFRAR = "Hola, me llamo Ralph";
        private static CipherManager cipherManager;

        [GlobalSetup]
        public void Inicializar() {
            cipherManager = new CipherManager();
        }

        [Benchmark]
        public void CifrarTexto() {
            cipherManager.CifrarText(TEXTO_CIFRAR);
        }
    }
}
