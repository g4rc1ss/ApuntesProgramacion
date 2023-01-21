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

![1-SeleccionPublish](https://user-images.githubusercontent.com/28193994/149130935-2625d9cd-1347-4bca-a1cf-6e55f054d6e1.PNG)

Hacemos Click derecho en el proyecto principal de la solucion y le damos al boton Publish...

![2-ConfigurarCarpetaExtraccion](https://user-images.githubusercontent.com/28193994/149130945-324b564b-ba96-41e0-b0bb-58dbb3c2001e.PNG)

Dandole a **Browse** seleccionamos la carpeta donde vamos a extraer los binarios, una vez seleccionado le damos al boton **Create Profile**.

![3-PantallaConfigPlatform](https://user-images.githubusercontent.com/28193994/149130972-c02b2878-bb5c-46db-9195-4cde3ddbf0fc.PNG)

Al darle a **Create Profile** nos aparecera esta venta, para configurar las opciones de compilacion le daremos a "edit"

![4-PantallaConfigProfile](https://user-images.githubusercontent.com/28193994/149130987-f048c4bc-e32c-4360-96f1-77268b543b4a.PNG)

Cuando le demos a **edit** nos aparecera esta ventana
- `Configuration:` Seleccionamos si queremos publicar modo **Debug** o modo **Release**

- `Target Frameworks:` Seleccionamos la version del SDK con la que queremos compilar (la mejor siempre sera la ultima que podamos)

- `Deployment Mode:` Seleccionamos el modo de compilacion que tendra la aplicacion(Explicamos mas abajo)

- `Target Runtime:` Seleccionamos el sistema operativo y la arquitectura de este.

![5-SelectModoCompilacion](https://user-images.githubusercontent.com/28193994/149130995-df3a92c3-8c26-4443-9330-64fb21620171.PNG)

- `Framework Dependent:` Compila solo los archivos necesarios de librerias, clases etc creadas por el usuario, las librerias del **Framework** no se crearan como **.dll** porque depende de que este instalado

- `Self-contained:` Compila todas las librerias que usa el programa, se usa para no requerir de tener .net instalado en el equipo, por tanto aqui se crearan todas las **.dll** del framework

![6-SeleccionarSO](https://user-images.githubusercontent.com/28193994/149131012-66215368-068f-41d9-944d-fb45bf93f35a.PNG)

En esta opcion seleccionamos los diferentes sistemas operativos a los que ira destinada la aplicacion y la compilara en consecuencia.

La opción **Portable** crea un `.dll` y para ejecutarlo se usara el comando
````
dotnet nombrePrograma.dll
````

![7-ResultadoCompilacion](https://user-images.githubusercontent.com/28193994/149131047-05cbe168-e6e1-4fdf-888e-a4a9d609dc38.PNG)

En la parte **Output** se mostrarán los resultados de la compilacion y extraccion de los archivos necesarios.
