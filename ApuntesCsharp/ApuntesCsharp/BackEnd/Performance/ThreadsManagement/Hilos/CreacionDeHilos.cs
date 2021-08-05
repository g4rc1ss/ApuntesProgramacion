using System;


namespace ThreadsManagement.Hilos {
    public class CreacionDeHilos {
        public void FuncHilo1() {
            for (var x = 0; x < 1000; x++)
                Console.WriteLine("hilo1");
        }

        public void FuncHilo2(string text) {
            for (var x = 0; x < 1000; x++)
                Console.WriteLine(text);
        }
    }
}
