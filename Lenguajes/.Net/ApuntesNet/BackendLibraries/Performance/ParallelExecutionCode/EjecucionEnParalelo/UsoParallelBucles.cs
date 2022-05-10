using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParallelExecutionCode.EjecucionEnParalelo
{
    internal class UsoParallelBucles
    {
        // Info en la teoria ubicada en BackEnd > Sintaxis > Teoria > 2_UsoAvanzado
        public void BucleFor()
        {
            Parallel.For(0, 10000, (i, state) =>
            {
                Console.WriteLine($"LAMBDA  --  {i}, {state.IsStopped}");
            });
        }

        public void BucleForEach()
        {
            var listas = new List<string> {
                "Hola",
                "Yo",
                "Me",
                "Llamo",
                "Ralph",
            };

            var option = new ParallelOptions
            {
                MaxDegreeOfParallelism = 2
            };

            Parallel.ForEach(listas, option, (linea, state) =>
            {
                if (state.IsStopped)
                {
                    state.Stop();
                    return;
                }
                Console.WriteLine($"ForEach LAMBDA  --  {linea}");
            });
        }
    }
}
