# Instalacion de python a nivel de proyecto
Una vez tenemos el paquete de python instalado a nivel global en el equipo, si queremos usarlo para un proyecto, deberiamos de crear una maquina virtual de python `venv` para instalar y gestionar las dependencias del proyecto, sino se instalarian a nivel global

Para la gestion de esas dependencias he creado unos Scripts, que estan en la carpeta correspondiente en `powershell` que gestionan la creacion y actualizacion tanto del entorno virtual de `python`, como de las dependendias con el `Requirements.txt`


**FilterSearch.ps1**
```powershell
function SearchWithFilter {
    param (
        [Parameter(Position = 1, Mandatory = $true)][string]$path,
        [Parameter(Position = 2, Mandatory = $true)][string]$wordToMatch
    )
    return Get-ChildItem $path -Recurse -File | Where-Object Name -match $wordToMatch 
}
```
- Creamos una libreria reutilizable en powershell para buscar a partir de un path los archivos que vamos a necesitar, por ejemplo el `requirements.txt` y el `pip`


**InitializePyEnvWithDependencies.ps1**
```powershell
$Global:CurrentPath = Split-Path $MyInvocation.MyCommand.Path

Set-Location $CurrentPath
Import-Module ".\FilterSearch.ps1"


#Nos posicionamos en la carpeta anterior a Scripts
Set-Location ..

$pythonCommand = "python" # Default value

# Mac tiene por defecto instalado la version de python2, por tanto
# si instalamos la 3, el comando se llama `python3`
if ([System.Environment]::OSVersion.Platform.ToString().ToLower().Contains("unix")) {
    $pythonCommand = "python3"
}


$ubicacionActivate = SearchWithFilter -path '.\' -wordToMatch 'Activate.ps1'
$ubicacionRequirements = SearchWithFilter -path '.\' -wordToMatch 'requirements.txt'

if ($null -eq $ubicacionActivate) {
    Write-Error "No se encuentra el pip en una maquina virtual, crea primero la Virtual Environment"

    Write-Output "Quieres crear la maquina virtual? [S]i o [N]o (por defecto es S):"
    $opcionVM = Read-Host
    if ('' -eq $opcionVM -or $opcionVM.ToUpper().Contains('S')) {
        
        Invoke-Expression "$($pythonCommand) -m venv env"

        $ubicacionActivate = SearchWithFilter -path '.\' -wordToMatch 'Activate.ps1'
    }
    else {
        exit
    }
}

if ($null -eq $ubicacionRequirements) {
    Write-Error "No se encuentra el archivo requirements.txt"
    exit
}


Invoke-Expression "$($ubicacionActivate.FullName)"

foreach ($requirementsPath in $ubicacionRequirements) {
    Invoke-Expression "pip install -r $($requirementsPath.FullName)"
}
```
- Utilizamos la libreria de mas arriba para localizar el pip.exe y el requirements
- Si no se encuentra, significa que no tenemos el entorno virtualizado asique se da la opcion de inicializarlo
- Si se encuentra el requirements, instalamos las dependencias en el entorno y sino, acabamos el proceso


**InstallPyEnvPackage.ps1**
```powershell
$Global:CurrentPath = Split-Path $MyInvocation.MyCommand.Path

Set-Location $CurrentPath
Import-Module ".\FilterSearch.ps1"


#Nos posicionamos en la carpeta anterior a Scripts
Set-Location ..


$ubicacionActivate = SearchWithFilter -path '.\' -wordToMatch 'Activate.ps1'

if ($null -eq $ubicacionActivate) {
    Write-Error "No se encuentra el Activate en el entorno virtual, crea primero la Virtual Environment"
    exit
}

Invoke-Expression "$($ubicacionActivate.FullName)"
[bool]$isDone = $false
while (!$isDone) {
    Write-Host "Teclea el nombre del paquete que quieres instalar"
    $packageName = Read-Host

    Invoke-Expression "pip install $packageName"

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
    Invoke-Expression "pip freeze > $($requirementsPath.FullName)"
}
```
- Buscamos las rutas de los ejecutables necesarios
- Instalamos el paquete que necesitamos y creamos o agregamos dicho paquete al requirements.txt


**UpdateAllDependencies.ps1**
```powershell
$Global:CurrentPath = Split-Path $MyInvocation.MyCommand.Path

Set-Location $CurrentPath
Import-Module ".\FilterSearch.ps1"


#Nos posicionamos en la carpeta anterior a Scripts
Set-Location ..

$ubicacionActivate = SearchWithFilter -path '.\' -wordToMatch 'Activate.ps1'
Invoke-Expression "$($ubicacionActivate.FullName)"

$ubicacionRequirements = SearchWithFilter -path '.\' -wordToMatch 'requirements.txt'


if ($null -eq $ubicacionRequirements) {
    Write-Error "No se encuentra el archivo requirements.txt"
    exit
}

foreach ($requirementsPath in $ubicacionRequirements) {
    $textoRequirements = [IO.FILE]::ReadAllText($requirementsPath.FullName);

    $dependenciesToUpdate = $textoRequirements.Split("`n")
    foreach ($package in $dependenciesToUpdate) {
        Invoke-Expression "pip install -U $($package.Split("==")[0])"
    }
    Invoke-Expression "pip freeze > $($requirementsPath.FullName)"
}
```
- Leemos el requiments linea por linea y ejecutamos el comando del pip para realizar un update a cada uno de los paquetes