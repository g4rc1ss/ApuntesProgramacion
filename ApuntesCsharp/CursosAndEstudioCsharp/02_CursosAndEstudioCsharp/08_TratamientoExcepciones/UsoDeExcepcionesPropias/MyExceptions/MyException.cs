using System;

namespace CursosAndEstudioCsharp._08_TratamientoExcepciones.UsoDeExcepcionesPropias.MyExceptions
{
    internal class MyException : ApplicationException
    {
        public MyException() : base("Esta es la custom exception")
        {

        }
    }
}
