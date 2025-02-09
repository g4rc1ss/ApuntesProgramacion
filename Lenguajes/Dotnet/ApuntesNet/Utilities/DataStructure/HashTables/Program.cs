var dictionary = new Dictionary<string, string>();

if (true)
{
    dictionary.Add("0", "value1");
    dictionary.Add("1", "value1");
    dictionary.Add("2", "value1");
    dictionary.Add("Mundo3", "value1");
    dictionary.Add("Mundo4", "value1");
}

dictionary.TryGetValue("Mundo", out var value);
Console.WriteLine(value);


var hashTable = new HashTables.HashTables<string, int>();

for (var i = 0; i < 100; i++)
{
    hashTable.Add(i.ToString(), i);
}

hashTable.Get("50");
hashTable.Get("63");
hashTable.Get("30");