using System.IO;

namespace CursosAndEstudioCsharp._07_ConceptosAvanzados.LiberacionDeMemoria
{
    internal class UsingClass
    {
        public void UsingExample()
        {
            var buffer = new char[50];
            using (var s = new StreamReader("File1.txt"))
            {
                var charsRead = 0;
                while (s.Peek() != -1)
                {
                    charsRead = s.Read(buffer, 0, buffer.Length);
                    //
                    // Process characters read.
                    //   
                }
            }
        }
    }
}
