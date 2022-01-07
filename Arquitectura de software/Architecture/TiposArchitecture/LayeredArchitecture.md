# N-Layers Architecture
Esta arquitectura generalmente se suele implementar con 3 capas, siendo estas: **Presentacion**, **Negocio** y **Datos**.

1. **Presentacion**: La capa de presentacion contiene, en el caso de un API, el conjunto de controladores y la configuracion para obtener las conexiones. En una aplicacion de escritorio, deberia de contener las GUI del proyecto.  
Es el punto de entrada del proyecto, aqui es donde se realizará la inyeccion de dependencias, configuracion con Base de Datos, etc.  
1. **Logica de negocio**: Es donde residen los programas que se ejecutan, se reciben las peticiones del usuario y se envían las respuestas tras el proceso.
1. **Datos**: En la capa de datos se gestiona el acceso a los datos de la aplicación. Se emplean gestores de bases de datos que realizan la recuperación y el almacenamiento físico de los datos a partir de solicitudes de la capa de negocio.
![Captura de pantalla 2022-01-07 175053](https://user-images.githubusercontent.com/28193994/148578304-a9d6f1d5-c29d-4978-96de-d4cff9622c0d.png)

El beneficio al final es que, al tener todo separado en varias capas, podemos modificar funcionalidades y los cambios se trasladarán desde la ultima capa, hacia la primera. 

Si sustituimos la capa de datos, por ejemplo, porque hemos decidido pasar de `MySQL` a `Postgresql`, lo mas probable es que tengamos que modificar algo en la capa de negocio y en la de presentacion.

Si sustituimos la capa de presentacion, porque queremos hacer que la aplicacion sea desktop, no se deberia de tener que modificar ni la capa de negocio, ni la de datos.