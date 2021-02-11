$rutaArchivosToChange = '.\ApuntesCsharp\BackEnd\01_CsharpBasico\1_Sintaxis\Documentacion.NET'

$ubicacionArchivos = Get-ChildItem $rutaArchivosToChange -Recurse -File | Where-Object Name -match '^[0-9][^0-9]'


foreach ($archivo in $ubicacionArchivos) {
    
    Move-Item ($archivo.FullName) ($archivo.FullName.Replace($archivo.Name, '0' + $archivo.Name))
    
    Write-Host "Archivo" ($archivo.FullName) "modificado"
}

$ubicacionDirectorios = Get-ChildItem $rutaArchivosToChange -Recurse -Directory | Where-Object Name -match '^[0-9][^0-9]'
foreach ($directorio in $ubicacionDirectorios) {

    Move-Item ($directorio.FullName) ($directorio.FullName.Replace($directorio.Name, '0' + $directorio.Name))

    Write-Host "Directorio" ($directorio.FullName) "modificado"
}
