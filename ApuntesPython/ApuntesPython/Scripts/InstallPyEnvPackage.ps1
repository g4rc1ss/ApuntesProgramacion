$Global:CurrentPath = Split-Path $MyInvocation.MyCommand.Path

Set-Location $CurrentPath
Import-Module ".\Library\FilterSearch.ps1"


#Nos posicionamos en la carpeta anterior a Scripts
Set-Location ..

$ubicacionPip = SearchWithFilter -path '.\' -wordToMatch 'pip.exe'

if ($null -eq $ubicacionPip) {
    Write-Error "No se encuentra el pip en una maquina virtual, crea primero la Virtual Environment"
    exit
}

[bool]$isDone = $false
while (!$isDone) {
    Write-Host "Teclea el nombre del paquete que quieres instalar"
    $packageName = Read-Host
    
    powershell "$($ubicacionPip.FullName) install $packageName"
    
    Write-Host "Quieres seguir instalando paquetes? S/n"
    $continue = Read-Host
    if ($continue.ToUpper() -ne "S") {
        $isDone = $true
    }
}

$ubicacionRequirements = SearchWithFilter -path '.\' -wordToMatch 'requirements.txt'

if ($null -eq $ubicacionRequirements) {
    Write-Host "No hay se encuentra un archivo requirements, se creara uno en la raiz"
    "" > .\requirements.txt
    $ubicacionRequirements = SearchWithFilter -path '.\' -wordToMatch 'requirements.txt'
}

foreach ($requirementsPath in $ubicacionRequirements) {
    powershell "$($ubicacionPip.FullName) freeze > $($requirementsPath.FullName)"
}

