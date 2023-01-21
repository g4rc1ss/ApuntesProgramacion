using System.Collections;

namespace Iterator
{
    public class Iterator<T> : IEnumerator<T>
    {
        private T[] collection;
        private int indiceActual;
        private T objetoActual;
        private bool disposedValue = false;

        public Iterator(T[] collection)
        {
            this.collection = collection;
            indiceActual = -1;
            objetoActual = default;
        }

        public T Current => objetoActual;

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            Console.WriteLine("Pasando por el Iterator personalizado");
            if (++indiceActual >= collection.Length)
            {
                return false;
            }
            else
            {
                objetoActual = collection[indiceActual];
            }
            return true;
        }

        public void Reset()
        {
            indiceActual = -1;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    collection = null;
                    objetoActual = default;
                }
            }
            disposedValue = true;
        }
    }
}
