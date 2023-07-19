# Docker Compose
Docker Compose es una herramienta de Docker que permite definir y gestionar aplicaciones multi-contenedor. Con Docker Compose, puedes describir la configuración de todos los servicios, redes y volúmenes que componen tu aplicación en un archivo YAML

En lugar de tener que ejecutar múltiples comandos de Docker para crear y configurar cada contenedor individualmente, Docker Compose te permite definir toda la infraestructura de tu aplicación en un solo archivo, lo que facilita su administración y despliegue.

1. **Definición de servicios**: Puedes definir los servicios que componen tu aplicación, especificando la imagen, los puertos, las variables de entorno, los volúmenes y otras configuraciones necesarias para cada servicio.

2. **Escalado de servicios**: Con Docker Compose, puedes escalar los servicios de tu aplicación para manejar diferentes niveles de carga, simplemente ajustando el número de réplicas.

3. **Gestión de redes**: Docker Compose crea automáticamente una red por defecto para todos los servicios de la aplicación, lo que permite la comunicación entre contenedores.

4. **Facilidad de despliegue**: Con un solo comando `docker-compose up`, puedes crear y levantar todos los contenedores definidos

5. **Entornos reproducibles**: Docker Compose garantiza que tu aplicación se despliegue de la misma manera en diferentes entornos, facilitando la reproducción de la configuración de desarrollo y producción.


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

- El servicio `dotnetapp` que se va a encangar de ejecutar el archivo dockerfile ubicado en `../src` pasandole la variable de entorno `production` y se accedera a traves de los puertos 80 y 443

- El servicio `mongodb` indicamos que queremos la imagen `mongo` del registro de docker, indicamos que el usuario administrador sera vacio, por tanto no habra usuario admin(para entornos de prueba o locales da igual, para pro... **NO**) y su punto de acceso sera el puerto 27017

En el docker compose se le pueden indicar parametros como:
- **restart** Si sucediera algun error que tiraria el contenedor, con este parametro podemos indicar si queremos que automaticamente docker lo vuelva a levantar.

- **volumes** Los contenedores carecen de una caracteristica muy importante como es la persistencia. Si eliminas un contenedor y lo vuelves a crear, todos los archivos son eliminados y reemplazados con la nueva imagen. Para poder indicar persistencia a una carpeta en especifico se puede usar la propiedad `volumes`.

- **link** Si queremos que un contendor pueda enviar peticiones y tratar con otros tenemos que agregar esta propiedad indicando el servicio con el que queremos enlazarlo.

- **mem_limit** Si necesitamos limitar el uso de recursos a un contenedor, por ejemplo la memoria RAM que puede utilizar lo podemos indicar con esta propiedad

- **cpus** Si queremos limitar el uso de la CPU al contenedor y no darle todos los Cores, podemos usar esta propiedad


Docker compose es muy buena opcion para entornos de desarrollo locales o ejecutar test de integracion, donde en cuestion de segundos tienes tu aplicacion corriendo con toda la infraestructura. En los entornos de produccion generalmente tenemos varios servidores por separado para la base de datos, el API, etc. Y por tanto tendrias que ejecutar los contenedores en entornos diferentes. Para eso existen herrameintas de orquestacion como **kubernetes** o **docker swarm**

## Ejecucion de Docker Compose
Para ejecutar docker compose simplemente hay que escribir el comando:


```powershell
docker compose -f archivoDockerCompose.yml up -d
```

Es importante destacar que en docker compose podemos tener varios archivos `yml` para ejecutar el entorno segun queramos.

```bash
docker compose -f archivoDotnetApp.yml -f archivoMongodb.yml up -d
```

Por ejemplo, supongamos que en local no queremos ejecutar el archivo para levantar la aplicacion dotnet, pero necesitamos la Base de datos

Yo por tener organizado los docker-compose personalmente me gusta tenerlos separados por servicio y despues tengo un script en `powershell` que monta el comando y los ejecuta:

```powershell 
param (
    [Parameter(Mandatory = $true)]
    [ValidateSet("up", "down")]
    [string]$action,

    [Parameter(Mandatory = $true)]
    [ValidateSet("local", "test")]
    [string]$environment,

    [Parameter(Mandatory = $false)]
    [ValidateSet("v")]
    [string]$removeVolumes
)

$composeToExecuteAlways = @(
    "docker-compose.grafana.yml",
    "docker-compose.mongo.yml",
    "docker-compose.openTelemetry.yml"
);


$composeToExecuteOnTest = @(
    "docker-compose.app.yml"
);

$composeToExecuteOnLocal = @(

);

$commadDockerComposeToExecute = "docker compose"
$enviromentFile = ".env.$environment"



$commadDockerComposeToExecute += " --env-file $enviromentFile"
foreach ($dockerComposeFile in $composeToExecuteAlways) {
    $commadDockerComposeToExecute += " -f $dockerComposeFile";
}


if ($environment -eq "local") {
    foreach ($dockerComposeFile in $composeToExecuteOnLocal) {
        $commadDockerComposeToExecute += " -f $dockerComposeFile";
    }
}

if ($environment -eq "test") {
    foreach ($dockerComposeFile in $composeToExecuteOnTest) {
        $commadDockerComposeToExecute += " -f $dockerComposeFile";
    }

    if ($action -eq "up") {
        $buildExec = "$commadDockerComposeToExecute build" 
        Write-Output $buildExec
        Invoke-Expression $buildExec
    }
}

if ($action -eq "up") {
    $commadDockerComposeToExecute += " up -d"

}
elseif ($action -eq "down") {
    $commadDockerComposeToExecute += " down"

    if ($removeVolumes -eq "v") {
        $commadDockerComposeToExecute += " -v"
    }

}

Write-Output "Comando a ejecutar" + $commadDockerComposeToExecute
Invoke-Expression $commadDockerComposeToExecute
```