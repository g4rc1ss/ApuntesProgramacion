# Clean Architecure
Esta arquitectura es una fusion de la hexagonal y la onion, cogiendo lo mejor de cada una. Abstrae y agrega algunos matices sobre la comunicacion de las capas, etc.

1. **Frameworks & Drivers**: Aqui se ubica la parte de infraestructura, el API, etc. Al final en esta capa se debe tener todo lo correspondiente al uso de librerias externas y servicios de tercero.  
Para usar una base de datos, usamos el recurso de un tercero.  
Si usamos una libreria de un tercero, para por ejemplo, realizar las queries y conexiones con la base de datos, usamos la libreria de un tercero.
1. **Interface Adapters**: Es una capa que contiene la responsabilidad de adaptar/mapear el objeto que se devuelve en el core con lo que se quiere mostrar al exterior, por ejemplo, si tenemos que devolver al usuario 2 propiedades, pero el core nos devuelve 5, realizamos la conversion del objeto para devolver 2.
1. **Application Business rules**: El core de la aplicacion, se hace uso de la inversion de dependencias para acceder a las diferentes capas y aqui se generaliza todo en casos de uso.  
En esta capa se ubican también las interfaces que se deben de implementar en otras capas.
1. **Entities**: Contiene "clases tontas" que contienen la definicion de las propiedades de la aplicacion, por ejemplo, la clase que puede devolver una consulta de infraestructura.

![Captura de pantalla 2022-01-07 175237](https://user-images.githubusercontent.com/28193994/148578335-b91c3028-cf41-4acf-984a-bafc2f0d85cd.png)

Al igual que la Onion, las dependencias van de fuera hacia dentro, de esta forma los Frameworks y las capas de terceros dependen del core de la aplicacion.
