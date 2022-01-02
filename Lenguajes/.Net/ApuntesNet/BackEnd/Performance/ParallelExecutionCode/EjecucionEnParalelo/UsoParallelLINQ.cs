using System;
using System.Linq;

namespace ParallelExecutionCode.EjecucionEnParalelo
{
    internal class UsoParallelLINQ
    {
        public UsoParallelLINQ()
        {
            var source = Enumerable.Range(100, 20000);

            // Result sequence might be out of order.
            var parallelQuery = from num in source.AsParallel()
                                where num % 10 == 0
                                select num;

            // Para leer una ParallelLinQ es muy recomendable usar el metodo ForAll.
            parallelQuery.ForAll((e) =>
            {
                Console.WriteLine($"PARALLEL LINQ - FOR ALL - {e}");
            });

            // Or use foreach to merge results first.
            foreach (var n in parallelQuery)
            {
                Console.WriteLine($"PARALLEL LINQ - parallelQuery - {n}");
            }

            // You can also use ToArray, ToList, etc as with LINQ to Objects.
            var parallelQuery2 = (from num in source.AsParallel()
                                  where num % 10 == 0
                                  select num).ToArray();

            foreach (var x in parallelQuery2)
            {
                Console.WriteLine($"PARALLEL LINQ - parallelQuery2 - {x}");
            }

            // Method syntax is also supported
            var parallelQuery3 = source.AsParallel().Where(n => n % 10 == 0).Select(n => n);

            foreach (var z in parallelQuery3)
            {
                Console.WriteLine($"PARALLEL LINQ - parallenQuery3 - {z}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadLine();
        }
    }
}
