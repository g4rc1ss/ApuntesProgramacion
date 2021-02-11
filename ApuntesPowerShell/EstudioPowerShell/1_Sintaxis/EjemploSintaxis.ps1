#------------Variables---------#
$string = "Hola"
$int = 1
$double = 2.3

Write-Output $string $int $double

$string.GetType(); $int.GetType(); $double.GetType()

#------------Operadores Aritmeticos---------#
Write-Output "------ Operadores Aritmeticos ------"

1+2; 2-1; 5*5; 20/2; 25%2

#------------Operadores de Comparacion---------#
Write-Output "------ Operadores Comparacion ------"

$int -ne $double # No son iguales
$int -eq $double # Son iguales
$int -ge $double # Es mayor que
$int -ge $double # Es mayor o igual que
$int -lt $double # menor que
$int -le $double # menor o igual que

#------------Operadores Logicos---------#
Write-Output "------ Logicos ------"

$int -ne $double -and $int -ge $double
$int -ne $double -or $int -ge $double
$int -ne $double -xor $int -ge $double
-not $int -ge $double
!$int -ge $double

#------------Operadores Intervalo---------#
Write-Output "------ Intervalo ------"

$valorini = 2
$valorfinal = 11
$valorini .. $valorfinal


#------------Array---------#
#Primera Forma:
Write-Output "------ Primera forma array ------"
[int[]]$miarray = 22, 12, 1986
$miarray2 = 22, 12, 1986
[int[][]] $miarray3 = @((14, 22, 2008), (1,2,3))
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

#HashTables/Diccionarios
Write-Output "------ Diccionarios ------"
$tablaHash = @{hash1 = 22; hash2 = 1986}
$tablaHash


#------------Condicionales---------#
<# 
if condicion 
		Bloque de instrucciones A
Si No Si
		Bloque de instrucciones B
Si No
		Bloque de instrucciones C
Fin Si
#>

#Ejemplo:

Write-Host("Introduce un valor entre 0 y 1")
$valor = Read-Host

if(($valor -ne 1) -and ($valor -ne 0)){
	Write-Host("No has introducido nada")
	Exit
} Elseif($valor -eq 1){
	Write-Host("Has introducido el numero correcto")
} Else{
	Write-Host("No has adivinado el numero....")
}

pause
Clear-Host
#se va a hacer un ejemplo de un menu con un switch
Write-Host("Menu")
Write-Host("====")
Write-Host("1) Listar directorio")
Write-Host("2) Dar la hora")
Write-Host("3) Salir")
Write-Host("Introduce la opcion: ")
$opcion = Read-Host

switch($opcion){
	1{Get-ChildItem;break}
	2{Get-Date;break}
	3{break}
	default {break}
}


#------------Bucles---------#
#while:
<#
 Como funciona el bucle? El funcionamiento del bucle es sencillo y se divide en los siguientes pasos:
	- Se evalua la condicion
	- Si la condicion es falsa se sale del bucle sin ejecutar instrucciones
	- Si la condicion es cierta se ejecuta el bloque de instrucciones
	- Se vuelve a iterar evaluando la condicion
#>
$cont = 0
while($cont -lt 10){
	Write-Host("iteracion numero $($cont)")
	$cont ++
}

#do-while:
<#
Este bucle es especial ya que es postprobado, es decir, su condicion de salida se comprueba una vez se ha ejecutado el
bloque de instrucciones previo. En otras palabras este tipo de bucle se ejecuta 1 o N veces. La sintaxis del bucle en
formato de pseudocodigo es la siguiente:
Hacer
	Bloque
Mientras que(condicion)
#>
do{
	Write-Output("1) Opcion 1")
	Write-Output("2) Opcion 2")
	Write-Output("3) Salir")
	Write-Output("Introduce opcion: ")
	$opcion = Read-Host
	Clear-Host
}while($opcion -ne 3)

<#
for
====

El funcionamiento que tiene el bucle for es el siguiente:
	- Se evalua el inicio, normalmente es la inicializacion de una variable
	- Se evalua la condicion, cuando esta sea falsa se termina el bucle
	- Si la condicion es verdadera, se ejecutan las instrucciones
	- La expresion se incrementa y se vuelve a evaluar la condicion
#>
$array = 'primero', 'segundo', 'tercero'
for($i = 0; $i -le $array.Length; $i++){
	Write-Host($array[$i])
}

ForEach ($elemento in Get-ChildItem){
	Write-Output "$($elemento.Name) atributos: $($elemento.Attributes)"
}

#------------Funciones---------#
# Obtener la ruta dentro del sistema de ficheros en que se encuentra este fichero *.ps1
$Global:CurrentPath = Split-Path $MyInvocation.MyCommand.Path
# Invocar librería
Import-Module $CurrentPath"\libreriaPowerShell.ps1"

FuncionConPasoParametros -Saludo "¡Hola!" -Despedida "Adios"

# El parametro Saludo es opcional
FuncionConPasoParametros -Despedida "Adios"

#------------Clases---------#
Write-Host("------------- Clases ---------")
class ClasePS {
    [String]$Mensaje
    [String]$Nombre

    [void]Saludo() {
        Write-Host $this.Mensaje $this.Nombre
    }
}

$PruebaClase = New-Object 'ClasePS'
$PruebaClase.Mensaje = "Viva PowerShell... "
$PruebaClase.Nombre = "Ahora con clases!"
$PruebaClase.Saludo()

#------------Excepciones---------#
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

#Write-Output(2/0) -ErrorAction="Dividiendooo"

#------------Csharp---------#

[String]$codigo = @"
using System;

namespace prueba {
	public class Prueba{
		public static void Main(){
			for(int x = 0; x < 10; x++)
				Console.Write($"{x} ");
		}
	}
}
"@
Add-Type -TypeDefinition $codigo
[prueba.Prueba]::Main()

