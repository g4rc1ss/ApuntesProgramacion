# Onion Architecture

1. **UI**: Contiene los controladores o la interfaz de usuario y esta depende directamente de **Application Services**
1. **Infraestructure**: Esta capa contiene las conexiones que se realizarán con terceros, por ejemplo, llamadas a API, Bases de datos, SOAP, etc.
1. **Application Services**: Esta capa contiene el core de la aplicacion, implementará las dependencias de las diferentes capas, por ejemplo, usar la capa de infraestructura para realizar una peticion a Base de datos.
1. **Domain Services**: Esta capa contiene las interfaces que se deben de implementar en las clases para permitir el desacoplamiento.
1. **Domain Model**: Contiene las entidades que se van a utilizar, se pueden definir propiedades, validaciones de campos, mapeadores, etc. Pero no contendra ninguna logica correspondiente al negocio de la aplicacion.

![Captura de pantalla 2022-01-07 175200](https://user-images.githubusercontent.com/28193994/148578325-42bf4ff0-f271-4772-956f-9ec3179005fc.png)


Si nos fijamos en la imagen, las dependencias van a la inversa de, por ejemplo, una N Layers.

La capas de infraestructura y User Interface estan al mismo nivel y van realizando las dependencias hacia dentro, de forma que Application Services conectara con infraestructura y UI a traves de la capa de Domain Services.

> Un concepto bastante interesante y una mejora de la arquitectura Hexagonal, puesto que hay mas capas y mas desacoplamiento, a la larga permite un mayor escalado.
