# Arquitectura monolitica

Consiste en una aplicacion que contiene toda la logica en un mismo punto. Esa misma aplicacion es la encargada de gestionar todas las API, logica de negocio, consultas a datos, etc.

![esquema-arquitectura-monoltica](https://github.com/g4rc1ss/ApuntesProgramacion/assets/28193994/7eceded4-7b0a-40b2-91a1-7648bc407cc6)

En la imagen lo que se aprecia es una llamada desde un front hacia el back, el back como monolitico gestiona 3 tipos de apis diferentes, pero estan todas en el mismo lenguaje de programacion y englobadas en la misma aplicación.


## Ventajas de una arquitectura monolítica
- **Implementación sencilla**: Solo hay que desplegar una aplicación.

- **Desarrollo**: Desarrollar una aplicación con una única base de código es más sencillo.

- **Rendimiento**: en una base de código y un repositorio centralizados, una API suele realizar la misma función que muchas API en el caso de los microservicios.

- **Pruebas**: Las pruebas se pueden hacer más rápido que con una aplicación distribuida.

- **Depuración**: con todo el código ubicado en un solo lugar, es más fácil rastrear las solicitudes y localizar incidencias.

## Desventajas de una arquitectura monolítica

- **Escalabilidad**: no se pueden escalar componentes individuales

- **Fiabilidad**: si hay un error en algún módulo, puede afectar a la disponibilidad de toda la aplicación.

- **Barrera para la adopción de tecnología**: cualquier cambio en el marco o el lenguaje afecta a toda la aplicación, lo que hace que los cambios suelan ser costosos y lentos.

- **Flexibilidad**: limitado por las tecnologías que se utilizan en él.

- **Implementación**: un pequeño cambio requiere una nueva implementación de todo el monolito.
