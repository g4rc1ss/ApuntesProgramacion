using Memento;


var originator = new Originator("Super-duper-super-puper-super.");
var caretaker = new Caretaker(originator);

caretaker.Backup();
originator.DoSomething();

caretaker.Backup();
originator.DoSomething();

caretaker.Backup();
originator.DoSomething();

Console.WriteLine();
caretaker.ShowHistory();

Console.WriteLine("\nClient: Now, let's rollback!\n");
caretaker.Undo();

Console.WriteLine("\n\nClient: Once more!\n");
caretaker.Undo();

Console.WriteLine("\n\nClient: Once more!");
caretaker.Undo();

Console.WriteLine();

Console.WriteLine("Pulsa una tecla para finalizar");
Console.ReadKey();
