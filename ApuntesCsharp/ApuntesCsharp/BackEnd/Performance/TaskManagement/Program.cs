using TaskManagement.Tareas;

namespace TaskManagement {
    internal class Program {
        private static void Main(string[] args) {
            //Tareas normales de codigo
            new CreacionTareas().Task2();
            new CreacionTareas().Task1();
            _ = new CreacionTareas().Task3("task3");
        }
    }
}
