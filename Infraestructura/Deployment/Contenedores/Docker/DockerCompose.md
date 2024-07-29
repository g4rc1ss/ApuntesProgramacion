# Docker Compose
Docker Compose es una herramienta de Docker que permite definir y gestionar aplicaciones multi-contenedor. Con Docker Compose, puedes describir la configuración de todos los servicios, redes y volúmenes que componen tu aplicación en un archivo YAML

En lugar de tener que ejecutar múltiples comandos de Docker para crear y configurar cada contenedor individualmente, Docker Compose te permite definir toda la infraestructura de tu aplicación en un solo archivo, lo que facilita su administración y despliegue.

1. **Definición de servicios**: Puedes definir los servicios que componen tu aplicación, especificando la imagen, los puertos, las variables de entorno, los volúmenes y otras configuraciones necesarias para cada servicio.

2. **Gestión de redes**: Docker Compose crea automáticamente una red por defecto para todos los servicios de la aplicación, lo que permite la comunicación entre contenedores.

3. **Facilidad de despliegue**: Con un solo comando `docker-compose up`, puedes crear y levantar todos los contenedores definidos

4. **Entornos reproducibles**: Docker Compose garantiza que tu aplicación se despliegue de la misma manera en diferentes entornos, facilitando la reproducción de la configuración de desarrollo y producción.


Por lo tanto Docker compose es una herramienta de **orquestación de contenedores**.

## Configurar docker-compose

```yaml
version: '3.8'

services:
  dotnetapp:
    build:
      context: ../src
      dockerfile: dockerfile
    environment:
      - ASPNETCORE_ENVIRONMENT=production
    ports:
      - "80:80"
      - "443:443"
    links:
      - mongodb
    volumes:
      - dotnetapp_keys_data:/keysData
    depends_on:
      - mongodb

  mongodb:
    container_name: mongodb
    image: mongo
    mem_limit: 512M   # Limitar la memoria a 512 megabytes
    cpus: 0.5        # Limitar el uso de CPU a 0.5 núcleos (50% de un núcleo)
    restart: always
    ports:
      - 27017:27017
    environment:
      - MONGO_INITDB_ROOT_USERNAME=
      - MONGO_INITDB_ROOT_PASSWORD=
    volumes:
      - ./MongoDB/mongo-init.js:/docker-entrypoint-initdb.d/mongo-init.js:ro
      - mongodb_data:/data
      - mongodb_data:/data/db

volumes:
  dotnetapp_keys_data:
  mongodb_data:
```

- El servicio `dotnetapp` comprobara si hay que compilar la imagen, si es asi, se basara en el dockerfile que le hemos indicado y despues levantará el servicio pasandole la variable de entorno correspondiente y asignando el volumen `dotnetapp_keys_data`

- El servicio `mongodb` indicamos que queremos la imagen `mongo` del registro de docker, indicamos que el usuario administrador sera vacio, por tanto no habra usuario admin(para entornos de prueba o locales da igual, para pro... **NO**) y su punto de acceso sera el puerto 27017

En el docker-compose se le pueden indicar parametros como:
- **restart** Si sucediera algun error que tiraria el contenedor, con este parametro podemos indicar si queremos que automaticamente docker lo vuelva a levantar.

- **volumes** Los contenedores carecen de una caracteristica muy importante como es la persistencia. Si eliminas un contenedor y lo vuelves a crear, todos los archivos son eliminados y reemplazados con la nueva imagen. Para poder indicar persistencia a una carpeta en especifico se puede usar la propiedad `volumes`.

- **networks** Si queremos que un contendor pueda enviar peticiones y tratar con otros tenemos que agregar esta propiedad indicando el servicio con el que queremos enlazarlo.

- **mem_limit** Si necesitamos limitar el uso de recursos a un contenedor, por ejemplo la memoria RAM que puede utilizar lo podemos indicar con esta propiedad

- **cpus** Si queremos limitar el uso de la CPU al contenedor y no darle todos los Cores, podemos usar esta propiedad


Docker compose es muy buena opcion para entornos de desarrollo locales o ejecutar test de integracion, donde en cuestion de segundos tienes tu aplicacion corriendo con toda la infraestructura. En los entornos de produccion generalmente tenemos varios servidores por separado para la base de datos, el API, etc. Y por tanto tendrias que ejecutar los contenedores en entornos diferentes. Para eso existen herrameintas de orquestacion como **kubernetes** o **docker swarm**

## Ejecucion de Docker Compose
Para ejecutar docker compose simplemente hay que escribir el comando:


```powershell
docker-compose -f archivoDockerCompose.yml up -d
```

Es importante destacar que en docker compose podemos tener varios archivos `yml` para ejecutar el entorno segun queramos.

```bash
docker-compose -f archivoDotnetApp.yml -f archivoMongodb.yml up -d
```

Por ejemplo, supongamos que en local no queremos ejecutar el archivo para levantar la aplicacion dotnet, pero necesitamos la Base de datos

Yo por tener organizado los docker-compose personalmente me gusta tenerlos separados por servicio y despues tengo un script en `powershell` que los junta y ejecuta: [docker-compose.ps1](https://github.com/g4rc1ss/Dotnet-Web-Clean-Architecture-Skeleton/blob/main/.docker/docker-compose.ps1)

## Comandos de Docker-compose
Docker compose tiene comandos parecidos a Docker, pero que trabajan directamente con los servicios de los docker-compose indicados, esto hace que resulte mas sencillo de interpretar y de visualizar

1. **`docker-compose up`**
   - **Descripción**: Inicia los servicios definidos en el archivo `docker-compose.yml`.
   - **Opciones comunes**:
     - `-d`: Ejecuta en segundo plano (detached mode).
     - `--build`: Fuerza la reconstrucción de las imágenes antes de iniciar los contenedores.

2. **`docker-compose down`**
   - **Descripción**: Detiene y elimina los contenedores, redes y volúmenes creados por `docker-compose up`.
   - **Opciones comunes**:
     - `-v`: Elimina los volúmenes asociados.

3. **`docker-compose start`**
   - **Descripción**: Inicia los contenedores que están definidos en el archivo `docker-compose.yml` pero que no están en ejecución.
   - **Nota**: No crea nuevos contenedores ni reconstruye las imágenes.

4. **`docker-compose stop`**
   - **Descripción**: Detiene los contenedores en ejecución sin eliminarlos.

5. **`docker-compose restart`**
   - **Descripción**: Reinicia los contenedores en ejecución.

6. **`docker-compose build`**
   - **Descripción**: Construye o reconstruye los servicios definidos en `docker-compose.yml`.
   - **Opciones comunes**:
     - `--no-cache`: No utiliza caché para construir las imágenes.

7. **`docker-compose logs`**
   - **Descripción**: Muestra los logs de los contenedores en ejecución.
   - **Opciones comunes**:
     - `-f`: Muestra los logs en tiempo real (follow).
     - `--tail <número>`: Muestra solo las últimas `<número>` líneas de logs.

8. **`docker-compose ps`**
   - **Descripción**: Lista los contenedores que están siendo gestionados por `docker-compose`.

9. **`docker-compose exec <servicio> <comando>`**
   - **Descripción**: Ejecuta un comando en un contenedor en ejecución.
   - **Opciones comunes**:
     - `-it`: Permite la interacción con el contenedor (modo interactivo).

10. **`docker-compose run <servicio> <comando>`**
    - **Descripción**: Ejecuta un comando en un nuevo contenedor basado en el servicio definido.
    - **Opciones comunes**:
      - `--rm`: Elimina el contenedor después de que el comando se complete.

11. **`docker-compose config`**
    - **Descripción**: Valida y muestra la configuración de `docker-compose.yml` en formato expandido.

12. **`docker-compose pull`**
    - **Descripción**: Descarga las imágenes para los servicios definidos en el archivo `docker-compose.yml`.

13. **`docker-compose push`**
    - **Descripción**: Sube las imágenes a un registro para los servicios definidos en el archivo `docker-compose.yml`.

14. **`docker-compose pause`**
    - **Descripción**: Pausa los contenedores en ejecución sin detenerlos.

15. **`docker-compose unpause`**
    - **Descripción**: Reanuda los contenedores que han sido pausados.

16. **`docker-compose rm`**
    - **Descripción**: Elimina los contenedores que están detenidos.
    - **Opciones comunes**:
      - `-f`: Elimina los contenedores sin solicitar confirmación.
