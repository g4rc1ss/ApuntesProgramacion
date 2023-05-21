# Observabilidad 
Cuando tenemos un sitema en producción es importante tener registros de cuando, como y por que han sucecido ciertos eventos.
 
- **Logs**: Registros que hacemos nosotros en la aplicacion para mostrar el error generado, los motivos, includo los datos que han llegado para poder simular nosotros la transaccion, etc.

- **Métricas**: Nos indican el estado del sistema, carga de request, latencias, tiempos de respuesta, threads, memoria del sistema, etc.

- **Traces**: Almacenan el curso de una accion por todo el sistema. Por ejemplo, si tenemos un sistema de microservicios y tenemos una request que falla, nos indicara por que micros pasa, cual de ellos falla, codigo de error, tiempos de respuesta, etc.

Para almacenar, tratar y estudiar los registros correspondientes a la observabilidad existen varios programas orientados a ellos.

## Almacenamiento de logs
- [Graylog](./Logs/Graylog.md)

## Almacenamiento de Trazas y Metricas
- [Zipking](./Telemetry/Zipking.md)