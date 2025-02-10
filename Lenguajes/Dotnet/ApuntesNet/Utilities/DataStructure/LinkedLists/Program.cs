using LinkedLists;

var listaNueva = new LinkedObjectList<string>();
listaNueva.Add("A");
listaNueva.Add("B");


var deep = listaNueva;
while (true)
{
    var (value, nextNode) = deep.Get();
    Console.WriteLine(value);

    if (nextNode == null)
    {
        break;
    }

    deep = nextNode;
}