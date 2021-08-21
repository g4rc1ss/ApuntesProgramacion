$Global:CurrentPath = Split-Path $MyInvocation.MyCommand.Path

Set-Location $CurrentPath
Import-Module ".\Library\FilterSearch.ps1"


#Nos posicionamos en la carpeta anterior a Scripts
Set-Location ..

$ubicacionPip = SearchWithFilter -path '.\' -wordToMatch 'pip.exe'

$ubicacionRequirements = SearchWithFilter -path '.\' -wordToMatch 'requirements.txt'


if ($null -eq $ubicacionRequirements) {
    Write-Error "No se encuentra el archivo requirements.txt"
    exit
}

foreach ($requirementsPath in $ubicacionRequirements) {
    $textoRequirements = [System.IO.File].ReadAllText($ubicacionRequirements)

    $dependenciesToUpdate = $textoRequirements.Split("\n")
    foreach ($package in $dependenciesToUpdate) {
        powershell "$($ubicacionPip.FullName) install -U $($package.Spit("==")[0])"
    }
    powershell "$($ubicacionPip.FullName) freeze > $($requirementsPath.FullName)"
}
