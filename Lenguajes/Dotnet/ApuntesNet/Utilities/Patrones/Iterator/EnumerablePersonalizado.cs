using System.Collections;

namespace Iterator
{
    public class EnumerablePersonalizado<T> : IEnumerable<T>
    {
        public T[] enumerable;

        public EnumerablePersonalizado(int maxIndex)
        {
            enumerable = new T[maxIndex];
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Iterator<T>(enumerable);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
