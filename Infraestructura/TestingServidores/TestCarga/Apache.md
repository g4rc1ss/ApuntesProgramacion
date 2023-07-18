# Apache Benchmark
Una herramienta diseñada por apache para realizar pruebas de carga contra servidores en red.

Instalaremos la herramienta y en una terminal podemos realizar lo siguiente:
```powershell
ab -c 10 -n 1000 http://127.0.0.1:8080/
```
Los parámetros más importantes son:
- `-c` **concurrencia**: número de peticiones concurrentes. Se lanzan tantos hilos como indique este parámetro, así que nunca tendremos más peticiones en vuelo que este número.
- -`n` **peticiones**: número total de peticiones a lanzar.
- `-t` **segundos**: tiempo de pruebas, tras el que ab dejará de recibir peticiones.


Cuando ejecutamos, podemos obtener un resultado como el siguiente:

```Powershell
Concurrency Level:      10
Time taken for tests:   3.334 seconds
Complete requests:      10000
Requests per second:    2999.08 [#/sec] (mean)
Time per request:       3.334 [ms] (mean)
Time per request:       0.333 [ms] (mean, across all concurrent requests)

Percentage of the requests served within a certain time (ms)
    50%      3
    66%      3
    75%      3
    80%      4
    90%      4
    95%      5
    98%      7
    99%     10
    100%     27 (longest request)
```
El resultado lo que nos muestra es:
- **Concurrency Level**: El nivel de concurrencia aplicado, cuando "usuarios" a la vez han estado conectados
- **Time taken for tests**: Duración de la prueba
- **Complete requests**: Numero de request enviadas que han sido completadas
- **Requests per second**: Numero máximo de peticiones por segundo que se han soportado en el servidor
- **Time per request**: Tiempo medio de respuesta de las peticiones
- **Time per request**: Tiempo medio entre las peticiones concurrentes
