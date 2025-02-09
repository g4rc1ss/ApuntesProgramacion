using System.Security.Cryptography;
using System.Text;

namespace HashTables;

public class HashTables<TKey, TValue>
{
    private int size;
    private ObjectKeyValue[] data;
    private int[] hashIndex;
    private int count;

    public HashTables()
    {
        data = new ObjectKeyValue[3];
        hashIndex = Enumerable.Range(0, 3).Select(x => -1).ToArray();
    }

    public void Add(TKey key, TValue value)
    {
        ArgumentNullException.ThrowIfNull(key);

        var existsValue = TryGet(key).exists;
        if (existsValue)
        {
            throw new KeyNotFoundException("Key was not found");
        }

        // Verificamos el tamaño de los array
        if (size == data.Length)
        {
            Resize();
        }

        var hash = GetHashCode(key);
        var indexHash = GetIndexHash(hash);
        var dataIndex = hashIndex[indexHash];


        data[size].key = key;
        data[size].value = value;
        data[size].hashCode = (uint)hash;
        data[size].next = -1;

        if (dataIndex > -1)
        {
            var dataIndexValue = data[dataIndex];
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
                    hashIndex[indexHash] = size;
                    break;
                }

                dataIndexValue = data[next];
            }
        }
        else
        {
            hashIndex[indexHash] = size;
        }

        size++;
        count++;
    }

    private void Resize()
    {
        Array.Resize(ref data, data.Length * 2);
        Array.Resize(ref hashIndex, hashIndex.Length * 2);
        RehashData();
    }

    private void RehashData()
    {
        var copyData = new ObjectKeyValue[this.data.Length];
        Array.Copy(data, copyData, copyData.Length);
        Array.Clear(data);
        Array.Clear(hashIndex);
        hashIndex = Enumerable.Range(0, hashIndex.Length).Select(x => -1).ToArray();
        var oldSize = size;
        size = 0;
        count = 0;

        for (var i = 0; i < oldSize; i++)
        {
            Add(copyData[i].key, copyData[i].value);
        }
    }

    public TValue Get(TKey key)
    {
        var (value, _) = TryGet(key);
        return value;
    }

    private (TValue value, bool exists) TryGet(TKey key)
    {
        ArgumentNullException.ThrowIfNull(key);

        var hash = GetHashCode(key);
        var indexHash = GetIndexHash(hash);
        var index = hashIndex[indexHash];
        if (index == -1)
        {
            return default;
        }

        var objectKeyValue = data[index];
        // Verificamos si la key existe
        while (true)
        {
            if ((uint)hash == objectKeyValue.hashCode)
            {
                return (objectKeyValue.value, true);
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
    private uint GetIndexHash(int hash)
    {
        return (uint)hash % (uint)hashIndex.Length;
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