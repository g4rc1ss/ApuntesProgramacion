using System;
using System.Threading.Tasks;

namespace TaskManagement.Tareas {
    public class CreacionTareas {
        /// <summary>
        /// Creamos un metodo asincrono porque vamos a ejecutar el await 
        /// Con Task.Run( () => NombreMetodo() ) ejecutamos la tarea sobre ese metodo
        /// </summary>
        public async void Task1() {
            await Task.Run(() => MetodoTask1());
        }

        private void MetodoTask1() {
            for (var x = 0; x < 1000; x++)
                Console.WriteLine("task1");
        }

        /// <summary>
        /// En esta funcion se enseña Task<T>, que es lo mismo que Task, pero
        /// devolviendo un tipo de objeto, en este caso string.
        /// </summary>
        /// <param name="mostrar">tambien se muestra como pasar datos a metodos</param>
        /// <returns>nada, simplemente para demostrar como devolver otro tipo de obj</returns>
        public async Task<string> Task3(string mostrar) {
            return await Task.Run(() => MetodoTask3(mostrar));
        }

        private string MetodoTask3(string mostrar) {
            for (var x = 0; x < 1000; x++)
                Console.WriteLine(mostrar);
            return null;
        }

        /// <summary>
        /// Creamos una variable Tarea, que va a ser de tipo Task.
        /// ejecutamos Task.Run(() => {aqui dentro va codigo que se va a ejecutar como una tarea}
        /// ejecutamos un for para simular un proceso largo y luego el return del metodo que necesitamos ejecutar
        /// una vez realizado ejecutamos el await tarea
        /// 
        /// El funcionamiento de esto es que ejecuto una tarea para ejecutar un codigo largo y que va a durar tiempo
        /// y cuando necesito los datos de ese metodo que he ejecutado uso el await para recibirlos, osea, el return
        /// </summary>
        public async void Task2() {
            var tarea = Task.Run(() => {
                for (var i = 0; i < 100000000; i++)
                    for (var z = 0; z < 10; z++) ;

                return Task2async();
            });
            Console.WriteLine(await tarea);
        }
        private string Task2async() {
            return "mensaje";
        }
    }
}
