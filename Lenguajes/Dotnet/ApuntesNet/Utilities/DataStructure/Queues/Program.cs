var arrayElementos = new int[5] { 5, 2, 3, 4, 5 };

var queue = new Queues.Queue<int>(arrayElementos);
queue.Enqueue(1);
var result = queue.Dequeue();

Console.WriteLine(result == 5);

var list = queue.ToList();

Console.WriteLine(string.Join(", ", list));


var queue2 = new Queues.Queue<int>();
queue2.Enqueue(1);
queue2.Enqueue(2);
var valor = queue2.Dequeue();
Console.WriteLine(valor == 1);
queue2.Enqueue(5);
queue2.ToList();

Console.WriteLine(string.Join(", ", queue2));