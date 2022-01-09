using System;
using System.Threading.Tasks;
using TaskManagement.Tareas;


var x = CreacionTareas.Esperando();
var z = CreacionTareas.Esperando();
//Tareas normales de codigo
CreacionTareas.Task2();
CreacionTareas.Task1();
_ = CreacionTareas.Task3("task3");

await Task.WhenAll(x, z);

Console.ReadKey();
