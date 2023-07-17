# RabbitMQ
Un software que actua como `Message Broker` pensado en su uso para la programacion asincrona y distribuida.

En lugar de que 2 aplicaciones realice una comunicacion entre si, una(productor) envia el objeto al servicio de RabbitMQ y la otra(consumidor), recibe el objeto y lo trata.

El uso principal de este sistema es la reduccion de tiempos de espera para tareas que no necesitemos una respuesta inmediata, por ejmplo, enviar un correo, sincronizar una base de datos, sincronizar caches, etc.

# Broker
El concepto de broker en RabbitMQ es simplemente la union de las `Queues` y los `Exchanges` mediante los `Bindings`.

La forma de agregar un mensaje a una cola en Rabbit es a traves de los exchange, este para saber a que colas tiene que enviar el mensaje, se indican a traves de los `bindings`
![https://www.netmentor.es/imagen/473fb12c-a4ed-4cdb-a728-6fd04472807f.jpg](https://github.com/g4rc1ss/ApuntesProgramacion/assets/28193994/c600c85c-3324-4b5c-832e-128b1c702cb2)


## Queues
RabbitMQ trabaja con un sistema de colas, un mensaje entra por un lado y se envia al consumidor por el otro. Una vez el mensaje ha desaparecido de la cola, no se puede recuperar.
![https://www.netmentor.es/imagen/1dfa3bea-8ff1-43ac-857c-4f9724a24c16.jpg](https://github.com/g4rc1ss/ApuntesProgramacion/assets/28193994/512b03f5-2fb0-4c07-a3da-940e14e7219b)

### DeadLetter


## Bindigns



## Exchange
Se encargan de transferir los mensajes a las colas configuradas en el exchange basandose en la `routing key`.

**Routing Key**: Cuando definimos una cola, le asignamos un nombre como por ejemplo `subscription.weatherForecast`. pues la routing key en un mensaje se encarga de indicar a que cola/s tiene que ir basandose en esos nombres.

### Direct
Solamente enviará el mensaje a los bindings que tengan configurada la misma routing key
https://www.netmentor.es/imagen/eee1a7aa-1c80-4ed2-9c86-46e087045f5f.jpg![image](https://github.com/g4rc1ss/ApuntesProgramacion/assets/28193994/cc942d98-4c85-41f4-9d61-34501b7b7fe4)

### Topic
Hace uso de la routing key para comprobar los bindings 

### Header

### fanout
