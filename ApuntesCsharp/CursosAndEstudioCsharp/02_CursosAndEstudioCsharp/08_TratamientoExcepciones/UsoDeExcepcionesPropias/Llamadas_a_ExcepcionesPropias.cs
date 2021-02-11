using System;
using CursosAndEstudioCsharp._08_TratamientoExcepciones.UsoDeExcepcionesPropias.MyExceptions;

namespace CursosAndEstudioCsharp._08_TratamientoExcepciones.UsoDeExcepcionesPropias
{
    internal class Llamadas_a_ExcepcionesPropias
    {
        public Llamadas_a_ExcepcionesPropias()
        {
            try
            {
                //bloque de código
                var variable = Ejemplo();
            }
            catch (MyException)
            {
                //capturamos la exception
            }
            finally
            {
                //siempre se ejecuta
            }
        }

        public static int Ejemplo()
        {
            try
            {
                //bloque de código
                object obj = "aa";
                var variable = (int)obj;
            }
            catch (Exception)
            {
                throw new MyException();
            }

            return 1;
        }
    }
}
