using System.Text;

namespace BackApi {
    public class Prueba {
        public Respuesta<string> CifrarText(string text) {
            return new Respuesta<string>(Encoding.UTF8.GetString(new AESHelper().EncriptarTexto(text)));
        }
    }
}
