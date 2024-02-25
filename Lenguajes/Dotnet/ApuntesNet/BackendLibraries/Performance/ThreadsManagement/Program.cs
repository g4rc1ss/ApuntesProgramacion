using ThreadsManagement.Hilos;


new Thread(CreacionDeHilos.FuncHilo1).Start();
new Thread(() => CreacionDeHilos.FuncHilo2("hilo2")).Start();
