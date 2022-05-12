using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapperBenchmark.Fakes.Clases;

namespace AutoMapperBenchmark
{
    public static class Helper
    {
        public static ClaseOrigen Origin => new()
        {
            IdRelacion = 10190,
            Valor1 = "Valor",
            Valor2 = "Valor",
            Valor3 = "Valor",
            Valor4 = "Valor",
            Valor5 = "Valor",
            Valor6 = "Valor",
            Valor7 = "Valor",
            Valor8 = "Valor",
            Valor9 = "Valor",
            Valor10 = "Valor",
            Valor11 = "Valor",
            Valor12 = "Valor",
            Valor13 = "Valor",
            Valor14 = "Valor",
            Valor15 = "Valor",

        };

        public static ClaseRelacionadaConOrigen ClaseRelacion => new()
        {
            ClaseOriginId = 10190,
            NombreCampo = "ValorClaseRelacionada",
        };
    }
}
