# User Secrets
Los **User secrets** son datos especificos que contienen datos como contraseñas, claves de API, cadenas de conexion, etc. Por lo que necesitamos tenerlas fuera del repositorio y de compartirlas con otros desarrolladores.

## Secret Manager
Una vez creado el proyecto principal, el que contiene los archivos de configuración, le damos al click derecho sobre el proyecto y buscamos la opción `Manage User Secrets`.

Esta opción generará un elemento `<userSecretsId>` en el `.csproj` del proyecto y se almacenara ese id en el programa.  
A su vez el programa creará un archivo llamado **secrets.json** que estará ubicado fuera del proyecto. Por defecto se ubica en:
- Windows `%APPDATA%\microsoft\UserSecrets\<userSecretsId>\secrets.json`
- Mac `~/.microsoft/usersecrets/<userSecretsId>/secrets.json`
- Linux `~/.microsoft/usersecrets/<userSecretsId>/secrets.json`

Para poder acceder a dicho archivo, se podra hacer desde el objeto `IConfiguration` con la configuracion por defecto.
> Nota: Se puede cambiar el identificador del secreto, simplemente buscamos en las rutas indicadas el id que se ha generado en el `csproj` y renombramos la carpeta y el id del proyecto poniendo lo que queramos.


# Publicar Proyecto
Para compilar las **Release** del proyecto se usara la opcion "**Publish**"

Este programa nos compilara en:
- ``.exe`` para windows
- ``.dll`` para ser portable y poder ejecutarlo en todas las versiones de S.O
Tambien se puede compilar para MacOs y Linux, pero son archivos sin extension

Las publicaciones se van a hacer desde el Visual Studio:

![SeleccionPublish](Capturas/1-SeleccionPublish.PNG)

Hacemos Click derecho en el proyecto principal de la solucion y le damos al boton Publish...

![ConfigurarCarpetaExtraccion](Capturas/2-ConfigurarCarpetaExtraccion.PNG)

Dandole a **Browse** seleccionamos la carpeta donde vamos a extraer los binarios, una vez seleccionado le damos al boton **Create Profile**.

![PantallaConfigPlatform](Capturas/3-PantallaConfigPlatform.PNG)

Al darle a **Create Profile** nos aparecera esta venta, para configurar las opciones de compilacion le daremos a "edit"

![PantallaConfigProfile](Capturas/4-PantallaConfigProfile.PNG)

Cuando le demos a **edit** nos aparecera esta ventana
- `Configuration:` Seleccionamos si queremos publicar modo **Debug** o modo **Release**

- `Target Frameworks:` Seleccionamos la version del SDK con la que queremos compilar (la mejor siempre sera la ultima que podamos)

- `Deployment Mode:` Seleccionamos el modo de compilacion que tendra la aplicacion(Explicamos mas abajo)

- `Target Runtime:` Seleccionamos el sistema operativo y la arquitectura de este.

![SelectModoCompilacion](Capturas/5-SelectModoCompilacion.PNG)

- `Framework Dependent:` Compila solo los archivos necesarios de librerias, clases etc creadas por el usuario, las librerias del **Framework** no se crearan como **.dll** porque depende de que este instalado

- `Self-contained:` Compila todas las librerias que usa el programa, se usa para no requerir de tener .net instalado en el equipo, por tanto aqui se crearan todas las **.dll** del framework

![SeleccionarSO](Capturas/6-SeleccionarSO.PNG)

En esta opcion seleccionamos los diferentes sistemas operativos a los que ira destinada la aplicacion y la compilara en consecuencia.

La opción **Portable** crea un `.dll` y para ejecutarlo se usara el comando
````
dotnet nombrePrograma.dll
````

![ResultadoCompilacion](Capturas/7-ResultadoCompilacion.PNG)

En la parte **Output** se mostrarán los resultados de la compilacion y extraccion de los archivos necesarios.
