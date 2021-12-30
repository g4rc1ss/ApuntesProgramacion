# Patrones Estructurales
Los patrones estructurales explican cómo ensamblar objetos y clases en estructuras más grandes, a la vez que se mantiene la flexibilidad y eficiencia de estas estructuras

## Adapter
También llamado: **Adaptador**

### Proposito

Es un patron de diseño estructural que permite la colaboración entre objetos con interfaces incompatibles.

### Problema

Supongamos que estamos realizando una aplicacion en la que obtenemos datos en un formato, como `XML` y necesitamos enviar esos datos a un API de analisis, pero dicho API espera recibirlos en formato `JSON` para tratar los datos.  
Un error seria modificar el API, puesto que este espera el estandard JSON, pero si enviamos los datos en XML, logicamente no funcionaria.

![image](https://user-images.githubusercontent.com/28193994/147789006-d7eb58d2-d51f-448e-8636-87cb7c5551c5.png)

### Solucion

Se puede crear un *adaptador*. Un objeto que se convierte la interfaz de un objeto, de forma que otro pueda ser capaz de comprenderla.

Un adaptador se encargar de convertir un objeto a otro tipo de datos sin que este sea consciente ni siquiera de la existencia de tal proceso. Esta pensado para ocultar la complejidad del codigo correspondiente de realizar la conversión con la logica de codigo normal que se deberia de seguir.

El funcionamiento es el siguiente.

1. El adaptador obtiene una interfaz compatible con uno de los objetos.
2. Haciendo uso de esta interfaz, se pueden invocar los metodos del adaptador.
3. Al recibir una llamada, el adaptador pasa la solicitud al siguiente objeto, pero en el formato que este espera.


![image](https://user-images.githubusercontent.com/28193994/147789015-58de18a2-7a44-4dc7-a24d-1557e194170a.png)


### Estructura

**Adatador de Objetos**

Utiliza el principio de composicion de objetos, implementa la interfaz de un objeto y envuelve el otro

![image](https://user-images.githubusercontent.com/28193994/147789037-76566722-bb97-45cd-b4ac-dfd085128bec.png)


**Clase Adaptadora**

Esta implementacion hace uso de la herencia, porque esta hereda interfaces de ambos objetos al mismo tiempo. ***Este metodo solo puede usarse en lenguajes con herencia multiple***

![image](https://user-images.githubusercontent.com/28193994/147789052-ac7414c0-bdd8-4658-9124-1f78ba4e87be.png)

## Bridge
También llamado: **Puente**

### Proposito

Permite dividir una clase grande, o un grupo de clases relacionadas, en dos jerarquias separadas(abstracción e implementación) que pueden desarrollarse de forma independiente.

### Problema

Digamos que tienes una clase geométrica Forma con un par de subclases: Círculo y Cuadrado. Deseas extender esta jerarquía de clase para que incorpore colores, por lo que planeas crear las subclases de forma Rojo y Azul. Sin embargo, como ya tienes dos subclases, tienes que crear cuatro combinaciones de clase, como CírculoAzul y CuadradoRojo.

![image](https://user-images.githubusercontent.com/28193994/147789061-66dd6a47-28ec-4789-9bec-9aa4ebade0d0.png)

Añadir nuevos tipos de forma y color a la jerarquía hará que ésta crezca exponencialmente. Por ejemplo, para añadir una forma de triángulo deberás introducir dos subclases, una para cada color. Y, después, para añadir un nuevo color habrá que crear tres subclases, una para cada tipo de forma. Cuanto más avancemos, peor será.

### Solucion

Este problema se presenta porque intentamos extender las clases de forma en dos dimensiones independientes: por forma y por color. Es un problema muy habitual en la herencia de clases.

El patrón Bridge intenta resolver este problema pasando de la herencia a la composición del objeto. Esto quiere decir que se extrae una de las dimensiones a una jerarquía de clases separada, de modo que las clases originales referencian un objeto de la nueva jerarquía, en lugar de tener todo su estado y sus funcionalidades dentro de una clase.

![image](https://user-images.githubusercontent.com/28193994/147789071-9428876f-35b8-4494-93af-b232139a4682.png)

Con esta solución, podemos extraer el código relacionado con el color y colocarlo dentro de su propia clase, con dos subclases: Rojo y Azul. La clase Forma obtiene entonces un campo de referencia que apunta a uno de los objetos de color. Ahora la forma puede delegar cualquier trabajo relacionado con el color al objeto de color vinculado. Esa referencia actuará como un puente entre las clases Forma y Color. En adelante, añadir nuevos colores no exigirá cambiar la jerarquía de forma y viceversa.

### Estructura

![image](https://user-images.githubusercontent.com/28193994/147789076-33c848cc-5677-4610-b695-e47826ead80d.png)

## Composite
También llamado: **Objeto Compuesto**

### Proposito



### Problema

El uso del patrón Composite sólo tiene sentido cuando el modelo central de tu aplicación puede representarse en forma de árbol.

Por ejemplo, imagina que tienes dos tipos de objetos: Productos y Cajas. Una Caja puede contener varios Productos así como cierto número de Cajas más pequeñas. Estas Cajas pequeñas también pueden contener algunos Productos o incluso Cajas más pequeñas, y así sucesivamente.

Digamos que decides crear un sistema de pedidos que utiliza estas clases. Los pedidos pueden contener productos sencillos sin envolver, así como cajas llenas de productos... y otras cajas. ¿Cómo determinarás el precio total de ese pedido?

![image](https://user-images.githubusercontent.com/28193994/147789084-9f2b76d2-986f-4645-8a9b-11e54a3d3b75.png)


### Solucion

El patrón Composite sugiere que trabajes con Productos y Cajas a través de una interfaz común que declara un método para calcular el precio total.

¿Cómo funcionaría este método? Para un producto, sencillamente devuelve el precio del producto. Para una caja, recorre cada artículo que contiene la caja, pregunta su precio y devuelve un total por la caja. Si uno de esos artículos fuera una caja más pequeña, esa caja también comenzaría a repasar su contenido y así sucesivamente, hasta que se calcule el precio de todos los componentes internos. Una caja podría incluso añadir costos adicionales al precio final, como costos de empaquetado.

La gran ventaja de esta solución es que no tienes que preocuparte por las clases concretas de los objetos que componen el árbol. No tienes que saber si un objeto es un producto simple o una sofisticada caja. Puedes tratarlos a todos por igual a través de la interfaz común. Cuando invocas un método, los propios objetos pasan la solicitud a lo largo del árbol.


### Estructura

![image](https://user-images.githubusercontent.com/28193994/147789097-41f20d11-21fa-4b83-b7a0-d415062464ac.png)


## Decorator
También llamado: **Decorador**

### Proposito

Es un patron de diseño estructural que te permite añadir funcionalidades a objetos colocando estos objetos dentro de objetos encapsuladores especiales que contienen estas funcionalidades.

### Problema

Nuestro sistema requiere que la funcionalidad de ciertos componentes pueda extenderse y modificarse en tiempo de ejecución. Además pretendemos que esta característica no se implemente mediante herencia para poder aprovechar al máximo las clases existentes sin introducir jerarquías complejas y extensas.

Se aplica cuando:
- Necesitamos añadir responsabilidades a objetos individuales de forma dinámica y transparente
- Se pueden revocar responsabilidades antes asignadas a nuestros objetos.
- La extensión mediante herencia viola los principios SOLID.
- Necesitamos extender la funcionalidad de una clase pero la herencia no es una solución viable.
- Necesitamos extender la funcionalidad de un objeto en tiempo de ejecución e incluso eliminarla si fuera necesario.

### Solucion

Crearemos un nuevo peldaño en la jerarquía de clases llamado Decorator que encapsulará las nuevas responsabilidades. Esta nueva clase se encarga de redirigir las peticiones al componente original además de permitir la modificación de ciertos aspectos antes y después de dicha redirección. Con esta estructura, podremos añadir nuevas funcionalidades con forma de decoradores de manera recursiva.

### Estructura

![image](https://user-images.githubusercontent.com/28193994/147789109-536dce79-cc09-4a44-8dad-9a1bafe31640.png)

## Facade
También llamado: **Fachada**

### Proposito

Patrón de diseño estructural que proporciona una interfaz simplificada a una biblioteca, un framework o cualquier otro grupo complejo de clases.

### Problema

Imagina que debes lograr que tu código trabaje con un amplio grupo de objetos que pertenecen a una sofisticada biblioteca o framework. Normalmente, debes inicializar todos esos objetos, llevar un registro de las dependencias, ejecutar los métodos en el orden correcto y así sucesivamente.

Como resultado, la lógica de negocio de tus clases se vería estrechamente acoplada a los detalles de implementación de las clases de terceros, haciéndola difícil de comprender y mantener.

Se aplica cuando:
- Nuestro sistema cliente tiene que acceder a parte de la funcionalidad de un sistema complejo.
- Hay tareas o configuraciones muy frecuentes y es conveniente simplificar el código de uso.
- Necesitamos hacer que una librería sea más legible.
- Nuestros sistemas clientes tienen que acceder a varias APIs y queremos simplificar dicho acceso.

### Solucion

La solución consiste en crear una clase fachada que proporcione la funcionalidad de manera sencilla a nuestro sistema cliente. Dicha clase utilizará la clase compleja o los distintos componentes de los sistemas requeridos y los ofrecerá por medio de operaciones más simples.

### Estructura

![image](https://user-images.githubusercontent.com/28193994/147789126-ea578001-d7bf-4d84-b23c-9e5e78a498ff.png)

## Flyweight
También llamado: **Cache**

### Proposito

Patrón de diseño estructural que te permite mantener más objetos dentro de la cantidad disponible de RAM compartiendo las partes comunes del estado entre varios objetos en lugar de mantener toda la información en cada objeto.

### Problema

Nuestro sistema tiene un tipo de componente que se repite numerosas veces, y las instancias tienen una serie de características en común. Queremos optimizar el tamaño en memoria que ocupa para sacar el máximo partido al sistema y no desaprovechar los recursos con datos redundantes.

Se aplica cuando:
- Se necesita eliminar o reducir la redundancia cuando se tiene gran cantidad de objetos que comparten bastante información.
- Nuestro soporte tiene memoria limitada y esta necesita ser aprovechada óptimamente.
- La identidad propia de los objetos es irrelevante.

![image](https://user-images.githubusercontent.com/28193994/147789140-76f20d13-ea24-4731-8a5b-e4d837f5dac7.png)

### Solucion

Para solucionar este escenario, debemos de abstraer las características del elemento que se replica en 2 grupo: las intrínsecas y las extrínsecas. Las primeras hacen referencia a los estados comunes que tiene el objeto o grupo de objetos a replicar, mientras que las segundas aluden a las características propias de la instancia.

De esta manera, nuestor objetivo será estudiar las características comunes de los objetos y crear una clase extrínseca. Luego a la hora de realizar las diferentes instancias, cojeremos la parte común (intrínseca) y la complementaremos con los datos específicos de la instancia.

### Estructura

![image](https://user-images.githubusercontent.com/28193994/147789154-308611f1-d74a-46c9-8bde-6ac30127d668.png)

## Proxy

### Proposito

Patrón de diseño estructural que te permite proporcionar un sustituto o marcador de posición para otro objeto. Un proxy controla el acceso al objeto original, permitiéndote hacer algo antes o después de que la solicitud llegue al objeto original.

### Problema
El patrón proxy trata de proporcionar un objeto intermediario que represente o sustituya al objeto original con motivo de controlar el acceso y otras características del mismo.

Se aplica cuando:

El patrón Proxy se usa cuando se necesita una referencia a un objeto más flexible o sofisticada que un puntero. Según la funcionalidad requerida podemos encontrar varias aplicaciones:

- Proxy remoto: representa un objeto en otro espacio de direcciones.
- Proxy virtual: retrasa la creación de objetos costosos.
- Proxy de protección: controla el acceso a un objeto.
- Referencia inteligente: tiene la misma finalidad que un puntero pero además ejecuta acciones adicionales sobre el objeto, como por ejemplo el control de concurrencia.

### Solucion

La solución a este problema es crear una interfaz Subject que defina toda la funcionalidad que nuestro objeto ha de proveer. Esta interfaz, evidentemente, ha de ser implementada por el objeto real. Crearemos también un Objeto Proxy que mantendrá una referencia al objeto real, y que además implementará la interfaz Subject, de modo que a la hora de precisar la funcionalidad sea indiferente si se está ejecutando el Proxy o el objeto real.

### Estructura

![image](https://user-images.githubusercontent.com/28193994/147789165-0edbff46-f05e-4061-beb3-1b0a95e0e360.png)
