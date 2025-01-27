using Stacks;

var arrayElementos = new int[5] { 5, 2, 3, 4, 5 };

var queue = new StackCollection<int>(arrayElementos);
queue.Push(1);
var result = queue.Pop();

Console.WriteLine(result == 1);

var list = queue.ToList();

Console.WriteLine(string.Join(", ", list));


var queue2 = new StackCollection<int>();
queue2.Push(1);
queue2.Push(2);
var valor = queue2.Pop();
Console.WriteLine(valor == 2);
queue2.Push(5);
queue2.ToList();

Console.WriteLine(string.Join(", ", queue2));