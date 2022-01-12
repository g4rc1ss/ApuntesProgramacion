# User Secrets
Los **User secrets** son datos especificos que contienen datos como contraseñas, claves de API, cadenas de conexion, etc. Por lo que necesitamos tenerlas fuera del repositorio y de compartirlas con otros desarrolladores.

## Secret Manager
Una vez creado el proyecto principal, el que contiene los archivos de configuración, le damos al click derecho sobre el proyecto y buscamos la opción `Manage User Secrets`.

Esta opción generará un elemento `<userSecretsId>` en el `.csproj` del proyecto y se almacenara ese id en el programa.  
A su vez el programa creará un archivo llamado **secrets.json** que estará ubicado fuera del proyecto. Por defecto se ubica en:
- Windows `%APPDATA%\microsoft\UserSecrets\<userSecretsId>\secrets.json`
- Mac `~/.microsoft/usersecrets/<userSecretsId>/secrets.json`
- Linux `~/.microsoft/usersecrets/<userSecretsId>/secrets.json`

> Nota: Se puede cambiar el identificador del secreto, simplemente buscamos en las rutas indicadas el id que se ha generado en el `csproj` y renombramos la carpeta y el id del proyecto poniendo lo que queramos.

> Para poder acceder a dicho archivo, se podra hacer desde el objeto `IConfiguration` con la configuracion por defecto.