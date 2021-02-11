using System;

namespace CursosAndEstudioCsharp._08_TratamientoExcepciones
{
    internal class IntroduccionExcepciones
    {
        public IntroduccionExcepciones()
        {
            try
            {
                //bloque de código
                object obj = "aa";
                var variable = (int)obj;
            }
            catch (OutOfMemoryException)
            {
                //capturamos la exception
            }
            catch (DivideByZeroException)
            {
                //capturamos la exception
            }
            catch (InvalidCastException)
            {
                //capturamos la exception
            }
            catch (Exception)
            {
                //capturamos la exception
            }
            finally
            {
                //siempre se ejecuta
            }
        }
    }
}
