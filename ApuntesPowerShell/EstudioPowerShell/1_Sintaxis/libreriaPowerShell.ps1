#------------Funciones---------#
<#
Funcion [Ambito] nombreDeLaAplicacion [(lista argumentos)]
	Bloque de Instrucciones
FinFuncion
#>
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