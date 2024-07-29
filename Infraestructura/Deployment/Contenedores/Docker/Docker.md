# Docker
Docker es una herramienta que permite crear entornos virtualizados donde ejecutar las aplicaciones que necesitas, tanto para desarrollar, como para desplegar a cualquier entorno. 

De esta forma no necesitas instalar herramientas como BBDD, etc. En tu equipo de desarrollo y te permite crearlas directamente con un comando en un entorno de produccion.

1. **Portabilidad**: Los contenedores de Docker son independientes del sistema operativo y pueden ejecutarse en cualquier plataforma que tenga instalado Docker.

2. **Aislamiento**: Cada contenedor de Docker es un entorno aislado que no afecta a otros contenedores ni al sistema anfitrión, lo que garantiza una mayor seguridad y evita conflictos de dependencias.

3. **Eficiencia**: Los contenedores comparten el mismo kernel del sistema operativo, lo que los hace más livianos y eficientes en términos de recursos

4. **Escalabilidad**: Docker facilita el escalado de aplicaciones, ya que se pueden crear y desplegar múltiples contenedores que se ejecutan en paralelo para manejar una carga de trabajo más grande.

5. **Facilidad de uso**: Docker proporciona una interfaz de línea de comandos y una interfaz gráfica de usuario que facilitan la creación, gestión y despliegue de contenedores.


Docker funciona con 2 conceptos principales, las `imagenes` y los `contenedores`

## Imagenes en Docker
Una imagen contiene los archivos, dependencias, etc. Necesarios para ejecutar la aplicacion que necesitamos en un contenedor.

Las imagenes suelen estar programadas en unos archivos llamados `dockerfile` que contienen un script con una sintaxis muy sencilla, que es interpretada por docker para obtener lo necesario y ejecutar la app.

Dentro de una imagen podemos referenciar a otras imagenes tambien, por ejemplo:

```dockerfile
# Establece la imagen base
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Establece el directorio de trabajo
WORKDIR /app

# Copia los archivos del proyecto y restaura las dependencias
COPY . .
RUN dotnet restore

# Compila la aplicación
RUN dotnet publish -c Release -o out
RUN dotnet dev-certs https -ep /app/cert.pfx -p password

# Configura la imagen de producción
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .
COPY --from=build /app/cert.pfx .

# Instalamos curl para el healthcheck de Docker
RUN apt update && apt install -y curl

# Inicia la aplicación
ENTRYPOINT ["dotnet", "HostWebApi.dll"]
```
1. En este dockerfile indicamos que necesitamos la imagen del SDK de dotnet porque vamos restaurar paquetes y compilar la aplicacion

2. Mas adelante indicamos que necesitamos lo basico de ASP para, con los archivos ya compilador, ejecutar la aplicacion

> El comando COPY se utiliza porque cuando ejecutamos la imagen, esta es el enlace entre nuestro equipo(host) y el contenedor de docker, por tanto, necesitamos pasar los archivos necesarios de un lugar al otro.


## Contenedores en Docker
Un contenedor es un entorno virtualizado donde se monta la imagen que le hemos indicado de forma aislada a la maquina principal(host) y a otros contenedores.

- Cada contenedor se gestiona de forma individualizada, por tanto podemos arrancarlo, pararlo, eliminarlo, etc. Sin afectar al resto.

- Podemos visualizar metricas de los contedores donde podemos obtener informacion sobre cuanta CPU, Memoria RAM, etc.

- Podemos limitar la capacidad de recursos a cada contenedor, como el numero de cores que le asignas o un maximo de RAM

**No** hay que **confundir** los contenedores docker con maquinas virtuales.

1. **Arquitectura**:
   - Docker: Utiliza virtualización a nivel de sistema operativo, donde cada contenedor comparte el mismo kernel del sistema operativo del host.
   - Máquinas Virtuales: Emula un sistema operativo completo en una capa de abstracción, que incluye su propio kernel.
2. **Tamaño y Eficiencia**:
   - Docker: Los contenedores son más pequeños y eficientes en comparación con las VM, ya que comparten recursos del sistema operativo del host y no requieren una copia completa del sistema operativo.
   - Máquinas Virtuales: Las VMs son más pesadas, ya que cada una contiene una copia completa del sistema operativo
3. **Tiempo de Inicio**:
   - Docker: Los contenedores se inician en cuestión de segundos, lo que permite una implementación y escalado más rápidos de las aplicaciones.
   - Máquinas Virtuales: Las VMs suelen requerir más tiempo para iniciarse, ya que se debe arrancar un sistema operativo completo.
4. **Aislamiento**:
   - Docker: Los contenedores proporcionan aislamiento de recursos a nivel de proceso y de sistema de archivos, lo que garantiza que una aplicación en un contenedor no afecte a otras aplicaciones en otros contenedores.
   - Máquinas Virtuales: Las VMs proporcionan un mayor nivel de aislamiento, ya que cada VM tiene su propio kernel y se ejecuta como una entidad independiente.
5. **Portabilidad**:
   - Docker: Los contenedores son altamente portátiles, ya que se pueden ejecutar en cualquier sistema operativo que tenga Docker instalado.
   - Máquinas Virtuales: Las VMs también son portátiles, pero requieren una capa de virtualización específica para cada tipo de `hipervisor` (por ejemplo, VMware, VirtualBox, Hyper-V, etc.).

## Comandos Docker
Para hacer uso de docker por terminal tenemos los siguientes comandos:

### Comandos Básicos
1. **`docker build -t <nombre>:<etiqueta> <directorio>`**  
   Construye una imagen Docker desde un Dockerfile ubicado en el directorio especificado.

1. **`docker run <opciones> <imagen>`**  
   Ejecuta un contenedor basado en la imagen especificada. Ejemplos de opciones incluyen:
   - `-d` para ejecutar en segundo plano (detached).
   - `-p <puerto_host>:<puerto_contenedor>` para mapear puertos.
   - `--name <nombre>` para darle un nombre al contenedor.

1. **`docker ps`**  
   Muestra una lista de los contenedores en ejecución.

1. **`docker ps -a`**  
   Muestra todos los contenedores, incluyendo los que están detenidos.

1. **`docker stop <nombre_contenedor>`**  
   Detiene un contenedor en ejecución.

1. **`docker start <nombre_contenedor>`**  
   Inicia un contenedor detenido.

1. **`docker restart <nombre_contenedor>`**  
   Reinicia un contenedor.

1. **`docker rm <nombre_contenedor>`**  
    Elimina un contenedor detenido.

1. **`docker rmi <imagen>`**  
    Elimina una imagen Docker.

1. **`docker logs <nombre_contenedor>`**  
    Muestra los logs de un contenedor.

### Gestión de Imágenes

1. **`docker images`**  
   Lista las imágenes disponibles en tu máquina local.

2. **`docker image prune`**  
   Elimina las imágenes que no están en uso y que no tienen etiquetas.

3. **`docker image ls`**  
   Lista las imágenes, similar a `docker images`.

### Volúmenes y Redes

1. **`docker volume ls`**  
   Muestra los volúmenes disponibles.

2. **`docker volume rm <volumen>`**  
   Elimina un volumen Docker.

3. **`docker network ls`**  
   Lista las redes disponibles.

4. **`docker network rm <red>`**  
   Elimina una red Docker.

### Otros Comandos Útiles

1. **`docker exec -it <nombre_contenedor> <comando>`**  
   Ejecuta un comando interactivo dentro de un contenedor en ejecución (por ejemplo, `bash`).

2. **`docker inspect <nombre_contenedor_o_imagen>`**  
   Muestra detalles en formato JSON sobre un contenedor o una imagen.
