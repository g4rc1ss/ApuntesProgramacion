$Global:CurrentPath = Split-Path $MyInvocation.MyCommand.Path

Set-Location $CurrentPath
Import-Module ".\FilterSearch.ps1"


#Nos posicionamos en la carpeta anterior a Scripts
Set-Location ..


$ubicacionPip = SearchWithFilter -path '.\' -wordToMatch 'pip.exe'

$ubicacionRequirements = SearchWithFilter -path '.\' -wordToMatch 'requirements.txt'

if ($null -eq $ubicacionPip) {
    Write-Error "No se encuentra el pip en una maquina virtual, crea primero la Virtual Environment"

    Write-Output "Quieres crear la maquina virtual? [S]i o [N]o (por defecto es S):"
    $opcionVM = Read-Host
    if ('' -eq $opcionVM -or $opcionVM.ToUpper().Contains('S')) {
        python.exe -m venv "env"
        $ubicacionPip = SearchWithFilter -path '.\' -wordToMatch 'pip.exe'
    }
    else {
        exit
    }
}

if ($null -eq $ubicacionRequirements) {
    Write-Error "No se encuentra el archivo requirements.txt"
    exit
}

foreach ($requirementsPath in $ubicacionRequirements) {
    powershell "$($ubicacionPip.FullName) install -r $($requirementsPath.FullName)"
}