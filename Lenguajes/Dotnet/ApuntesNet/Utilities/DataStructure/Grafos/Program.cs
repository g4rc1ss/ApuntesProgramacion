using Grafos;

var graph = new GraphObject<string, string>();

graph.Add("Hola", "adios");
graph.Add("Hola", "buenas");

var result = graph.Get("Hola");
foreach (var data in result)
{
    Console.WriteLine(data);
}