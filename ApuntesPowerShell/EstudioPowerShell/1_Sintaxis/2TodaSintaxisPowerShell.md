# Interactuando con la Shell

PowerShell utiliza sintaxis del lenguaje C# y esto es algo importante a la hora de desarrollar scripts.

Las palabras clave y funciones de sintaxis son practicamente identicas a las que los desarrolladores pueden utilizar en C#.

Esto es debido a la base de PowerShell que es .NET Framework o .NET Core.



---
# Variables

Las variables son proporciones de memoria que almacenan informacion ue puede variar con el tiempo.

````PowerShell
$string = "Hola"
$int = 1
$double = 2.3
[String]$stringObligado = ""
[int]$integer = 0
````
Se puede indicar el tipo de variable o no, si no se indica el tipo de variable y se requiere saber el tipo mas adelante se podra usar la instruccion ``$variable.GetType()``


Variables necesarias en el desarrollo:

El proveedor de variables contiene todas las variables predefinidas y variables creadas por el usuario.

Existen variables predefinidas muy interesantes para el desarrollo de scripts

| Variable | Descripcion |
| -------- | ----------- |
| $Args	| Contiene una lista con los argumentos pasados a una funcion o a un script |
| $? | Esta variable indica si la ultima instruccion se ejecuto correctamente o no |
| $^ | Esta variable indica el primer miembro del ultimo comando tecleado |
| $$ | Esta variable indica el ultimo miembre del ultimo comando tecleado |
| $Error | Esta variable registra los errores producidos durante la ejecucion de la sesion |
| $ErrorView | Esta variable indica el formato en el que se muestran los errores de $Error |
| $Home | Variable que almacena la ruta del directorio de inicio del usuario |
| $Pid | Variable que contiene el identificador del proceso de PowerShell |


---
# Operadores

Los operadores son fundamentales para un gran tipo de operaciones. Las operaciones aritmeticas, de comparacion, logicas, etc. Estan presentes en cualquier script que se tenga que desarrollar.

PowerShell aporta un gran numero de operadores, los cuales se estudiaran en este apartado clasificado por categorias.

## Operadores de comparacion:

| Operador | Descripcion |
| -------- | ----------- 
| **-ne** | si no son iguales |
| **-eq** | Si son iguales |
| **-gt** | mayor que |
| **-ge** | mayor o igual que |
| **-lt** | menor que |
| **-le** | menor o igual que |

Existen 2 parametros like y notlike.
- ``like``: Comprueba la igualdad de la comparacion
- ``notlike``: la desigualdad.


## Operadores Logicos:

| Operador | Descripcion | Operador |
| -------- | ----------- | -------- |
| **-and** | Y  | Logico |
| **-or** | O  | Logico |
| **-not** | No  | Logico |
| **!** | No  | Logico |
| **-xor** | O | Exclusivo |

## Operadores de Intervalo:
Este tipo de operador permite representar los valores que hay entre un valor inicial y otro valor final.
	
Se representa con 2 puntos ``".."`` por ejemplo:
````PowerShell
$valorini = 2
$valorfinal = 11
$valorini .. $valorfinal#operador de intervalo
````

---
# Arrays

Un array es una coleccion de elementos. Tradicionalmente, los arrays han sido definidos como una coleccion de elementos homogeneos, pero en PowerShell no tiene porque ser asi.

Los arrays tambien son conocidos como ``tablas`` en PowerShell.

```PowerShell
Write-Output "------ Primera forma array ------"
[int[]]$miarray = 22, 12, 1986
$miarray2 = 22, 12, 1986
[int[][]] $miarray3 = @((14, 22, 2008), (1,2,3))#2 dimensiones
$miarray2
$miarray3

#Segunda forma:
Write-Output "------ Segunda forma array ------"
$multitipo = [int]1, [double]9.5
$multitipo

#Agregar datos al array de una dimension
$miarray += 14

#Agregar datos a array varias dimensiones:
Write-Output "------ arrayVariasDimensiones ------"
$miarray3 += @((15, 9, 2009))
$miarray3

Write-Output "------ el Length ------"
$miarray.Length

```

## Metodos para array:

- `$Array.remove("nombreValorElemento"):` Borra el indice en el que esta ubicado el elemento

- `$diccionario.Add(""):` Agrega en el ultimo indice el elemento

---
# Tablas hash:

Un diccionario o tabla de hashes(en otros lenguajes) son colecciones que relacionan una clave y valor. osea que se asocia una especia de significado

```PowerShell
Write-Output "------ Diccionarios ------"
$tablaHash = @{clave1 = "valor"; clave2 = 22}
$tablaHash
```

## Metodos habituales de tablas hash:

- `$diccionario.remove("clave"):` Borra clave y valor

- `$diccionario.Add("clave", "valor"):` Agrega clava y valor

- `$diccionario.ContainsKey("clave"):` Busca y devuelve true o false si encuentra el nombre de la clave

- `$diccionario.ConstainsValue("valor"):`Busca y devuelve true o false si encuentra el valor

---
# Condicionales

````PowerShell
if(($valor -ne 1) -and ($valor -ne 0)){
	Write-Host("No has introducido nada")
	Exit
} Elseif($valor -eq 1){
	Write-Host("Has introducido el numero correcto")
} Else{
	Write-Host("No has adivinado el numero....")
}

#-------------switch-----------#
switch($opcion){
	1{Get-ChildItem;break}
	2{Get-Date;break}
	3{break}
	default {break}
}
````

# Bucles

````PowerShell
#------------while-----------#
$cont = 0
while($cont -lt 10){
	Write-Host("iteracion numero $($cont)")
	$cont ++
}

#------------do-While-----------#
do{
	Write-Output("1) Opcion 1")
	Write-Output("2) Opcion 2")
	Write-Output("3) Salir")
	Write-Output("Introduce opcion: ")
	$opcion = Read-Host
	Clear-Host
}while($opcion -ne 3)

#------------for-----------#
$array = 'primero', 'segundo', 'tercero'
for($i = 0; $i -le $array.Length; $i++){
	Write-Host($array[$i])
}

#------------foreach-----------#
ForEach ($elemento in Get-ChildItem){
	Write-Output "$($elemento.Name) atributos: $($elemento.Attributes)"
}
````

# Funciones

````PowerShell

function PrimeraFuncion {
	
	Write-Host "Mostrar mensaje tras invocar primera función"
}

function FuncionConPasoParametros {
	param (
	 [parameter(Position=1, Mandatory=$false)][string]$Saludo ="Bienvenido",
	 [parameter(Position=2, Mandatory=$true)][string]$Despedida
   	)
	$Mensaje = $Saludo + ". ", $Despedida
	Write-Host $Mensaje
}
PS > FuncionConPasoParametros -Saludo "hola" -Despedida "aduis"
````

# Class

Una clase es una estructura de datos que combina estados (campos) y acciones (métodos y otros miembros de función) en una sola unidad. 

De una clase se pueden hacer instancias y objetos para usar sus funciones etc y permitir la reutilizacion de codigo


````PowerShell
class ClasePS {
    [String]$Mensaje
    [String]$Nombre

    [void]Saludo() {
        Write-Host $this.Mensaje $this.Nombre
    }
}

PS > $PruebaClase = New-Object 'ClasePS'
PS > $PruebaClase.Mensaje = "Viva PowerShell... "
PS > $PruebaClase.Nombre = "Ahora con clases!"
PS > $PruebaClase.Saludo()
````

# Excepciones


```PowerShell
Try {
    #En esta sección ejecutamos los comandos cuyos errores queremos controlar
    2/0
}
Catch [System.DivideByZeroException] {
    #En esta sección gestionamos una exceción específica
    Write-Output("Dividiendo entre 0")
}
Catch {
    #En esta sección gestionamos cualquier tipo de excepción
    Write-Output("Excepciones generales")
}
Finally {
    #Esta sección se ejecuta siempre, haya o no una excepción
    Write-Output("usado principalmente para cerrar archivos etc")
}
```

# Estructura de objetos

Los objetos son algo muy importante en PowerShell por tanto es importante saber como tratarlos.

El comando `Get-Member` se utiliza para analizar objetos. Te devuelve los resultados indicando que clases y objetos se utilizan y metodos, propiedades, etc.

Se suele utilizar con un pipe `|` como por ejemplo:
```PowerShell
PS > Get-ChildItem | Get-Member
```

Devuelve que usa la libreria DirectoryInfo y FileInfo y las propiedades y metodos que contienen, etc.

# CSharp y PowerShell mejores amigos

Una de las cosas mas interesantes(para mi) que tiene powershell es que permite ejecutar codigo escrito en C#, por ejemplo:

```PowerShell

```