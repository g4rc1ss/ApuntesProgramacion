using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParallelExecutionCode.EjecucionEnParalelo {
    internal class UsoParallelBucles {
        // Info en la teoria ubicada en BackEnd > Sintaxis > Teoria > 2_UsoAvanzado
        public void BucleFor() {
            var x = 10000;

            Parallel.For(0, x, (i, state) => {
                Console.WriteLine($"LAMBDA  --  {i}, {state.IsStopped}");
            });

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Teclea algo para seguir con la ejecucion");
            Console.Read();
            Parallel.For(0, x, delegate (int i, ParallelLoopState state) {
                Console.WriteLine($"DELEGATE  --  {i}");
            });

            Console.WriteLine("---------------------------------");
            // opt menos usada
            Parallel.For(0, x, MetodoParaFor);
        }
        public void BucleForEach() {
            var listas = new List<string>(new string[] {
                "Hola",
                "Soy",
                "Asier",
                "Garcia",
                "Barrenengoa",
                "Programador",
                "Junior"
            });

            Parallel.ForEach(listas, (linea, state) => {
                Console.WriteLine($"ForEach LAMBDA  --  {linea}");
            });

            var option = new ParallelOptions {
                MaxDegreeOfParallelism = 1
            };
            Parallel.ForEach(listas, option, linea => {
                Console.WriteLine($"ForEach con Options -- {linea}");
            });

            Parallel.ForEach(listas, delegate (string linea, ParallelLoopState state) {
                Console.WriteLine($"ForEach DELEGADO  --  {linea}");
            });

            Parallel.ForEach(listas, MetodoParaForEach);
        }

        private void MetodoParaFor(int i) {
            Console.WriteLine($"METODO NOMBRE  --  {i}");
        }

        private void MetodoParaForEach(string linea, ParallelLoopState state) {
            Console.WriteLine($"ForEach METODO NOMBRE  --  {linea}");
        }
    }
}
