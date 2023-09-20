# Arquitectura en Infraestructura
No hay que confundir una arquitectura a nivel infraestructura, que una a nivel software.

- La arquitectura de **software** define como distribuir el codigo de una forma limpia para que sea lo mas mantenible posible, desacoplando y diferenciando la logica de negocio con el acceso a datos, etc.

- La arquitectura de una aplicacion a nivel **infraestructura** define como implementar esa aplicacion a nivel de servidor, donde te llega trafico de usuarios y tienes que dar la respuesta mas óptima, pero teniendo en cuenta el tiempo de desarrollo y la dificultad que supone un tipo de arquitectura u otra

Antes las aplicaciones se escribían como una sola unidad de código, en la que todos los elementos compartían los mismos recursos y espacio de memoria. A este estilo de arquitectura se lo conoce como monolito.

Por lo general, las arquitecturas modernas tiran de aplicaciones distrubuidas, de esta manera cada peticion irá por su propio servicio y el consumo no es compartido, permitiendo hacer una division de recursos y una mejor forma de mantener y escalar las aplicaciones


- [Monolitica](./TiposArquitectura/Monolitica.md)
- [Microservices](./TiposArquitectura/Microservices.md)
