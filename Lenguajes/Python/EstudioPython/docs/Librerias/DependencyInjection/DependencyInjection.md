La inyección de dependencias es un patrón de diseño utilizado para desacoplar componentes y facilitar la reutilización y el testing en aplicaciones. En Python, la inyección de dependencias se puede implementar utilizando diferentes enfoques, como la inyección explícita, la inyección a través de parámetros y la inyección a través de contenedores de inversión de control (IoC).

## Inyección explícita:
En este enfoque, las dependencias se pasan explícitamente como argumentos a una función o constructor. Esto permite que el componente dependiente sea independiente de la creación y gestión de sus dependencias.

```python
class ServicioCorreo:
    def enviar_correo(self, destinatario, mensaje):
        # Lógica para enviar el correo

class ProcesadorFacturas:
    def __init__(self, servicio_correo):
        self.servicio_correo = servicio_correo

    def procesar_factura(self, factura):
        # Lógica para procesar la factura
        self.servicio_correo.enviar_correo(factura.cliente, "Factura procesada")

servicio_correo = ServicioCorreo()
procesador = ProcesadorFacturas(servicio_correo)
```

En este ejemplo, tenemos una clase `ProcesadorFacturas` que depende de un `ServicioCorreo` para enviar notificaciones. La dependencia se pasa explícitamente como argumento al constructor de `ProcesadorFacturas`.

## Inyección a través de parámetros:
En este enfoque, las dependencias se pasan como argumentos a los métodos que las necesitan. Esto permite una mayor flexibilidad para inyectar diferentes implementaciones de dependencias en diferentes momentos.

```python
class ServicioCorreo:
    def enviar_correo(self, destinatario, mensaje):
        # Lógica para enviar el correo

class ProcesadorFacturas:
    def procesar_factura(self, factura, servicio_correo):
        # Lógica para procesar la factura
        servicio_correo.enviar_correo(factura.cliente, "Factura procesada")

servicio_correo = ServicioCorreo()
procesador = ProcesadorFacturas()
procesador.procesar_factura(factura, servicio_correo)
```

En este ejemplo, la dependencia `servicio_correo` se pasa como argumento al método `procesar_factura()` de `ProcesadorFacturas`.

## Inyección a través de contenedores de IoC:
En este enfoque, se utiliza un contenedor de inversión de control (IoC) para gestionar y resolver las dependencias. El contenedor IoC se encarga de crear y administrar las instancias de las dependencias y las inyecta automáticamente cuando se necesitan.

Existen varias bibliotecas populares en Python que facilitan la inyección de dependencias y la gestión de contenedores IoC, como `Django`, `Flask`, `Inject`, `PyInject`, entre otras.

```python
from inject import Injector, inject

class ServicioCorreo:
    def enviar_correo(self, destinatario, mensaje):
        # Lógica para enviar el correo

class ProcesadorFacturas:
    @inject
    def __init__(self, servicio_correo: ServicioCorreo):
        self.servicio_correo = servicio_correo

    def procesar_factura(self, factura):
        # Lógica para procesar la factura
        self.servicio_correo.enviar_correo(factura.cliente, "Factura procesada")

injector = Injector()
procesador = injector.get(ProcesadorFacturas)
```

En este ejemplo, utilizamos la biblioteca `Inject` para gestionar las dependencias. El contenedor IoC `injector` se encarga de crear y resolver las dependencias automáticamente cuando se crea una instancia de `ProcesadorFacturas`.
