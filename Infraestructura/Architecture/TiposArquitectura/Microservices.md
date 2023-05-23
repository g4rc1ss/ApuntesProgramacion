# Arquitectura Microservicios
Se basa en una serie de servicios que se pueden implementar de forma independiente.

- Los servicios tienen su propia lógica de negocio y base de datos con un objetivo específico.

- La actualización, las pruebas, la implementación y el escalado se llevan a cabo de forma independiente a cada servicio

- Los microservicios no reducen la complejidad, pero hacen que sea más gestionable, ya que separan las tareas en procesos más pequeños que funcionan de manera independiente entre sí.



En la imagen el frontend hace una llamada a un gestor de API, que sera el encargado de recibir el trafico y redirigir las peticiones al endpoint correspondiente.  
- Cada servicio puede estar desarrollado en diferentes lenguajes y tecnologias
- Cada servicio deberia de contener su propia base de datos, si necesitamos datos de otro servicio se pueden hacer llamadas internas entre ellos o hacer procesos de sincronizacion entre bases de datos.

## Ventajas de los microservicios

- **Escalado**: si un microservicio está alcanzando su capacidad de carga, se pueden implementar nuevas instancias de ese servicio.

- **Implementación continua**: ciclos de lanzamiento frecuentes y rápidos.

- **Flexibilidad**: se pueden usar diferentes soluciones tecnologicas, si un lenguaje esta mas orientado a lo que necesitas, no estas obligado a usar otro diferente

- **Fiabilidad**: puedes implementar cambios para un servicio en concreto sin el riesgo de que se caiga toda la aplicación.


## Desventajas de los microservicios
- **Desarrollo descontrolado**: los microservicios suman complejidad en comparación con las arquitecturas monolíticas, ya que hay más servicios en más lugares creados por varios equipos. Si el desarrollo descontrolado no se gestiona adecuadamente, se reduce la velocidad de desarrollo y el rendimiento operativo.

- **Costes elevados de infraestructura**: cada nuevo microservicio tiene su propio coste.

- **Depuración**: cada microservicio tiene su propio conjunto de registros, lo que complica la depuración. Además, una transaccion puede pasar por varios micros.

- **Falta de estandarización**: sin una plataforma común, puede haber una proliferación de idiomas, de estándares de registro y de supervisión.

- **La propiedad no está clara**: a medida que se introducen más servicios, también lo hace el número de equipos que los ejecutan. Con el tiempo, se hace difícil conocer los servicios disponibles que un equipo puede aprovechar y con quién hay que hablar para obtener asistencia.