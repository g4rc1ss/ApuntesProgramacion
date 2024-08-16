Un software que actua como `Message Broker` pensado en su uso para la programacion asincrona y distribuida.

En lugar de que 2 aplicaciones realicen una comunicacion entre si, una(productor) envia el objeto al servicio de RabbitMQ y la otra(consumidor), recibe el objeto y lo trata.

El uso principal de este sistema es la reduccion de tiempos de espera para tareas que no necesitemos una respuesta inmediata, por ejmplo, enviar un correo, sincronizar una base de datos, sincronizar caches, etc.


El funcionamiento de RabbitMQ es el siguiente:
![RabbitMQ general](.img/RabbitMQ.webp)

- **Producer**: Envia un mensaje a Rabbit, por ejemplo, un json
- **Exchange**: Es el componente que, a traves de las Routing Key decide hacia que colas tiene que enviar los mensajes recibidos
- **Routing Key**: Es un valor que tiene que venir dado en el mensaje y se usa para evaluar hacia donde tiene que ir el mensaje, en el ejemplo, una routingkey seria `shop.user.*`
- **Binding Key**: Es un valor asociado a la QUEUE que se usa para compararlo con la `Routing Key` y de esta manera saber a donde hay que dirigir el mensaje.
- **Queue**: Almacena los mensajes en memoria y los va enviando a los consumer a través del sistema `FIFO`
- **Consumer**: Es un proceso externo al protocolo de rabbit y su misión es esperar a recibir el mensaje para procesarlo como sea necesario

> Como se puede ver en la imagen, una cola puede tener varios consumer, rabbit se encargará de enviar el mensaje de esa cola a todos los suscriptores

> Cuando el mensaje es procesado y se recibe `ACK`, es eliminado de la memoria y desaparece de rabbit **todos los mensajes van a la memoria**


# Exchange
Se encargan de transferir los mensajes a las colas configuradas en el exchange a traves de los bindings basandose en la `routing key` y la `binding key`.

- **Binding Key**: Cuando definimos una cola, establecemos el valor de la binding key para saber que mensajes tienen que ir hacia esa cola, por ejemplo `subscription.weatherForecast`

- **Routing Key**: Cuando enviamos un mensaje, indicamos la clave de enrutado para que rabbit sepa hacia que colas tiene que enviarlo

## Direct
Cuando llega el mensaje, comprueba si la **routing key** que recibimos coindide con la **binding key** configurada entre el exchange y la cola
![RabbitMQ Exchange Direct](.img/rabbit_exchange_direct.png)

## fanout
El concepto de binding key y routing key es totalmente eliminado, simplemente recibe el mensaje y lo inyecta a todas las colas que rabbit tiene disponibles
![RabbitMQ Exchange Direct](.img/rabbit_exchange_fanout.png)

## Header
El tipo header funciona como el direct, pero en vez de **routing keys** se utilizan **cabeceras o parametros**

![RabbitMQ Exchange Direct](.img/rabbit_exchange_header.png)

En la configuración entre el exchange y la cola se establece las cabeceras que se esperan y  el campo **x-match** con los valores:
- **all**: Indica que tienen que coincidir todas las cabeceras
- **any**: Indica que tienen que coindicidr alguna de las cabeceras

El mensaje nos trae las cabeceras y se evaluan en el exchange para dirigia a la cola

## Topic
Se configura el match a nivel de la binding key y se hace mediante el uso de *wildcards*

- **\***o *single level wildcard*: hará match con una única palabra. Por ejemplo `shop.*.created` coincidirá siempre con cualquier mensaje de creación de recursos dentro de `shop` como `shop.order.created` o `shop.product.created`

- **#** o *multi-level wildcard*: hará match con cualquier número de palabras. Por ejemplo, `shop.#` coincidirá con cualquier mensaje del contexto `shop` como `shop.order.created` o `shop.user.registered`

![RabbitMQ Exchange Topic](.img/rabbit_exchange_topic.png)

# Queues
RabbitMQ trabaja con un sistema de colas, un mensaje entra por un lado y se envia al consumidor por el otro. Una vez el mensaje ha desaparecido de la cola, no se puede recuperar.
![RabbitMQ Queues](.img/rabbit_queues.png)

## DeadLetter
Cuando un mensaje no puede ser enrutado a su cola de destino o cuando se agota su tiempo de vida, RabbitMQ puede redirigir ese mensaje a otra cola designada como la "dead-letter"

El uso de dead-letter exchanges proporciona una manera de manejar mensajes que no pueden ser procesados en el flujo normal de trabajo, en lugar de perderlos o enviarlos indefinidamente a una cola de espera.

1. **Mensaje rechazado**: Si un consumidor rechaza o no puede manejar un mensaje específico, se puede redirigir a la cola de mensajes no entregados para su posterior revisión o reintentos.

2. **Tiempo de vida del mensaje agotado**: Cuando un mensaje ha estado en una cola durante un tiempo determinado y no ha sido procesado, puede ser enviado automáticamente a la cola de mensajes no entregados.

3. **Cola llena**: Si la cola de destino está llena, se pueden enviar los mensajes excedentes a la cola de mensajes no entregados para evitar pérdida de datos.

4. **Error en el enrutamiento**: Si un mensaje no puede ser enrutado a la cola deseada debido a un error en la configuración, se puede redirigir a la cola de mensajes no entregados para su posterior análisis.
