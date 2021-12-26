using Builder.Query;
using Builder.Query.Extensions;

var claseImplementaBuilder1 = new PatronBuilder();
var claseImplementaBuilder2 = new PatronBuilder();
var claseImplementaBuilder3 = new PatronBuilder();


var query1 = claseImplementaBuilder1
    .Select("Id")
    .From("table")
    .Where("1 = 1")
    .OrderBy("Id")
    .Build();

var query2 = claseImplementaBuilder2
    .From("table")
    .Build();

var query3 = claseImplementaBuilder3
    .Select("Hola")
    .From("tableFrom")
    .Build();

Console.WriteLine(query1);
Console.WriteLine(query2);
Console.WriteLine(query3);

Console.ReadKey();
