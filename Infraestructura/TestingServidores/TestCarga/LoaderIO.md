# Loader.io

[Loader.io](https://loader.io) es una plataforma CLOUD que permite hacer pruebas de carga simulando cargas de usuarios y duracion de las peticiones para probar los servicios que le indiquemos.

Simplemente nos registramos en la web de ellos y tienen un plan gratuito que te permite hasta 10k de usuarios con 1m de duración, si necesitamos mas, hay que pagar.

<img width="1276" alt="image" src="https://github.com/g4rc1ss/ApuntesProgramacion/assets/28193994/a40c1984-a7c6-421c-a802-aabf56336ed4">
Nos vamos a `Test` y a `New test` y configuramos los parametros, tipo de request, url, etc. Que necesitamos.

> Es importante destacar que cuando creemos el test, nos va a pedir una verificacion que tendremos que implementarla en el API y que este responda el codigo que nos indican

Una vez configurado, podemos ejecutar el test y ver las estadisticas.

<img width="1276" alt="image" src="https://github.com/g4rc1ss/ApuntesProgramacion/assets/28193994/189ca3f0-b92e-4c40-9d31-d0dcd9926eac">

<img width="1276" alt="image" src="https://github.com/g4rc1ss/ApuntesProgramacion/assets/28193994/5fb9798e-49d8-4f88-8d18-0d7970a1fa5a">

En estas imagenes se ven 2 pruebas de carga sobre un servidor con CPU 1 Core, 2GB de RAM y 20GB Almacenamiento

1. Se ha realizado una prueba de carga contra un ExpressJS con Node 18 y una BBDD MongoDB, desplegadas con Docker
2. Se ha realizado una prueba de carga contra un servidor ASP.NET Core 7 con una base de datos MongoDB desplegadas ambas mediante Docker en el servidor

Vemos que el rendimiento es similar con entre 80 y 90 ms de tiempo de respuesta.
