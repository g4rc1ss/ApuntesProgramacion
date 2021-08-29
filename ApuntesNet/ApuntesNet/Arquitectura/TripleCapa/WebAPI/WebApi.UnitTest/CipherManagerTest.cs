using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPI.Backend.Business.BusinessManager.CipherManager;

namespace WebApi.UnitTest {

    [TestClass]
    public class CipherManagerTest {
        private static CipherManager cipherManager;

        [ClassInitialize]
        public static void Inicializar(TestContext testContext) {
            cipherManager = new CipherManager();
        }

        [TestMethod]
        public void CifrarTexto() {
            var textoCifrar = "Hola, me llamo Ralph";
            var resultadoCifrado = "`a�3�K������woA��*6:u?��I";

            var textoCifrado = cipherManager.CifrarText(textoCifrar);

            Assert.AreEqual(textoCifrado, resultadoCifrado);
        }
    }
}
