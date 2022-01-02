using TaskManagement.Tareas;

namespace TaskManagement
{
    internal class Program
    {
        private static void Main()
        {
            //Tareas normales de codigo
            CreacionTareas.Task2();
            CreacionTareas.Task1();
            _ = CreacionTareas.Task3("task3");
        }
    }
}
