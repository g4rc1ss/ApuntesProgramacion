using System;
using System.Linq;

namespace CursosAndEstudioCsharp._12_LINQ._01_IntroduccionToLINQ
{
    internal class IntroduccionLINQ
    {
        public IntroduccionLINQ()
        {
            // Specify the data source.
            var scores = new int[] { 97, 92, 81, 60 };

            // Define the query expression.
            var scoreQuery = from score in scores
                             where score > 90
                             select score;

            // Execute the query.
            foreach (var i in scoreQuery)
            {
                Console.Write(i + " ");
            }
        }
    }
}
