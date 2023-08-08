# Cancelacion de Subprocesos
El proceso que invoca una o más operaciones cancelables, por ejemplo creando un nuevo subproceso o tarea, pasa el token a cada operación. Las operaciones individuales pueden pasar a su vez copias del token a otras operaciones. Si en algun momento, el objeto que creó el token solicita que las operaciones se detengan, este cambio se propagará al resto de operaciones y estas seran canceladas

Para implementar el proceso de cancelación:
- Crear una instancia de `CancellationTokenSource`, que administra y envía una notificación de cancelación a los tokens.
- Pasar el token devuelto por la propiedad `CancellationTokenSource.Token` para cada `Task`
- Proporciona un mecanismo para que cada tarea o subproceso responda a la cancelación.
- Llamar al método `CancellationTokenSource.Cancel` para proporcionar una notificación de cancelación.

![Cancellation Token](https://github.com/g4rc1ss/ApuntesProgramacion/assets/28193994/a6d540b7-1338-4df6-9aee-3170004967c8)

El uso de `CancellationToken` y `CancellationTokenSource` en .NET ofrece varias ventajas, especialmente cuando se trata de tareas largas.

- Mejora de la capacidad de respuesta: Cuando una operación se vuelve innecesaria o no deseada (por ejemplo, un usuario decide cancelar una descarga), la cancelación permite que la aplicación responda inmediatamente y libere recursos

- Control y gestión de recursos: La cancelación de subprocesos permite liberar recursos asociados con operaciones que ya no son necesarias.

- Gestión de estados y coherencia: La cancelación controlada garantiza que las operaciones se detengan de manera ordenada, lo que puede ser crucial para mantener la coherencia

- Manejo de errores más limpio: Al lanzar una excepción `OperationCanceledException` cuando se produce una cancelación, se puede capturar y manejar de manera específica, lo que facilita la identificación de operaciones canceladas en el código.

- Escalabilidad: Al usar cancelación de subprocesos, las aplicaciones pueden gestionar eficientemente muchas operaciones simultáneas y cancelarlas según sea necesario.

- Flexibilidad en operaciones asincronas: Se puede propagar la cancelación a través de cadenas de llamadas asincronas, lo que permite una gestión uniforme de la cancelación en operaciones complejas.

- Aplicar en diferentes escenarios: La cancelación de subprocesos es útil en diversos contextos, como operaciones de E/S intensivas, llamadas a servicios web, etc.

> Es recomendable hacer uso del CancellationToken en el uso de Task y operaciones asincronas siempre que se pueda, por ejemplo, en un API, si un usuario cuando va a entrar reinicia o cierra la pestaña, al perderse la conexion, el CancellationToken se propagaria y se usarian menos recursos de operacione I/O
