using System.Security.Cryptography;
using System.Text;

namespace HashTables;

public class HashTables<TKey, TValue>
{
    private int size;
    private ObjectKeyValue[] data;
    private uint[] hashIndex;
    private int count;

    public HashTables()
    {
        data = new ObjectKeyValue[3];
        hashIndex = new uint[3];
    }

    public void Add(TKey key, TValue value)
    {
        ArgumentNullException.ThrowIfNull(key);

        var hash = GetHashCode(key);
        var indexHash = GetIndexHash((uint)hash);
        var dataIndex = hashIndex[indexHash];

        var objectKeyValue = data[dataIndex];
        // Verificamos si la key existe
        while (true)
        {
            if (hash == objectKeyValue.hashCode)
            {
                throw new ArgumentException("Key already exists");
            }

            if (objectKeyValue.next == -1)
            {
                break;
            }

            if (objectKeyValue.next == default && objectKeyValue.hashCode == default)
            {
                break;
            }

            objectKeyValue = data[objectKeyValue.next];
        }

        // Verificamos el tamaño de los array
        if (size == data.Length)
        {
            Array.Resize(ref data, data.Length * 2);
            Array.Resize(ref hashIndex, hashIndex.Length * 2);
            RehashData();
            dataIndex = GetIndexHash((uint)hash);
        }

        // Insertamos en el indice del hash en data, si tiene contenido, registramos en el next
        
        var dataIndexValue = data[dataIndex];
        data[size].key = key;
        data[size].value = value;
        data[size].hashCode = (uint)hash;
        data[size].next = -1;

        while (true)
        {
            var next = dataIndexValue.next;

            if (next == -1 && dataIndexValue.hashCode != 0)
            {
                data[dataIndex].next = size;
                break;
            }

            if (dataIndexValue.hashCode == 0)
            {
                hashIndex[indexHash] = (uint)size;
                break;
            }

            dataIndexValue = data[next];
        }

        size++;
        count++;
    }

    private void RehashData()
    {
        var rehashIndex = new uint[hashIndex.Length];
        for (var i = 0; i < data.Length; i++)
        {
            var hash = data[i].hashCode;
            var index = (uint)(hash % hashIndex.Length);
            rehashIndex[index] = (uint)i;
        }

        hashIndex = rehashIndex;
    }

    public TValue Get(TKey key)
    {
        ArgumentNullException.ThrowIfNull(key);

        var hash = GetHashCode(key);
        var indexHash = GetIndexHash((uint)hash);
        var index = hashIndex[indexHash];

        var objectKeyValue = data[index];
        // Verificamos si la key existe
        while (true)
        {
            if (hash == objectKeyValue.hashCode)
            {
                return objectKeyValue.value;
            }

            if (objectKeyValue.next == -1)
            {
                break;
            }

            if (objectKeyValue.next == default && objectKeyValue.hashCode == default)
            {
                break;
            }

            objectKeyValue = data[objectKeyValue.next];
        }

        return default;
    }

    private int GetHashCode(TKey key)
    {
        if (typeof(TKey).IsValueType)
        {
            return key.GetHashCode();
        }

        if (key is string stringKey)
        {
            using var sha256 = SHA256.Create();
            var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(stringKey));
            return BitConverter.ToInt32(hash, 0);
        }

        return EqualityComparer<TKey>.Default.GetHashCode(key);
    }


    // Metodo copiado de la clase Dictionary
    private uint GetIndexHash(uint hash)
    {
        return hash % (uint)hashIndex.Length;
    }


    private struct ObjectKeyValue
    {
        public TKey key = default!;
        public TValue value = default!;
        public uint hashCode;
        public int next;

        public ObjectKeyValue()
        {
            hashCode = 0;
            next = -1;
        }
    }
}