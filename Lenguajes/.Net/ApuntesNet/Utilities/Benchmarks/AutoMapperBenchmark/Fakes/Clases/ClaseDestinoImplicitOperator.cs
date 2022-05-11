using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperBenchmark.Fakes.Clases
{
    public class ClaseDestinoImplicitOperator : ClaseDestino
    {

        public static implicit operator ClaseDestinoImplicitOperator(ClaseOrigen origin)
        {
            return new ClaseDestinoImplicitOperator
            {
                Valor1 = origin.Valor1,
                Valor2 = origin.Valor2,
                Valor3 = origin.Valor3,
                Valor4 = origin.Valor4,
                Valor5 = origin.Valor5,
                Valor6 = origin.Valor6,
                Valor7 = origin.Valor7,
                Valor8 = origin.Valor8,
                Valor9 = origin.Valor9,
                Valor10 = origin.Valor10,
                Valor11 = origin.Valor11,
                Valor12 = origin.Valor12,
                Valor13 = origin.Valor13,
                Valor14 = origin.Valor14,
                Valor15 = origin.Valor15,
            };
        }
    }
}
