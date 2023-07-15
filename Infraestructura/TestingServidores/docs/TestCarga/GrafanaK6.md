# Grafana K6
Una plataforma propiedad de `grafana` que utiliza servicios cloud como `AWS`, `Azure`, etc. Para hacer pruebas de performance

Nos vamos a la [pagina oficial](https://grafana.com/products/cloud/k6/?src=k6io) y nos registramos de forma gratuita donde tendremos una version de prueba de 14 dias, luego a pagar.

Para crear un test es bastante intuitivo, ponemos el tipo de peticion, API a consultar, path, body, etc.
<img width="1047" alt="image" src="https://github.com/g4rc1ss/ApuntesProgramacion/assets/28193994/73c62c9b-1784-4f72-80aa-11df9ba9b276">

Si nos vamos a `Options` podemos configurar el test con el volumen de peticiones que queremos probar, usuarios concurrentes y tiempo de duracion del test.

<img width="1047" alt="image" src="https://github.com/g4rc1ss/ApuntesProgramacion/assets/28193994/85801add-582c-4c97-bd64-f3a2ec8e9b14">

Le damos al `RUN` y esperamos a que finalice el test donde nos devuelve estadisticas de las peticiones fallidas, completadas, etc.

